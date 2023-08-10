using Microsoft.Extensions.Hosting;
using TuneOrBuy.Data.Migrations;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Tests.Mocks;
using TuneOrBuy.Web.Data;
using CarService = TuneOrBuy.Services.Cars.CarService;

namespace TuneOrBuy.Tests.Services
{
    public class CarServiceTests
    {
        private readonly string CarIdGuid = "cab29622-c09c-4b30-888f-f76c2ba42359";
        private readonly string SellerIdGuid = "0bfb1b8d-5a6c-4c11-aba3-08db8b7ad603";
        private readonly string BuyerIdGuid = "cf55f3ad-bff1-4d12-2352-08db8b5e9b25";
        private readonly int TownId = 15;

        [Test]
        public void ShouldReturnAllCars()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            var cars = Task.Run(async () =>
                            {
                                var cars = await carService.AllCarsAsync();
                                return cars;
                            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(1, cars.Count);
        }

        [Test]
        public void ShouldReturnCarDetailsServiceModel()
        {
            //Arange
            var data = this.GetData();
            var car = this.GetCar();

            var carService = new CarService(data);

            //Act
            var carDetails = Task.Run(async () =>
            {
                return await carService.CarDetailsByIdAsync(CarIdGuid);
            })
                                 .GetAwaiter()
                                 .GetResult();

            //Assert
            Assert.AreEqual(typeof(CarDetailsServiceModel), carDetails.GetType());
        }

        [Test]
        public void ShouldAddCar()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            Task.Run(async () =>
            {
                await carService.CreateCarAsync("Honda", "Civic", "Hatchback", "", "LPG", 90, 2003, 2003, 4200, 250044,
                                                BuyerIdGuid, "image", "Manual", "Silver", "2/3", "5",
                                                new List<string>() {"ABS"}, "", false);
            })
                .GetAwaiter()
                .GetResult();

            var cars = Task.Run(async () =>
                            {
                                var cars = await carService.AllCarsAsync();
                                return cars;
                            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(2, cars.Count);
        }

        [Test]
        public void ShouldEditCar()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            Task.Run(async () =>
                 {
                     await carService.EditCarAsync(CarIdGuid, "Honda", "Civic", "Hatchback", "", "LPG", 90, 2003, 2003, 4200, 250000,
                                                     BuyerIdGuid, "image", "Manual", "Silver", "2/3", "5",
                                                     "ABS", "", false);
                 })
                .GetAwaiter()
                .GetResult();

            var cars = Task.Run(async () =>
                            {
                                var cars = await carService.AllCarsAsync();
                                return cars;
                            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(250000, cars[0].TraveledDistance);
        }

        [Test]
        public void ShouldDeleteCar()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            Task.Run(async () =>
                 {
                     await carService.DeleteCarAsync(CarIdGuid);
                 })
                .GetAwaiter()
                .GetResult();

            var cars = Task.Run(async () =>
                            {
                                var cars = await carService.AllCarsAsync();
                                return cars;
                            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(0, cars.Count);
        }

        [Test]
        public void ShouldReturnFavoriteCarFalse()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            var check = Task.Run(async () =>
                 {
                     var check = await carService.ContainsCarAsync(CarIdGuid, BuyerIdGuid);

                     return check.Item1;
                 })
                .GetAwaiter()
                .GetResult();

            //Assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void ShouldReturnFavoriteCarTrue()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 await carService.ToFavouriteCarsAsync(CarIdGuid, BuyerIdGuid);

                                 var check = await carService.ContainsCarAsync(CarIdGuid, BuyerIdGuid);

                                 return check.Item1;
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldReturnCorrectCar()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);
            var carToReturn = GetCar();

            //Act
            var car = Task.Run(async () =>
                             {
                                 return await carService.GetCarAsync(CarIdGuid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(carToReturn.Id.ToString().ToLower(), car.Id.ToLower());
            Assert.AreEqual(carToReturn.Manufacturer, car.Manufacturer);
            Assert.AreEqual(carToReturn.Brand, car.Brand);
            Assert.AreEqual(carToReturn.SellerId.ToString().ToLower(), car.SellerId.ToLower());
        }

        [Test]
        public void ShouldReturnCorrectTown()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            var town = Task.Run(async () =>
                             {
                                 return await carService.GetTownByIdAsync(TownId);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual("Велико Търново", town.Name);
        }

        [Test]
        public void GetSellerWithBuyerId()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            var seller = Task.Run(async () =>
                            {
                                return await carService.GetSellerByBuyerIdAsync(BuyerIdGuid);
                            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(TownId, seller.TownId);
        }

        [Test]
        public void GetSellerWithSellerId()
        {
            //Arange
            var data = this.GetData();

            var carService = new CarService(data);

            //Act
            var seller = Task.Run(async () =>
                              {
                                  return await carService.GetSellerBySellerIdAsync(SellerIdGuid);
                              })
                             .GetAwaiter()
                             .GetResult();

            //Assert
            Assert.AreEqual(TownId, seller.TownId);
        }

        private TuneOrBuyDbContext GetData()
        {
            var data = DatabaseMock.Context;

            Task.Run(async () =>
                 {
                     await data.Cars.AddAsync(GetCar());
                     await data.Sellers.AddAsync(GetSeller());
                     await data.Users.AddAsync(GetBuyer());
                     await data.Towns.AddAsync(GetTown());

                     await data.SaveChangesAsync();
                 })
                .GetAwaiter()
                .GetResult();

            return data;
        }

        private Car GetCar()
        {
            return new Car()
            {
                Manufacturer = "BMW",
                Brand = "320",
                BodyType = "Coupe",
                Color = "Blue",
                Description = "uikbnl",
                Equipments = "ABS",
                FirstRegistrationYear = DateTime.Parse("01/01/2004"),
                Year = DateTime.Parse("01/01/2003"),
                Fuel = "LPG",
                GearType = "Manual",
                HorsePower = 170,
                NumberOfDoors = "2/3",
                NumberOfSeats = "5",
                Price = 4500,
                SellerId = Guid.Parse((ReadOnlySpan<char>) SellerIdGuid),
                ServiceHistory = true,
                TraveledDistance = 150000,
                VIN = "ubhoihnln",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8d/BMW_G20_IMG_0167.jpg",
                Id = Guid.Parse((ReadOnlySpan<char>) CarIdGuid)
            };
        }

        private Seller GetSeller()
        {
            return new Seller()
            {
                Id = Guid.Parse((ReadOnlySpan<char>) SellerIdGuid),
                BuyerId = Guid.Parse((ReadOnlySpan<char>) BuyerIdGuid),
                PhoneNumber = "0888888888",
                ImageUrl =
                    "https://www.findlaw.com/consumer/lemon-law/how-to-sue-a-car-dealer-for-misrepresentation-/_jcr_content/pg/articleHeading/imageInLine.coreimg.jpeg/1636986965527.jpeg",
                TownId = TownId
            };
        }

        private Buyer GetBuyer()
        {
            return new Buyer()
            {
                Id = Guid.Parse((ReadOnlySpan<char>)BuyerIdGuid),
                FirstName = "test",
                LastName = "Test"
            };
        }

        private Town GetTown()
        {
            return new Town()
            {
                Id = TownId,
                Name = "Велико Търново"
            };
        }
    }
}
