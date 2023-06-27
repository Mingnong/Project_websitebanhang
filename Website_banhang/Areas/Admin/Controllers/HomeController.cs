using Microsoft.AspNetCore.Mvc;
using Website_banhang.Areas.Admin.Authorization;

namespace Website_banhang.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeAdmin]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
