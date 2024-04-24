using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Car4U.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction("Tasks", "Home", new { area = "Admin" });
            }
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {

            if (statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 500)
            {
                return View("Error500");
            }

            return View();
        }
    }
}