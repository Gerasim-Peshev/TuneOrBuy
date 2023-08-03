using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Services.Parts.Models;
using TuneOrBuy.Web.Data;
using TuneOrBuy.Data.Models;
using static TuneOrBuy.Data.DataConstants;
using Part = TuneOrBuy.Data.Models.Part;
using Seller = TuneOrBuy.Data.Models.Seller;
using Buyer = TuneOrBuy.Data.Models.Buyer;
using Town = TuneOrBuy.Data.Models.Town;

namespace TuneOrBuy.Services.Parts
{
    public class PartService : IPartService
    {
        private readonly TuneOrBuyDbContext context;

        public PartService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public async Task<Seller> GetSellerByBuyerIdAsync(string userId)
        {
            return await context.Sellers.FirstAsync(s => s.BuyerId == Guid.Parse(userId));
        }

        public async Task<Seller> GetSellerBySellerIdAsync(string userId)
        {
            return await context.Sellers.FirstAsync(s => s.Id == Guid.Parse(userId));
        }

        public async Task<Buyer> GetBuyerByIdAsync(string userId)
        {
            return await context.Users.FirstAsync(u => u.Id.ToString().ToLower() == userId.ToLower());
        }

        public async Task<Town> GetTownByIdAsync(int townId)
        {
            return await context.Towns.FirstAsync(t => t.Id == townId);
        }

        public async Task<PartServiceModel> GetPart(string partId)
        {
            var part = await context.Parts.FirstAsync(p => p.Id.ToString().ToLower() == partId.ToLower());

            return new PartServiceModel()
            {
                Id = part.Id.ToString(),
                Name = part.Name,
                Manufacturer = part.Manufacturer,
                Brand = part.Brand,
                Year = part.Year,
                Price = part.Price,
                SellerId = part.SellerId.ToString(),
                ImageUrl = part.ImageUrl,
                Description = part.Description
            };
        }

        public async Task<List<PartServiceModel>> AllPartsAsync()
        {
            var parts = await context.Parts
                                     .Select(p => new PartServiceModel()
                                      {
                                          Id = p.Id.ToString(),
                                          Name = p.Name,
                                          Manufacturer = p.Manufacturer,
                                          Brand = p.Brand,
                                          Year = p.Year,
                                          Price = p.Price,
                                          ImageUrl = p.ImageUrl,
                                          SellerId = p.SellerId.ToString(),
                                          Description = p.Description
                                      })
                                     .ToListAsync();

            if (parts == null)
            {
                return new List<PartServiceModel>();
            }

            return parts;
        }

        public async Task CreatePartAsync(string name, string manufacturer, string brand, int year, decimal price, string sellerId, string imageUrl,
                                    string description)
        {
            var seller = await GetSellerByBuyerIdAsync(sellerId);

            var partToAdd = new Part()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Manufacturer = manufacturer,
                Brand = brand,
                Year = DateTime.Parse($"01/01/{year}"),
                Price = price,
                SellerId = seller.Id,
                Seller = seller,
                ImageUrl = imageUrl,
                Description = description
            };

            seller.PartsForSell.Add(partToAdd);

            await context.Parts.AddAsync(partToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<PartDetailsServiceModel> PartDetailsByIdAsync(string partId)
        {
            var part = await context.Parts.FirstAsync(c => c.Id.ToString().ToLower() == partId.ToLower());

            var seller = await GetSellerBySellerIdAsync(part.SellerId.ToString());
            seller.Town = await GetTownByIdAsync(seller.TownId);
            seller.Buyer = await GetBuyerByIdAsync(seller.BuyerId.ToString());

            var partToReturn = new PartDetailsServiceModel()
            {
                Manufacturer = part.Manufacturer,
                Brand = part.Brand,
                Year = part.Year,
                Price = part.Price,
                ImageUrl = part.ImageUrl,
                Seller = seller,
                Description = part.Description
            };

            return partToReturn;
        }

        public async Task EditPartAsync(string id, string name, string manufacturer, string brand, int year, decimal price, string sellerId,
                                  string imageUrl, string description)
        {
            var partToEdit = await context.Parts.FirstAsync(p => p.Id.ToString().ToLower() == id.ToLower());

            partToEdit.Manufacturer = manufacturer;
            partToEdit.Brand = brand;
            partToEdit.Year = DateTime.Parse($"01/01/{year}");
            partToEdit.Price = price;
            partToEdit.SellerId = Guid.Parse((ReadOnlySpan<char>)sellerId);
            partToEdit.ImageUrl = imageUrl;
            partToEdit.Description = description;

            await context.SaveChangesAsync();
        }

        public async Task DeletePart(string partId)
        {
            var partToDelete = await context.Parts.FirstAsync(p => p.Id.ToString().ToLower()  == partId.ToLower());

            context.Remove(partToDelete);
            await context.SaveChangesAsync();
        }

        public async Task ToFavouriteParts(string partId, string userId)
        {
            var buyer = await context.Users.FirstAsync(b => b.Id.ToString().ToLower() == userId.ToLower());

            var contains = await ContainsPart(partId, userId);

            if (!contains.Item1)
            {
                buyer.FavouriteParts.Add(contains.Item3);
            }
            else if (contains.Item1)
            {
                buyer.FavouriteParts.Remove(contains.Item3);
            }

            await context.SaveChangesAsync();
        }

        public async Task<Tuple<bool, Buyer, Part>> ContainsPart(string partId, string userId)
        {
            var part = await context.Parts
                                   .FirstAsync(c => c.Id.ToString().ToLower() == partId.ToLower());

            var buyer = await context.Users
                                     .FirstAsync(b => b.Id.ToString().ToLower() == userId.ToLower());
            return new Tuple<bool, Buyer, Part>(
                buyer.FavouriteParts.Any(c => c.Id.ToString().ToLower() == partId.ToLower()), buyer, part);
        }

        public async Task<List<PartServiceModel>> MyFavoritePartsAsync(string userId)
        {
            var parts = new List<Part>();

            foreach (var part in await context.Parts.ToListAsync())
            {
                var contains = await ContainsPart(part.Id.ToString(), userId);
                if (contains.Item1)
                {
                    parts.Add(part);
                }
            }

            var partsToReturn = parts
                             .Select(fp => new PartServiceModel()
                              {
                                  Id = fp.Id.ToString().ToLower(),
                                  Manufacturer = fp.Manufacturer,
                                  Brand = fp.Brand,
                                  Year = fp.Year,
                                  Price = fp.Price,
                                  ImageUrl = fp.ImageUrl,
                                  SellerId = fp.SellerId.ToString(),
                                  Description = fp.Description,
                              })
                             .ToList();

            if (partsToReturn == null)
            {
                return new List<PartServiceModel>();
            }

            return partsToReturn;
        }
    }
}
