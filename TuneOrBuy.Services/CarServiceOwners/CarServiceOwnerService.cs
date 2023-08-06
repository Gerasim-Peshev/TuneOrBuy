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

        public CarServiceOwnerService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public async Task<bool> UserIsCarServiceOwner(string userId)
        {
            return await context.CarServiceOwners.AnyAsync(c => c.BuyerId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<Buyer> GetBuyerAsync(string userId)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id.ToString().ToLower() == userId.ToLower());
        }

        public async Task<CarServiceOwner> GetCarServiceOwner(string userId)
        {
            return await context.CarServiceOwners.FirstOrDefaultAsync(cso => cso.BuyerId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await context.CarServiceOwners.AnyAsync(c => c.BuyerId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<bool> ExistsByPhoneNumber(string phoneNumber)
        {
            return await context.CarServiceOwners.AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task CreateCarServiceOwner(string userId, string phoneNumber)
        {
            var carServiceOwnerToAdd = new CarServiceOwner()
            {
                BuyerId = Guid.Parse(userId),
                Buyer = await GetBuyerAsync(userId),
                PhoneNumber = phoneNumber
            };

            await context.CarServiceOwners.AddAsync(carServiceOwnerToAdd);
            await context.SaveChangesAsync();
        }
    }
}
