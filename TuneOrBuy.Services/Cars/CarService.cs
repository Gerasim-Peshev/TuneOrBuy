using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Data;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Data;

namespace TuneOrBuy.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly TuneOrBuyDbContext context;

        public CarService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public async Task<Seller> GetSeller(string userId)
        {
            return await context.Sellers.FirstAsync(s => s.BuyerId == Guid.Parse(userId));
        }

        public async Task<CarServiceModel> GetCar(string carId)
        {
            var car = await context.Cars.FirstAsync(c => c.Id == Guid.Parse(carId));

            return new CarServiceModel()
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
            };
        }

        public async Task<List<CarServiceModel>> AllCarsAsync()
        {
            var cars = await context.Cars.Select(c => new CarServiceModel()
                                 {
                                     Id = c.Id.ToString(),
                                     Manufacturer = c.Manufacturer,
                                     Brand = c.Brand,
                                     VIN = c.VIN,
                                     BodyType = c.BodyType,
                                     Fuel = c.Fuel,
                                     HorsePower = c.HorsePower,
                                     Year = c.Year,
                                     FirstRegistrationYear = c.FirstRegistrationYear,
                                     Price = c.Price,
                                     TraveledDistance = c.TraveledDistance,
                                     ImageUrl = c.ImageUrl,
                                     SellerId = c.SellerId.ToString(),
                                     GearType = c.GearType,
                                     Color = c.Color,
                                     NumberOfDoors = c.NumberOfDoors,
                                     NumberOfSeats = c.NumberOfSeats,
                                     Equipments = c.Equipments,
                                     Description = c.Description,
                                     ServiceHistory = c.ServiceHistory
                                 })
                                .ToListAsync();

            if (cars == null)
            {
                return new List<CarServiceModel>();
            }

            return cars;
        }

        public async Task<IEnumerable<CarServiceModel>> MyCarsAsync(string userId)
        {
            return await context.Cars
                                .Where(c => c.SellerId == Guid.Parse(userId))
                                .Select(c => new CarServiceModel()
                                 {
                                    Id = c.Id.ToString(),
                                    Manufacturer = c.Manufacturer,
                                    Brand = c.Brand,
                                    VIN = c.VIN,
                                    BodyType = c.BodyType,
                                    Fuel = c.Fuel,
                                    HorsePower = c.HorsePower,
                                    Year = c.Year,
                                    FirstRegistrationYear = c.FirstRegistrationYear,
                                    Price = c.Price,
                                    TraveledDistance = c.TraveledDistance,
                                    ImageUrl = c.ImageUrl,
                                    SellerId = userId,
                                    GearType = c.GearType,
                                    Color = c.Color,
                                    NumberOfDoors = c.NumberOfDoors,
                                    NumberOfSeats = c.NumberOfSeats,
                                    Equipments = c.Equipments,
                                    Description = c.Description,
                                    ServiceHistory = c.ServiceHistory
                                })
                                .ToListAsync();
        }

        public async Task CreateCarAsync(string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower,
                              int year, int firstRegistrationYear, decimal price, int traveledDistance, string sellerId, string imageUrl,
                              string gearType, string color, string numberOfDoors, string numberOfSeats, IEnumerable<string> equipments,
                              string description, bool serviceHistory)
        {

            var seller = await GetSeller(sellerId);

            var carToAdd = new Car()
            {
                Id = Guid.NewGuid(),
                Manufacturer = manufacturer,
                Brand = brand,
                BodyType = bodyType,
                VIN = vin,
                Fuel = fuel,
                HorsePower = horsePower,
                Year = DateTime.Parse($"01/01/{year}"),
                FirstRegistrationYear = DateTime.Parse($"01/01/{firstRegistrationYear}"),
                Price = price,
                TraveledDistance = traveledDistance,
                SellerId = seller.Id,
                Seller = seller,
                ImageUrl = imageUrl,
                GearType = gearType,
                Color = color,
                NumberOfDoors = numberOfDoors,
                NumberOfSeats = numberOfSeats,
                Equipments = equipments,
                Description = description,
                ServiceHistory = serviceHistory
            };

            await context.AddAsync(carToAdd);
            await context.SaveChangesAsync();
        }

        public Task<CarServiceModel> CarDetailsByIdAsync(string carId)
        {
            throw new NotImplementedException();
        }

        public Task EditCarAsync(string id, string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower,
                                 DateTime year, DateTime firstRegistrationYear, decimal price, int traveledDistance, string sellerId, string imageUrl,
                                 string gearType, string color, string numberOfDoors, string numberOfSeats, IEnumerable<string> equipments,
                                 string description, bool serviceHistory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCar(string carId)
        {
            throw new NotImplementedException();
        }
    }
}
