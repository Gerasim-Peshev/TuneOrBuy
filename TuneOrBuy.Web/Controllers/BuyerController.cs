using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Controllers
{
    public class BuyerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
