using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.CarServices.Models;
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

        public async Task<List<CarServiceServiceModel>> GetAllCarServicesForManage(string userId)
        {
            var carServiceOwner = await GetCarServiceOwner(userId);


            var carServices = await context.CarServices
                                    .Where(c => c.CarServiceOwnerId == carServiceOwner.Id)
                                    .Select(carService => new CarServiceServiceModel()
                                     {
                                        Id = carService.Id.ToString(),
                                        CarServiceOwnerId = carService.CarServiceOwnerId.ToString(),
                                        Name = carService.Name,
                                        Address = carService.Address,
                                        TownId = carService.TownId,
                                        Town = carService.Town,
                                        PhoneNumber = carService.PhoneNumber,
                                        Services = carService.Services,
                                        OpenHour = carService.OpenHour,
                                        CloseHour = carService.CloseHour,
                                        ImageUrl = carService.ImageUrl,
                                        Description = carService.Description
                                    })
                                    .ToListAsync();

            if (carServices == null)
            {
                return new List<CarServiceServiceModel>();
            }

            return carServices;
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
