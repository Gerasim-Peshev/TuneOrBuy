using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TuneOrBuy.Services.CarServiceOwners;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Services.Sellers;
using TuneOrBuy.Web.Models.CarServiceOwner;

namespace TuneOrBuy.Web.Controllers
{
    public class CarServiceOwnerController : Controller
    {
        private readonly ICarServiceOwnerService carServiceOwnerService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public CarServiceOwnerController(ICarServiceOwnerService carServiceOwners)
        {
            this.carServiceOwnerService = carServiceOwners;
        }

        public async Task<bool> UserIsCarServiceOwner()
        {
            return await carServiceOwnerService.UserIsCarServiceOwner(Guid.Parse(UserId()));
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            return View(new BecomeCarServiceOwnerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeCarServiceOwnerViewModel carServiceOwnerToBecome)
        {
            var userId = UserId();

            if (await carServiceOwnerService.ExistsById(Guid.Parse((ReadOnlySpan<char>)userId)))
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

            await carServiceOwnerService.CreateSeller(
                Guid.Parse((ReadOnlySpan<char>)userId),
                carServiceOwnerToBecome.PhoneNumber);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> MyServices()
        {
            return View();
        }
    }
}
