using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Models.CarServiceOwner;

namespace TuneOrBuy.Web.Controllers
{
    [Authorize]
    public class CarServiceOwnerController : Controller
    {
        private readonly ICarServiceOwnerService carServiceOwnerService;
        private readonly ISellerService sellerService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public CarServiceOwnerController(ICarServiceOwnerService carServiceOwners, ISellerService sellerService)
        {
            this.carServiceOwnerService = carServiceOwners;
            this.sellerService = sellerService;
        }

        public async Task<bool> UserIsCarServiceOwner()
        {
            return await carServiceOwnerService.UserIsCarServiceOwner(UserId());
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await UserIsCarServiceOwner() == true || await sellerService.GetSeller(UserId()) != null)
            {
                return RedirectToAction("All", "CarService");
            }

            return View(new BecomeCarServiceOwnerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeCarServiceOwnerViewModel carServiceOwnerToBecome)
        {
            if (await UserIsCarServiceOwner() == true || await sellerService.GetSeller(UserId()) != null)
            {
                return RedirectToAction("All", "CarService");
            }

            var userId = UserId();

            if (await carServiceOwnerService.ExistsById(userId))
            {
                return BadRequest();
            }

            if (await carServiceOwnerService.ExistsByPhoneNumber(carServiceOwnerToBecome.PhoneNumber))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(carServiceOwnerToBecome);
            }

            await carServiceOwnerService.CreateCarServiceOwner(userId, carServiceOwnerToBecome.PhoneNumber);

            return RedirectToAction("Index", "Home");
        }
    }
}
