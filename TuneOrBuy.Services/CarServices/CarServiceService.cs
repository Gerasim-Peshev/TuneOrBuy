using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.CarServices.Models;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Data;
using static TuneOrBuy.Data.DataConstants;
using Buyer = TuneOrBuy.Data.Models.Buyer;
using CarService = TuneOrBuy.Data.Models.CarService;
using CarServiceOwner = TuneOrBuy.Data.Models.CarServiceOwner;
using Town = TuneOrBuy.Data.Models.Town;

namespace TuneOrBuy.Services.CarServices
{
    public class CarServiceService : ICarServiceService
    {
        private readonly TuneOrBuyDbContext context;

        public CarServiceService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public async Task<CarServiceOwner> GetOwnerByBuyerIdAsync(string userId)
        {
            return await context.CarServiceOwners.FirstAsync(cso => cso.BuyerId == Guid.Parse(userId));
        }

        public async Task<CarServiceOwner> GetOwnerByOwnerIdAsync(string userId)
        {
            return await context.CarServiceOwners.FirstAsync(cso => cso.Id == Guid.Parse(userId));
        }

        public async Task<Buyer> GetBuyerByIdAsync(string userId)
        {
            return await context.Users.FirstAsync(u => u.Id.ToString().ToLower() == userId.ToLower());
        }

        public async Task<Town> GetTownByIdAsync(int townId)
        {
            return await context.Towns.FirstAsync(t => t.Id == townId);
        }

        public async Task<CarServiceServiceModel> GetCarServiceAsync(string carServiceId)
        {
            var carService = await context.CarServices
                                          .FirstAsync(cs => cs.Id.ToString().ToLower() == carServiceId.ToLower());

            carService.Town = await GetTownByIdAsync(carService.TownId);

            return new CarServiceServiceModel()
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
            };
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

        public async Task<List<CarServiceServiceModel>> AllCarServicesAsync()
        {
            var carServices = await context.CarServices
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
                carServices = new List<CarServiceServiceModel>();
            }

            return carServices;
        }

        public async Task CreateCarServiceAsync(string name, string address, string ownerId, int townId, string phoneNumber, string services, int openHour,
                                   int closeHour, string imageUrl, string description)
        {
            var owner = await GetOwnerByBuyerIdAsync(ownerId);
            var town = await GetTownByIdAsync(townId);

            var carService = new CarService()
            {
                Id = new Guid(),
                Name = name,
                Address = address,
                CarServiceOwnerId = owner.Id,
                CarServiceOwner = owner,
                TownId = townId,
                Town = town,
                PhoneNumber = phoneNumber,
                Services = services,
                OpenHour = new DateTime(2023, 1, 1, openHour, 0, 0),
                CloseHour = new DateTime(2023, 1, 1, closeHour, 0, 0),
                ImageUrl = imageUrl,
                Description = description
            };

            owner.CarServices.Add(carService);

            await context.CarServices.AddAsync(carService);
            await context.SaveChangesAsync();
        }

        public async Task<CarServiceDetailsServiceModel> CarServiceDetailsByIdAsync(string carServiceId)
        {
            var carService = await context.CarServices
                                          .FirstAsync(cs => cs.Id.ToString().ToLower() == carServiceId.ToLower());

            var owner = await GetOwnerByOwnerIdAsync(carService.CarServiceOwnerId.ToString());
            var town = await GetTownByIdAsync(carService.TownId);
            owner.Buyer = await GetBuyerByIdAsync(owner.BuyerId.ToString());

            var carServiceToReturn = new CarServiceDetailsServiceModel()
            {
                Name = carService.Name,
                Address = carService.Address,
                CarServiceOwner = owner,
                Town = town,
                PhoneNumber = carService.PhoneNumber,
                Services = carService.Services,
                OpenHour = carService.OpenHour,
                CloseHour = carService.CloseHour,
                ImageUrl = carService.ImageUrl,
                Description = carService.Description
            };

            return carServiceToReturn;
        }

        public async Task EditCarServiceAsync(string id, string name, string address, string ownerId, int townId, string phoneNumber, string services,
                                        int openHour, int closeHour, string imageUrl, string description)
        {
            var carService = await context.CarServices
                                    .FirstAsync(cs => cs.Id.ToString().ToLower() == id.ToLower());

            carService.Name = name;
            carService.Address = address;
            carService.CarServiceOwnerId = Guid.Parse((ReadOnlySpan<char>)ownerId);
            carService.TownId = townId;
            carService.PhoneNumber = phoneNumber;
            carService.Services = String.Join(", ", services);
            carService.OpenHour = new DateTime(2023, 1, 1, openHour, 0, 0);
            carService.CloseHour = new DateTime(2023, 1, 1, closeHour, 0, 0);
            carService.Services = services;
            carService.ImageUrl = imageUrl;
            carService.Description = description;

            await context.SaveChangesAsync();
        }

        public async Task DeleteCarServiceAsync(string carServiceId)
        {
            var carService = await context.CarServices
                                    .FirstAsync(cs => cs.Id.ToString().ToLower() == carServiceId.ToLower());

            context.Remove(carService);
            await context.SaveChangesAsync();
        }

        public async Task ToFavouriteCarsAsync(string carServiceId, string userId)
        {
            var buyer = await context.Users
                                     .FirstAsync(u => u.Id.ToString().ToLower() == userId.ToLower());

            var contains = await ContainsCarServiceAsync(carServiceId, userId);

            if (!contains.Item1)
            {
                buyer.FavouriteCarServices.Add(contains.Item3);
            }
            else if (contains.Item1)
            {
                buyer.FavouriteCarServices.Remove(contains.Item3);
            }

            await context.SaveChangesAsync();
        }

        public async Task<Tuple<bool, Buyer, CarService>> ContainsCarServiceAsync(string carServiceId, string userId)
        {
            var carService = await context.CarServices
                                          .FirstAsync(cs => cs.Id.ToString().ToLower() == carServiceId.ToLower());

            var buyer = await context.Users
                                     .FirstAsync(b => b.Id.ToString().ToLower() == userId.ToLower());

            return new Tuple<bool, Buyer, CarService>(
            buyer.FavouriteCarServices.Any(cs => cs.Id.ToString().ToLower() == carServiceId.ToLower()), buyer, carService);
        }

        public async Task<List<CarServiceServiceModel>> MyFavoriteCarServicesAsync(string userId)
        {
            var carServices = new List<CarService>();

            foreach (var carService in await context.CarServices.ToListAsync())
            {
                var contains = await ContainsCarServiceAsync(carService.Id.ToString(), userId);
                if (contains.Item1)
                {
                    carServices.Add(carService);
                }
            }

            var carServicesToReturn = carServices
                              .Select(fcs => new CarServiceServiceModel()
                              {
                                  Id = fcs.Id.ToString().ToLower(),
                                  CarServiceOwnerId = fcs.CarServiceOwnerId.ToString(),
                                  Name = fcs.Name,
                                  Address = fcs.Address,
                                  TownId = fcs.TownId,
                                  PhoneNumber = fcs.PhoneNumber,
                                  Services = fcs.Services,
                                  OpenHour = fcs.OpenHour,
                                  CloseHour = fcs.CloseHour,
                                  ImageUrl = fcs.ImageUrl,
                                  Description = fcs.Description
                              })
                              .ToList();

            if (carServicesToReturn == null)
            {
                return new List<CarServiceServiceModel>();
            }

            return carServicesToReturn;
        }
    }
}
