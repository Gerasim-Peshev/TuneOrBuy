using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Controllers
{
    public class CarServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
