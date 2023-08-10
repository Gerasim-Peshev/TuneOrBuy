using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Parts;
using TuneOrBuy.Services.Parts.Models;
using TuneOrBuy.Tests.Mocks;
using TuneOrBuy.Web.Data;

namespace TuneOrBuy.Tests.Services
{
    public class PartServiceTests
    {
        private readonly string PartIdGuid = "cab29622-c09c-4b30-888f-f76c2ba42359";
        private readonly string SellerIdGuid = "0bfb1b8d-5a6c-4c11-aba3-08db8b7ad603";
        private readonly string BuyerIdGuid = "cf55f3ad-bff1-4d12-2352-08db8b5e9b25";
        private readonly int TownId = 15;

        [Test]
        public void ShouldReturnAllparts()
        {
            //Arange
            var data = this.GetData();

            var partService = new PartService(data);

            //Act
            var parts = Task.Run(async () =>
            {
                var parts = await partService.AllPartsAsync();
                return parts;
            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(1, parts.Count);
        }

        [Test]
        public void ShouldReturnCarDetailsServiceModel()
        {
            //Arange
            var data = this.GetData();
            var part = this.GetPart();

            var partService = new PartService(data);

            //Act
            var partDetails = Task.Run(async () =>
            {
                return await partService.PartDetailsByIdAsync(PartIdGuid);
            })
                                 .GetAwaiter()
                                 .GetResult();

            //Assert
            Assert.AreEqual(typeof(PartDetailsServiceModel), partDetails.GetType());
        }

        [Test]
        public void ShouldAddCar()
        {
            //Arange
            var data = this.GetData();

            var partService = new PartService(data);

            //Act
            var parts = Task.Run(async () =>
                             {
                                 await partService.CreatePartAsync("Dzhanti", "Honda", "Civic", 516, 4500, BuyerIdGuid, "dnesfn", "");
                                 var parts = await partService.AllPartsAsync();
                                 return parts;
                             })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(2, parts.Count);
        }

        [Test]
        public void ShouldEditCar()
        {
            //Arange
            var data = this.GetData();

            var partService = new PartService(data);

            //Act
            Task.Run(async () =>
            {
                await partService.EditPartAsync(PartIdGuid, "Dzhanti", "Honda", "Civic", 2005, 4500, SellerIdGuid, "dnesfn", "");
            })
                .GetAwaiter()
                .GetResult();

            var parts = Task.Run(async () =>
            {
                var parts = await partService.AllPartsAsync();
                return parts;
            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(2005, parts[0].Year.Year);
        }

        [Test]
        public void ShouldDeleteCar()
        {
            //Arange
            var data = this.GetData();

            var partService = new PartService(data);

            //Act
            Task.Run(async () =>
            {
                await partService.DeletePart(PartIdGuid);
            })
                .GetAwaiter()
                .GetResult();

            var parts = Task.Run(async () =>
            {
                var parts = await partService.AllPartsAsync();
                return parts;
            })
                           .GetAwaiter()
                           .GetResult();

            //Assert
            Assert.AreEqual(0, parts.Count);
        }

        [Test]
        public void ShouldReturnFavoriteCarFalse()
        {
            //Arange
            var data = this.GetData();

            var partService = new PartService(data);

            //Act
            var check = Task.Run(async () =>
            {
                var check = await partService.ContainsPart(PartIdGuid, BuyerIdGuid);

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

            var partService = new PartService(data);

            //Act
            var check = Task.Run(async () =>
            {
                await partService.ToFavouriteParts(PartIdGuid, BuyerIdGuid);

                var check = await partService.ContainsPart(PartIdGuid, BuyerIdGuid);

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
            var partToReturn = GetPart();

            var partService = new PartService(data);

            //Act
            var part = Task.Run(async () =>
            {
                return await partService.GetPart(PartIdGuid);
            })
                            .GetAwaiter()
                            .GetResult();

            //Assert
            Assert.AreEqual(partToReturn.Id.ToString().ToLower(), part.Id.ToLower());
            Assert.AreEqual(partToReturn.Manufacturer, part.Manufacturer);
            Assert.AreEqual(partToReturn.Brand, part.Brand);
            Assert.AreEqual(partToReturn.SellerId.ToString().ToLower(), part.SellerId.ToLower());
        }

        [Test]
        public void ShouldReturnCorrectTown()
        {
            //Arange
            var data = this.GetData();

            var partService = new PartService(data);

            //Act
            var town = Task.Run(async () =>
            {
                return await partService.GetTownByIdAsync(TownId);
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

            var partService = new PartService(data);

            //Act
            var seller = Task.Run(async () =>
            {
                return await partService.GetSellerByBuyerIdAsync(BuyerIdGuid);
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

            var partService = new PartService(data);

            //Act
            var seller = Task.Run(async () =>
            {
                return await partService.GetSellerBySellerIdAsync(SellerIdGuid);
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
                await data.Parts.AddAsync(GetPart());
                await data.Sellers.AddAsync(GetSeller());
                await data.Users.AddAsync(GetBuyer());
                await data.Towns.AddAsync(GetTown());

                await data.SaveChangesAsync();
            })
                .GetAwaiter()
                .GetResult();

            return data;
        }

        private Part GetPart()
        {
            return new Part()
            {
                Name = "Dzhanti",
                Manufacturer = "BBS",
                Brand = "Ultra Legera",
                Description = "uikbnl",
                Year = DateTime.Parse("01/01/2003"),
                Price = 4500,
                SellerId = Guid.Parse((ReadOnlySpan<char>)SellerIdGuid),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8d/BMW_G20_IMG_0167.jpg",
                Id = Guid.Parse((ReadOnlySpan<char>)PartIdGuid)
            };
        }

        private Seller GetSeller()
        {
            return new Seller()
            {
                Id = Guid.Parse((ReadOnlySpan<char>)SellerIdGuid),
                BuyerId = Guid.Parse((ReadOnlySpan<char>)BuyerIdGuid),
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
