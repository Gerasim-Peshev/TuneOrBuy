using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Tests.Mocks;
using TuneOrBuy.Web.Data;

namespace TuneOrBuy.Tests.Services
{
    public class CarServiceOwnerServiceTests
    {
        public const string BuyerId1Guid = "03eef371-0fc1-4067-cfbd-08db8c57ac63";
        public const string BuyerId2Guid = "1485e924-eb30-44e5-8a7e-573dc37faf0a";
        public const string CarServiceOwnerIdGuid = "ab2d631c-7895-414c-5519-08db8c5eca5f";
        public const string PhoneNumber = "0999999999";

        [Test]
        public void ShouldReturnIsCarServiceOwnerTrue()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.UserIsCarServiceOwner(BuyerId1Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldReturnIsCarServiceOwnerFalse()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.UserIsCarServiceOwner(BuyerId2Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void ShouldReturnCorrectBuyer()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var buyer = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.GetBuyerAsync(BuyerId1Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(buyerToReturn.Id, buyer.Id);
            Assert.AreEqual(buyerToReturn.FirstName, buyer.FirstName);
            Assert.AreEqual(buyerToReturn.LastName, buyer.LastName);
        }

        [Test]
        public void ShouldReturnCorrectCarServiceOwner()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var carServiceOwner = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.GetCarServiceOwner(BuyerId1Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(carServiceOwnerToReturn.Id, carServiceOwner.Id);
            Assert.AreEqual(carServiceOwnerToReturn.BuyerId, carServiceOwner.BuyerId);
            Assert.AreEqual(carServiceOwnerToReturn.PhoneNumber, carServiceOwner.PhoneNumber);
        }

        [Test]
        public void ShouldReturnExistByIdTrue()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.ExistsById(BuyerId1Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldReturnExistByIdFalse()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.ExistsById(BuyerId2Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void ShouldReturnExistsByPhoneNumberTrue()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.ExistsByPhoneNumber(PhoneNumber);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldReturnExistsByPhoneNumberFalse()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await carServiceOwnerService.ExistsByPhoneNumber("0133713370");
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void ShouldCreateCarServiceOwner()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var carServiceOwnerToReturn = GetCarServiceOwner();

            var carServiceOwnerService = new TuneOrBuy.Services.CarServiceOwners.CarServiceOwnerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 await carServiceOwnerService.CreateCarServiceOwner(BuyerId2Guid, "0133713370");

                                 return await carServiceOwnerService.ExistsById(BuyerId2Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        private TuneOrBuyDbContext GetData()
        {
            var data = DatabaseMock.Context;

            Task.Run(async () =>
                 {
                     await data.Users.AddAsync(GetBuyer());
                     await data.CarServiceOwners.AddAsync(GetCarServiceOwner());

                     await data.SaveChangesAsync();
                 })
                .GetAwaiter()
                .GetResult();

            return data;
        }

        private Buyer GetBuyer()
        {
            return new Buyer()
            {
                Id = Guid.Parse((ReadOnlySpan<char>) BuyerId1Guid),
                FirstName = "test",
                LastName = "test"
            };
        }

        private CarServiceOwner GetCarServiceOwner()
        {
            return new CarServiceOwner()
            {
                Id = Guid.Parse((ReadOnlySpan<char>) CarServiceOwnerIdGuid),
                BuyerId = Guid.Parse((ReadOnlySpan<char>) BuyerId1Guid),
                PhoneNumber = PhoneNumber
            };
        }
    }
}
