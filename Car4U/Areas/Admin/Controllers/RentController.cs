using Microsoft.AspNetCore.Mvc;

namespace Car4U.Areas.Admin.Controllers
{
    public class RentController : AdminBaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
