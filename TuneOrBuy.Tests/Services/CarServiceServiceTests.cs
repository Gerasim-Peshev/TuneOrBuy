using TuneOrBuy.Data.Models;
using TuneOrBuy.Tests.Mocks;
using TuneOrBuy.Web.Data;

namespace TuneOrBuy.Tests.Services
{
    public class CarServiceServiceTests
    {
        private const string CarServiceName = "U pernik";
        private const string CarServicePhoneNumber = "0999999999";
        private const string CarServiceAddress = "Leshta 9";
        private readonly string CarServiceIdGuid = "cab29622-c09c-4b30-888f-f76c2ba42359";
        private readonly string CarServiceOwnerIdGuid = "0bfb1b8d-5a6c-4c11-aba3-08db8b7ad603";
        private readonly string BuyerIdGuid = "cf55f3ad-bff1-4d12-2352-08db8b5e9b25";
        private readonly int TownId = 15;

        [Test]
        public void ShouldReturnOwnerByBuyerIdCorrect()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carServiceOwner = Task.Run(async () =>
            {
                return await carServiceService.GetOwnerByBuyerIdAsync(BuyerIdGuid);
            })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(carServiceOwnerToReturn.Id, carServiceOwner.Id);
            Assert.AreEqual(carServiceOwnerToReturn.BuyerId, carServiceOwner.BuyerId);
            Assert.AreEqual(carServiceOwnerToReturn.PhoneNumber, carServiceOwner.PhoneNumber);
        }

        [Test]
        public void ShouldReturnOwnerByOwnerIdCorrect()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var buyer = Task.Run(async () =>
                                       {
                                           return await carServiceService.GetOwnerByOwnerIdAsync(CarServiceOwnerIdGuid);
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(carServiceOwnerToReturn.Id, buyer.Id);
            Assert.AreEqual(carServiceOwnerToReturn.BuyerId, buyer.BuyerId);
            Assert.AreEqual(carServiceOwnerToReturn.PhoneNumber, buyer.PhoneNumber);
        }

        [Test]
        public void ShouldReturnBuyerByBuyerIdCorrect()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var buyer = Task.Run(async () =>
                                       {
                                           return await carServiceService.GetBuyerByIdAsync(BuyerIdGuid);
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(buyerToReturn.Id, buyer.Id);
            Assert.AreEqual(buyerToReturn.FirstName, buyer.FirstName);
            Assert.AreEqual(buyerToReturn.LastName, buyer.LastName);
        }

        [Test]
        public void ShouldReturnTownByIdCorrect()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var town = Task.Run(async () =>
                                       {
                                           return await carServiceService.GetTownByIdAsync(TownId);
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(townToReturn.Id, town.Id);
            Assert.AreEqual(townToReturn.Name, town.Name);
        }

        [Test]
        public void ShouldReturnAllTowns()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var towns = Task.Run(async () =>
                                       {
                                           return await carServiceService.GetAllTowns();
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(1, towns.Count());
        }

        [Test]
        public void GetCarServiceCorrect()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carService = Task.Run(async () =>
                                       {
                                           return await carServiceService.GetCarServiceAsync(CarServiceIdGuid);
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(carServiceToReturn.Id.ToString().ToLower(), carService.Id.ToLower());
            Assert.AreEqual(carServiceToReturn.Name, carService.Name);
            Assert.AreEqual(carServiceToReturn.TownId, carService.TownId);
        }

        [Test]
        public void ShouldGetAllCarServices()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carServices = Task.Run(async () =>
                                       {
                                           return await carServiceService.AllCarServicesAsync();
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(1, carServices.Count);
        }

        [Test]
        public void SouldReturnCarServicesDetails()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carService = Task.Run(async () =>
                                       {
                                           return await carServiceService.CarServiceDetailsByIdAsync(CarServiceIdGuid);
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(carService.Name, carService.Name);
            Assert.AreEqual(carService.Address, carService.Address);
        }

        [Test]
        public void ShouldCreateCarService()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carServices = Task.Run(async () =>
                                       {
                                           await carServiceService.CreateCarServiceAsync(
                                               "Vtori", "Tam", BuyerIdGuid, TownId, "0888888888", "fsgr", 5,
                                               23, "daefes", "");

                                           return await carServiceService.AllCarServicesAsync();
                                       })
                                      .GetAwaiter()
                                      .GetResult();

            //Assert
            Assert.AreEqual(2, carServices.Count);
        }

        [Test]
        public void ShouldEditCarService()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carService = Task.Run(async () =>
                                   {
                                       await carServiceService.EditCarServiceAsync(CarServiceIdGuid,
                                           "Vtori", "Tam", CarServiceOwnerIdGuid, TownId, "0888888888", "fsgr", 5,
                                           23, "daefes", "");

                                       return await carServiceService.GetCarServiceAsync(CarServiceIdGuid);
                                   })
                                  .GetAwaiter()
                                  .GetResult();

            //Assert
            Assert.AreNotEqual(carServiceToReturn.Name, carService.Name);
            Assert.AreNotEqual(carServiceToReturn.Address, carService.Address);
            Assert.AreNotEqual(carServiceToReturn.PhoneNumber, carService.PhoneNumber);
        }

        [Test]
        public void ShouldReturnMyFavoriteCarServices()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carServices = Task.Run(async () =>
                                   {
                                       return await carServiceService.MyFavoriteCarServicesAsync(BuyerIdGuid);
                                   })
                                  .GetAwaiter()
                                  .GetResult();

            //Assert
            Assert.AreEqual(1, carServices.Count);
        }

        [Test]
        public void ShouldDeleteCarService()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var carServices = Task.Run(async () =>
                                  {
                                      await carServiceService.DeleteCarServiceAsync(CarServiceIdGuid);

                                      return await carServiceService.AllCarServicesAsync();
                                  })
                                 .GetAwaiter()
                                 .GetResult();

            //Assert
            Assert.AreEqual(0, carServices.Count);
        }

        [Test]
        public void ShouldContainsReturnTrue()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 await carServiceService.ToFavouriteCarServicesAsync(CarServiceIdGuid, BuyerIdGuid);
                                 return carServiceService.ContainsCarServiceAsync(CarServiceIdGuid, BuyerIdGuid).Result
                                                         .Item1;
                             })
                                  .GetAwaiter()
                                  .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldNotContainReturnFalse()
        {
            //Arrange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();
            var carServiceToReturn = GetCarService();
            var townToReturn = GetTown();

            var carServiceService = new TuneOrBuy.Services.CarServices.CarServiceService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return carServiceService.ContainsCarServiceAsync(CarServiceIdGuid, BuyerIdGuid).Result
                                                         .Item1;
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(false, check);
        }

        private TuneOrBuyDbContext GetData()
        {
            var data = DatabaseMock.Context;

            Task.Run(async () =>
                 {
                     await data.CarServices.AddAsync(GetCarService());
                     await data.CarServiceOwners.AddAsync(GetCarServiceOwner());
                     await data.Users.AddAsync(GetBuyer());
                     await data.Towns.AddAsync(GetTown());

                     await data.SaveChangesAsync();
                 })
                .GetAwaiter()
                .GetResult();

            return data;
        }

        private CarService GetCarService()
        {
            return new CarService()
            {
                Id = Guid.Parse((ReadOnlySpan<char>)CarServiceIdGuid),
                Name = CarServiceName,
                PhoneNumber = CarServicePhoneNumber,
                Address = CarServiceAddress,
                CarServiceOwnerId = Guid.Parse(CarServiceOwnerIdGuid),
                OpenHour = new DateTime(2023, 8, 8, 8, 0, 0),
                CloseHour = new DateTime(2023, 8, 8, 20, 0, 0),
                Description = "uikbnl",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8d/BMW_G20_IMG_0167.jpg",
                TownId = TownId,
                Services = "Remont"
            };
        }

        private CarServiceOwner GetCarServiceOwner()
        {
            return new CarServiceOwner()
            {
                Id = Guid.Parse((ReadOnlySpan<char>)CarServiceOwnerIdGuid),
                BuyerId = Guid.Parse((ReadOnlySpan<char>)BuyerIdGuid),
                PhoneNumber = "0888888888"
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
