using Car4U.Core.Contracts;
using Car4U.Core.Models.Car;
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
            ILogger logger)
        {
            _vehicleService = vehicleService;
            _imageService = imageService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllVehiclesQueryModel model)
        {
            var vehicles = await _vehicleService.AllAsync
                (
                    model.FuelType,
                    model.Model,
                    model.SearchTerm,
                    model.VehiclesSorting,
                    model.CurrentPage,
                    model.VehiclesPerPage
                );

            model.TotalVehiclesCount = vehicles.TotalVehiclesCount;

            model.Vehicles = vehicles.Vehicles;

            model.FuelTypes = await _vehicleService.AllFuelTypeNamesAsync();

            model.FuelTypes = await _vehicleService.AllModelNamesAsync();

            return View(model);
        }
    }
}
