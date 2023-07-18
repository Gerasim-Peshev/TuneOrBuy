using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Controllers
{
    public class ServiceOwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
