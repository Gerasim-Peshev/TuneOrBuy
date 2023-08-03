using Microsoft.EntityFrameworkCore;
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
                Equipments = String.Join(", ", car.Equipments),
                Description = car.Description,
                ServiceHistory = car.ServiceHistory
            };
        }

        public async Task<List<CarServiceModel>> AllCarsAsync()
        {
            var cars = await context.Cars
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

        

        public async Task ToFavouriteCars(string carId, string userId)
        {
            var buyer = await context.Users.FirstAsync(b => b.Id.ToString().ToLower() == userId.ToLower());

            var contains = await ContainsCar(carId, userId);

            if (!contains.Item1)
            {
                buyer.FavouriteCars.Add(contains.Item3);
            }
            else if(contains.Item1)
            {
                buyer.FavouriteCars.Remove(contains.Item3);
            }

            await context.SaveChangesAsync();
        }

        public async Task<Tuple<bool, Buyer, Car>> ContainsCar(string carId, string userId)
        {
            var car = await context.Cars
                                   .FirstAsync(c => c.Id.ToString().ToLower() == carId.ToLower());

            var buyer = await context.Users
                                     .FirstAsync(b => b.Id.ToString().ToLower() == userId.ToLower());

            return new Tuple<bool, Buyer, Car>(
                buyer.FavouriteCars.Any(c => c.Id.ToString().ToLower() == carId.ToLower()), buyer, car);
        }

        public async Task<List<CarServiceModel>> MyFavoriteCarsAsync(string userId)
        {
            var cars = new List<Car>();

            foreach (var car in await context.Cars.ToListAsync())
            {
                var contains = await ContainsCar(car.Id.ToString(), userId);
                if (contains.Item1)
                {
                    cars.Add(car);
                }
            }

            var carsToReturn = cars
                            .Select(fc => new CarServiceModel()
                             {
                                 Id = fc.Id.ToString().ToLower(),
                                 Manufacturer = fc.Manufacturer,
                                 Brand = fc.Brand,
                                 VIN = fc.VIN,
                                 BodyType = fc.BodyType,
                                 Fuel = fc.Fuel,
                                 HorsePower = fc.HorsePower,
                                 Year = fc.Year,
                                 FirstRegistrationYear = fc.FirstRegistrationYear,
                                 Price = fc.Price,
                                 TraveledDistance = fc.TraveledDistance,
                                 ImageUrl = fc.ImageUrl,
                                 SellerId = fc.SellerId.ToString(),
                                 GearType = fc.GearType,
                                 Color = fc.Color,
                                 NumberOfDoors = fc.NumberOfDoors,
                                 NumberOfSeats = fc.NumberOfSeats,
                                 Equipments = fc.Equipments,
                                 Description = fc.Description,
                                 ServiceHistory = fc.ServiceHistory
                             })
                            .ToList();

            if (carsToReturn == null)
            {
                return new List<CarServiceModel>();
            }

            return carsToReturn;
        }

        public async Task CreateCarAsync(string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower,
                                         int year, int firstRegistrationYear, decimal price, int traveledDistance, string sellerId, string imageUrl,
                                         string gearType, string color, string numberOfDoors, string numberOfSeats, List<string> equipments,
                                         string description, bool serviceHistory)
        {

            var seller = await GetSellerByBuyerIdAsync(sellerId);

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
                Equipments = String.Join(", ", equipments),
                Description = description,
                ServiceHistory = serviceHistory
            };

            seller.CarsForSell.Add(carToAdd);

            await context.AddAsync(carToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<CarDetailsServiceModel> CarDetailsByIdAsync(string carId)
        {
            var car = await context.Cars.FirstAsync(c => c.Id.ToString().ToLower() == carId.ToLower());

            var seller = await GetSellerBySellerIdAsync(car.SellerId.ToString());
            seller.Town = await GetTownByIdAsync(seller.TownId);
            seller.Buyer = await GetBuyerByIdAsync(seller.BuyerId.ToString());

            var carToReturn = new CarDetailsServiceModel()
            {
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
                Seller = seller,
                GearType = car.GearType,
                Color = car.Color,
                NumberOfDoors = car.NumberOfDoors,
                NumberOfSeats = car.NumberOfSeats,
                Equipments = String.Join(", ", car.Equipments),
                Description = car.Description,
                ServiceHistory = car.ServiceHistory
            };

            return carToReturn;
        }

        public async Task EditCarAsync(string id, string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower,
                                       int year, int firstRegistrationYear, decimal price, int traveledDistance, string sellerId, string imageUrl,
                                       string gearType, string color, string numberOfDoors, string numberOfSeats, string equipments,
                                       string description, bool serviceHistory)
        {
            var car = await context.Cars.FirstAsync(c => c.Id.ToString().ToLower() == id.ToLower());

            car.Manufacturer = manufacturer;
            car.Brand = brand;
            car.BodyType = bodyType;
            car.VIN = vin;
            car.Fuel = fuel;
            car.HorsePower = horsePower;
            car.Year = DateTime.Parse($"01/01/{year}");
            car.FirstRegistrationYear = DateTime.Parse($"01/01/{firstRegistrationYear}");
            car.Price = price;
            car.TraveledDistance = traveledDistance;
            car.SellerId = Guid.Parse((ReadOnlySpan<char>) sellerId);
            car.ImageUrl = imageUrl;
            car.GearType = gearType;
            car.Color = color;
            car.NumberOfDoors = numberOfDoors;
            car.NumberOfSeats = numberOfSeats;
            car.Equipments = equipments;
            car.Description = description;
            car.ServiceHistory = serviceHistory;

            await context.SaveChangesAsync();
        }

        public async Task DeleteCar(string carId)
        {
            var car = await context.Cars.FirstAsync(c => c.Id.ToString().ToLower() == carId.ToLower());

            context.Remove(car);
            await context.SaveChangesAsync();
        }
    }
}
