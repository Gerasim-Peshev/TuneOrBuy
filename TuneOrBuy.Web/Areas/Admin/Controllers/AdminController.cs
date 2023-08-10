using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TuneOrBuy.Web.Areas.Admin.Controllers
{
    [Area(AdminConstants.AdminAreaName)]
    [Authorize(Roles = AdminConstants.AdministratorRoleName)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
