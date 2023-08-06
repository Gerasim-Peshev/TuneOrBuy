using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Services.Parts.Models;
using TuneOrBuy.Web.Data;
using Buyer = TuneOrBuy.Data.Models.Buyer;
using Seller = TuneOrBuy.Data.Models.Seller;
using Town = TuneOrBuy.Data.Models.Town;

namespace TuneOrBuy.Services.Sellers
{
    public class SellerService : ISellerService
    {
        private readonly TuneOrBuyDbContext context;

        public SellerService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public async Task<bool> UserIsSeller(string userId)
        {
            return await context.Sellers.AnyAsync(s => s.BuyerId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<IEnumerable<Town>> GetAllTowns()
        {
            return await context
                        .Towns
                        .Select(t => new Town()
                        {
                            Id = t.Id,
                            Name = t.Name
                        })
                        .OrderBy(t => t.Name)
                        .ToListAsync();
        }

        public async Task<Buyer> GetBuyerAsync(string userId)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id.ToString().ToLower() == userId.ToLower());
        }

        public async Task<Town> GetTownByIdAsync(int townId)
        {
            return await context.Towns.FirstOrDefaultAsync(t => t.Id == townId);
        }

        public async Task<Seller> GetSeller(string userId)
        {
            return await context.Sellers.FirstOrDefaultAsync(s => s.BuyerId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await context.Sellers.AnyAsync(s => s.BuyerId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<bool> ExistsByPhoneNumber(string phoneNumber)
        {
            return await context.Sellers.AnyAsync(s => s.PhoneNumber == phoneNumber);
        }

        public async Task CreateSeller(string userId, string phoneNumber, int townId, string imageUrl)
        {
            var sellerToAdd = new Seller()
            {
                BuyerId = Guid.Parse(userId),
                Buyer = await GetBuyerAsync(userId),
                PhoneNumber = phoneNumber,
                TownId = townId,
                Town = await GetTownByIdAsync(townId),
                ImageUrl = imageUrl
            };

            await context.Sellers.AddAsync(sellerToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<List<CarServiceModel>> GetAllCarsForSell(string userId)
        {
            var seller = await GetSeller(userId);

            var cars = await context.Cars
                                    .Where(c => c.SellerId == seller.Id)
                                    .Select(car => new CarServiceModel()
                                    {
                                        Id = car.Id.ToString(),
                                        Manufacturer = car.Manufacturer,
                                        Brand = car.Brand,
                                        VIN = car.VIN,
                                        BodyType = car.BodyType,
                                        Fuel = car.Fuel,
                                        HorsePower = car.HorsePower,
                                        Year = car.Year,
                                        FirstRegistrationYear = car.FirstRegistrationYear,
                                        Price = car.Price,
                                        TraveledDistance = car.TraveledDistance,
                                        ImageUrl = car.ImageUrl,
                                        SellerId = car.SellerId.ToString(),
                                        GearType = car.GearType,
                                        Color = car.Color,
                                        NumberOfDoors = car.NumberOfDoors,
                                        NumberOfSeats = car.NumberOfSeats,
                                        Equipments = car.Equipments,
                                        Description = car.Description,
                                        ServiceHistory = car.ServiceHistory
                                    })
                                    .ToListAsync();

            if (cars == null)
            {
                return new List<CarServiceModel>();
            }

            return cars;
        }

        public async Task<List<PartServiceModel>> GetAllPartsForSell(string userId)
        {
            var seller = await GetSeller(userId);

            var parts = await context.Parts
                                     .Where(p => p.SellerId == seller.Id)
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
    }
}
