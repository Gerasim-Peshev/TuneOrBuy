using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneOrBuy.Data;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Sellers;
using TuneOrBuy.Tests.Mocks;
using TuneOrBuy.Web.Data;
using static TuneOrBuy.Data.DataConstants;
using Buyer = TuneOrBuy.Data.Models.Buyer;
using Seller = TuneOrBuy.Data.Models.Seller;
using Town = TuneOrBuy.Data.Models.Town;

namespace TuneOrBuy.Tests.Services
{
    public class SellersTests
    {
        public const string BuyerId1Guid = "03eef371-0fc1-4067-cfbd-08db8c57ac63";
        public const string BuyerId2Guid = "1485e924-eb30-44e5-8a7e-573dc37faf0a";
        public const string CarServiceOwnerIdGuid = "ab2d631c-7895-414c-5519-08db8c5eca5f";
        public const string PhoneNumber = "0999999999";
        public const int TownId = 15;
        public const string TownName = "Велико Търново";

        [Test]
        public void ShouldReturnUserIsSellerTrue()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();

            var sellerService = new TuneOrBuy.Services.Sellers.SellerService(data);

            //Act
            var check = Task.Run(async () =>
            {
                return await sellerService.UserIsSeller(BuyerId1Guid);
            })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldGetAllTowns()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();

            var sellerService = new SellerService(data);

            //Act
            var towns = Task.Run(async () =>
                             {
                                 return await sellerService.GetAllTowns();
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(1, towns.Count());
        }

        [Test]
        public void ShouldGetBuyerCorrect()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();

            var sellerService = new TuneOrBuy.Services.Sellers.SellerService(data);

            //Act
            var buyer = Task.Run(async () =>
                             {
                                 return await sellerService.GetBuyerAsync(BuyerId1Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(buyerToReturn.Id, buyer.Id);
            Assert.AreEqual(buyerToReturn.FirstName, buyer.FirstName);
            Assert.AreEqual(buyerToReturn.LastName, buyer.LastName);
        }

        [Test]
        public void ShouldGetTownByIdCorrect()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var town = Task.Run(async () =>
                             {
                                 return await sellerService.GetTownByIdAsync(TownId);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(townToReturn.Id, town.Id);
            Assert.AreEqual(townToReturn.Name, town.Name);
        }

        [Test]
        public void ShouldGetSellerCorrect()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var seller= Task.Run(async () =>
                          {
                              return await sellerService.GetSeller(BuyerId1Guid);
                          })
                         .GetAwaiter()
                         .GetResult();

            //Assert
            Assert.AreEqual(sellerToReturn.Id, seller.Id);
            Assert.AreEqual(sellerToReturn.BuyerId, seller.BuyerId);
            Assert.AreEqual(sellerToReturn.PhoneNumber, seller.PhoneNumber);
        }

        [Test]
        public void ShouldReturnExistByIdTrue()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var check = Task.Run(async () =>
                              {
                                  return await sellerService.ExistsById(BuyerId1Guid);
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
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await sellerService.ExistsById(BuyerId2Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void ShouldReturnExistByPhoneNumbertrue()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await sellerService.ExistsByPhoneNumber(PhoneNumber);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldReturnExistByPhoneNumberfalse()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 return await sellerService.ExistsByPhoneNumber("0777777777");
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(false, check);
        }

        [Test]
        public void ShouldCreateSeller()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var check = Task.Run(async () =>
                             {
                                 await sellerService.CreateSeller(BuyerId2Guid, "0000000000", TownId, "fsgrgd");
                                 return await sellerService.ExistsById(BuyerId2Guid);
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(true, check);
        }

        [Test]
        public void ShouldGetAllCarsForSell()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var carsForSell = Task.Run(async () =>
                                   {
                                       return await sellerService.GetAllCarsForSell(BuyerId1Guid);
                                   })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(0, carsForSell.Count);
        }

        [Test]
        public void ShouldGetAllPartsForSell()
        {
            //Arange
            var data = GetData();
            var buyerToReturn = GetBuyer();
            var sellerToReturn = GetSeller();
            var townToReturn = GetTown();

            var sellerService = new SellerService(data);

            //Act
            var partsForSell = Task.Run(async () =>
                                   {
                                       return await sellerService.GetAllPartsForSell(BuyerId1Guid);
                                   })
                                  .GetAwaiter()
                                  .GetResult();

            //Assert
            Assert.AreEqual(0, partsForSell.Count);
        }

        private TuneOrBuyDbContext GetData()
        {
            var data = DatabaseMock.Context;

            Task.Run(async () =>
                 {
                     await data.Users.AddAsync(GetBuyer());
                     await data.Sellers.AddAsync(GetSeller());
                     await data.Towns.AddAsync(GetTown());

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
                Id = Guid.Parse((ReadOnlySpan<char>)BuyerId1Guid),
                FirstName = "test",
                LastName = "test"
            };
        }

        private Seller GetSeller()
        {
            return new Seller()
            {
                Id = Guid.Parse((ReadOnlySpan<char>)CarServiceOwnerIdGuid),
                BuyerId = Guid.Parse((ReadOnlySpan<char>)BuyerId1Guid),
                PhoneNumber = PhoneNumber,
                ImageUrl =
                    "https://www.findlaw.com/consumer/lemon-law/how-to-sue-a-car-dealer-for-misrepresentation-/_jcr_content/pg/articleHeading/imageInLine.coreimg.jpeg/1636986965527.jpeg",
                TownId = TownId
            };
        }

        private Town GetTown()
        {
            return new Town()
            {
                Id = TownId,
                Name = TownName
            };
        }
    }
}
