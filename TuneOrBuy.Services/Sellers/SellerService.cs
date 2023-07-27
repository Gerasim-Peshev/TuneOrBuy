using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Data;

namespace TuneOrBuy.Services.Sellers
{
    public class SellerService : ISellerService
    {
        private readonly TuneOrBuyDbContext context;

        public SellerService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public  async Task<bool> UserIsSeller(Guid userId)
        {
            return await context.Sellers.AnyAsync(s => s.BuyerId == userId);
        }

        public async Task<Seller> GetSeller(string userId)
        {
            return await context.Sellers.FirstAsync(s => s.BuyerId == Guid.Parse(userId));
        }

        public async Task<bool> ExistsById(Guid userId)
        {
            return await context.Sellers.AnyAsync(s => s.BuyerId == userId);
        }

        public async Task<bool> ExistsByPhoneNumber(string phoneNumber)
        {
            return await context.Sellers.AnyAsync(s => s.PhoneNumber == phoneNumber);
        }

        public async Task CreateSeller(Guid userId, string phoneNumber, int townId, string imageUrl)
        {
            var sellerToAdd = new Seller()
            {
                BuyerId = userId,
                Buyer = await GetBuyerAsync(userId),
                PhoneNumber = phoneNumber,
                TownId = townId,
                Town = await GetTownByIdAsync(townId),
                ImageUrl = imageUrl
            };

            await context.Sellers.AddAsync(sellerToAdd);
            await context.SaveChangesAsync();
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
                        .ToListAsync();
        }

        public async Task<Buyer> GetBuyerAsync(Guid userId)
        {
            return await context.Users.FirstAsync(u => u.Id == userId);
        }

        public async Task<Town> GetTownByIdAsync(int townId)
        {
            return await context.Towns.FirstAsync(t => t.Id == townId);
        }
    }
}
