using Car4U.Core.Contracts;
using Car4U.Core.Models.Rating;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Car4U.Controllers
{
    public class RatingController : BaseController
    {
        private readonly IRatingService _ratingService;
        private readonly IOwnerService _ownerService;
        private readonly IVehicleService _vehicleService;

        public RatingController(
            IRatingService ratingService,
            IOwnerService ownerService,
            IVehicleService vehicleService)
        {
            _ratingService = ratingService;
            _ownerService = ownerService;
            _vehicleService = vehicleService;

        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await _ownerService.GetAllOwnersRatingsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            if (!await _ownerService.OwnerExistsByIdAsync(id))
            {
                return NotFound();
            }
            var model = await _ratingService.GetRatingDetailsByOwnerIdAsync(id);

            if (model.Count() == 0)
            {
                return RedirectToAction(nameof(All));
            }

            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Rate(int id)
        {
            if (await _vehicleService.IsRentedByIUserWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await _vehicleService.ExistsAsync(id) == false)
            {
                return NotFound();
            }

            RatingFormViewModel model = new RatingFormViewModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Rate(RatingFormViewModel model)
        {

            var vehicle = await _vehicleService.GetRentedVehicleByUserId(User.Id());

            if (await _vehicleService.ExistsAsync(vehicle.Id) == false)
            {
                return NotFound();
            }

            if (await _vehicleService.IsRentedByIUserWithIdAsync(vehicle.Id, User.Id()) == false)
            {
                return Unauthorized();
            }
            if (await _ownerService.OwnerExistsByIdAsync(vehicle.OwnerId) == false)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _ratingService.CreateRatingAsync(model, vehicle.OwnerId);
            await _vehicleService.ReturnAsync(vehicle.Id);

            return RedirectToAction("RentedVehicles", "Vehicle");
        }
    }
}
