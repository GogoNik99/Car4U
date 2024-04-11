using Car4U.Core.Contracts;
using Car4U.Core.Models.Vehicle;
using Car4U.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Car4U.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService _vehicleService;

        private readonly IOwnerService _ownerService;

        private readonly ILogger _logger;

        public VehicleController(
            IVehicleService vehicleService,
            ILogger<VehicleController> logger,
            IOwnerService ownerService)
        {
            _vehicleService = vehicleService;
            _logger = logger;
            _ownerService = ownerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllVehiclesQueryModel input)
        {
            var vehicles = await _vehicleService.AllAsync
                (
                    input.FuelType,
                    input.Model,
                    input.SearchTerm,
                    input.VehiclesSorting,
                    input.CurrentPage,
                    input.VehiclesPerPage
                );

            input.TotalVehiclesCount = vehicles.TotalVehiclesCount;

            input.Vehicles = vehicles.Vehicles;

            input.FuelTypes = await _vehicleService.AllFuelTypeNamesAsync();

            input.Models = await _vehicleService.AllModelNamesAsync();

            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            VehicleDetailsViewModel model = await _vehicleService.GetVehiclesDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RentedVehicles()
        {
            var userId = User.Id();

            IEnumerable<VehicleServiceModel> model = await _vehicleService.AllVehiclesByRenter(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OwnedVehicles()
        {
            var userId = User.Id();

            IEnumerable<VehicleServiceModel> model = await _vehicleService.AllVehiclesByOwner(userId);

            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Register()
        {
            if (!await _ownerService.OwnerExistsAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(Owner), "Not registered as Owner");
            }

            var model = new VehicleFormModel()
            {
                FuelTypes = await _vehicleService.AllFuelTypesAsync()
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Register(VehicleFormModel model)
        {
            if (!await _ownerService.OwnerExistsAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(Owner), "Not registered as Owner");
            }

            if (!await _vehicleService.FuelTypeExists(model.FuelTypeId))
            {
                ModelState.AddModelError(nameof(model.FuelTypeId), "There is no such fuel type!");
            }

            if (!ModelState.IsValid)
            {
                model.FuelTypes = await _vehicleService.AllFuelTypesAsync();

                return View(model);
            }

            int OwnerId = await _ownerService.GetOwnerIdAsync(User.Id());

            await _vehicleService.CreateAsync(model, OwnerId);

            return RedirectToAction(nameof(OwnedVehicles), nameof(Vehicle));
        }
    }
}
