using Microsoft.AspNetCore.Mvc;

namespace Car4U.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Tasks()
        {
            return View();
        }


    }
}
