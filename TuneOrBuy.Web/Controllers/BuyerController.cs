using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Controllers
{
    public class BuyerController : Controller
    {
        public IActionResult MyCars()
        {
            return View();
        }

        public IActionResult MyParts()
        {
            return View();
        }
    }
}
