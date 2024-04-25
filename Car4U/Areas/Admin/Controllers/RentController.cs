using Car4U.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Car4U.Areas.Admin.Controllers
{
    public class RentController : AdminBaseController
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await _rentService.GetAllRentsAsync();

            return View(model);
        }
    }
}
