using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Data;
using CarServiceOwner = TuneOrBuy.Data.Models.CarServiceOwner;

namespace TuneOrBuy.Services.CarServiceOwners
{
    public class CarServiceOwnerService : ICarServiceOwnerService
    {
        private readonly TuneOrBuyDbContext context;
        private ICarServiceOwnerService _carServiceOwnerImplementation;

        public CarServiceOwnerService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public async Task<bool> UserIsCarServiceOwner(Guid userId)
        {
            return await context.CarServiceOwners.AnyAsync(c => c.BuyerId == userId);
        }

        public async Task<bool> ExistsById(Guid userId)
        {
            return await context.CarServiceOwners.AnyAsync(c => c.BuyerId == userId);
        }

        public async Task<bool> ExistsByPhoneNumber(string phoneNumber)
        {
            return await context.CarServiceOwners.AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task CreateSeller(Guid userId, string phoneNumber)
        {
            var carServiceOwnerToAdd = new CarServiceOwner()
            {
                BuyerId = userId,
                Buyer = await GetBuyerAsync(userId),
                PhoneNumber = phoneNumber
            };

            await context.CarServiceOwners.AddAsync(carServiceOwnerToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<Buyer> GetBuyerAsync(Guid userId)
        {
            return await context.Users.FirstAsync(u => u.Id == userId);
        }
    }
}
