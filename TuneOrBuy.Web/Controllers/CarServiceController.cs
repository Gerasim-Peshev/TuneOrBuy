using Microsoft.AspNetCore.Mvc;
using TuneOrBuy.Web.Models.CarService;

namespace TuneOrBuy.Web.Controllers
{
    public class CarServiceController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(AddCarServiceViewModel carServiceToAdd)
        {
            return RedirectToAction("All", "CarService");
        }
    }
}
