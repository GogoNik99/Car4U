using Car4U.Core.Contracts;
using Car4U.Core.Models.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car4U.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService _vehicleService;

        private readonly IImageService _imageService;

        private readonly ILogger _logger;

        public VehicleController(
            IVehicleService vehicleService,
            IImageService imageService,
            ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _imageService = imageService;
            _logger = logger;
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

            VehicleServiceModel model = await _vehicleService.GetVehiclesDetailsAsync(id);

            return View(model);
        }
    }
}
