using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TuneOrBuy.Services.CarServiceOwners;
using TuneOrBuy.Services.Contracts;

namespace TuneOrBuy.Web.Controllers
{
    public class CarServiceOwnerController : Controller
    {
        private readonly ICarServiceOwner carServiceOwnerService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public CarServiceOwnerController(CarServiceOwnerService service)
        {
            this.carServiceOwnerService = service;
        }

        public async Task<bool> UserIsCarServiceOwner()
        {
            return await carServiceOwnerService.UserIsCarServiceOwner(Guid.Parse(UserId()));
        }

        public IActionResult Become()
        {
            return View();
        }
    }
}
