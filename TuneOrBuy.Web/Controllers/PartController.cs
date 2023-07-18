using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Controllers
{
    public class PartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
