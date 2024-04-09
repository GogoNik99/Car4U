using Car4U.Core.Contracts;
using Car4U.Core.Models.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Car4U.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService _vehicleService;

        private readonly IImageService _imageService;

        private readonly IOwnerService _ownerService;

        private readonly ILogger _logger;

        public VehicleController(
            IVehicleService vehicleService,
            IImageService imageService,
            ILogger<VehicleController> logger,
            IOwnerService ownerService)
        {
            _vehicleService = vehicleService;
            _imageService = imageService;
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
    }
}
