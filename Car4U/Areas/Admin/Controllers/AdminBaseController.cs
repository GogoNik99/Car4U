using Microsoft.AspNetCore.Mvc;

namespace Car4U.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
