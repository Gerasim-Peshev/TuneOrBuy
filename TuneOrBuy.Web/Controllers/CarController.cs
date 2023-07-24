using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Controllers
{
    public class CarController : Controller
    {
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
