using Microsoft.AspNetCore.Mvc;

namespace Car4U.Areas.Admin.Controllers
{
    public class VehicleController : AdminBaseController
    {
        public IActionResult ForApproval()
        {
            return View();
        }
    }
}
