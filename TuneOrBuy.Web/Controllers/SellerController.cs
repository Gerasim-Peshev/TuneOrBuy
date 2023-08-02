using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Models.Car;
using TuneOrBuy.Web.Models.Seller;

namespace TuneOrBuy.Web.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public SellerController(ISellerService sellers)
        {
            this.sellerService = sellers;
        }

        public async Task<bool> UserIsSeller()
        {
           return await sellerService.UserIsSeller(Guid.Parse(UserId()));
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var allTowns = await sellerService.GetAllTowns();

            var viewToReturn = new BecomeSellerViewModel
            {
                Towns = allTowns
            };

            return View(viewToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeSellerViewModel sellerToBecome)
        {
            var userId = UserId();

            if (await sellerService.ExistsById(Guid.Parse((ReadOnlySpan<char>) userId)))
            {
                return BadRequest();
            }

            if (await sellerService.ExistsByPhoneNumber(sellerToBecome.PhoneNumber))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                sellerToBecome.Towns = await sellerService.GetAllTowns();
                return View(sellerToBecome);
            }

            await sellerService.CreateSeller(
                Guid.Parse((ReadOnlySpan<char>)userId), 
                sellerToBecome.PhoneNumber, 
                sellerToBecome.TownId,
                sellerToBecome.ImageUrl);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CarsForSell()
        {
            var userId = UserId();

            var carsForSell = await sellerService.GetAllCarsForSell(userId);

            return View(carsForSell);
        }

        public async Task<IActionResult> PartsForSell()
        {
            return View();
        }
    }
}
