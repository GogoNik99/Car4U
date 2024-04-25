using Car4U.Core.Contracts;
using Car4U.Core.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Car4U.Areas.Admin.Controllers
{
    public class VehicleController : AdminBaseController
    {
        private IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> ForApproval()
        {
            var model = await _vehicleService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            if (await _vehicleService.ExistsAsync(id) == false)
            {
                return NotFound();
            }

            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            VehicleDetailsViewModel model = await _vehicleService.GetVehiclesDetailsAsync(id);

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Approve(int id)
        {
            await _vehicleService.ApproveVehicleAsync(id);

            return RedirectToAction(nameof(ForApproval));
        }
    }
}
