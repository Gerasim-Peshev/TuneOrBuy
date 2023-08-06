using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Models.Seller;

namespace TuneOrBuy.Web.Controllers
{
    [Authorize]
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;
        private readonly ICarServiceService carServiceService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public SellerController(ISellerService sellers, ICarServiceService carServiceService)
        {
            this.sellerService = sellers;
            this.carServiceService = carServiceService;
        }

        public async Task<bool> UserIsSeller()
        {
           return await sellerService.UserIsSeller(UserId());
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await UserIsSeller() == true || await carServiceService.GetOwnerByBuyerIdAsync(UserId()) != null)
            {
                return RedirectToAction("All", "Car");
            }

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
            if (await UserIsSeller() == true || await carServiceService.GetOwnerByBuyerIdAsync(UserId()) != null)
            {
                return RedirectToAction("All", "Car");
            }

            var userId = UserId();

            if (await sellerService.ExistsById(userId))
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
                userId, 
                sellerToBecome.PhoneNumber, 
                sellerToBecome.TownId,
                sellerToBecome.ImageUrl);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CarsForSell()
        {
            if (await UserIsSeller() == false || await carServiceService.GetOwnerByBuyerIdAsync(UserId()) != null)
            {
                return RedirectToAction("All", "Car");
            }

            var userId = UserId();

            var carsForSell = await sellerService.GetAllCarsForSell(userId);

            return View(carsForSell);
        }

        public async Task<IActionResult> PartsForSell()
        {
            if (await UserIsSeller() == false || await carServiceService.GetOwnerByBuyerIdAsync(UserId()) != null)
            {
                return RedirectToAction("All", "Part");
            }

            var userId = UserId();

            var partsForSell = await sellerService.GetAllPartsForSell(userId);

            return View(partsForSell);
        }
    }
}
