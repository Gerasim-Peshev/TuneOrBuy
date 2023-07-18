using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
