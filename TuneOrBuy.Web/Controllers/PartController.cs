using Microsoft.AspNetCore.Mvc;
using TuneOrBuy.Web.Models.Car;
using TuneOrBuy.Web.Models.Part;

namespace TuneOrBuy.Web.Controllers
{
    public class PartController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddPart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(AddPartViewModel partToAdd)
        {
            return RedirectToAction("All", "Car");
        }
    }
}
