using Car4U.Areas.Admin.Controllers;
using Car4U.Core.Contracts;
using Car4U.Core.Models.Vehicle;
using Car4U.Core.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Car4U.Tests.Tests.IntegrationTests.Admin
{
    public class VehicleControllerTests : UnitTestsBase
    {
        private IVehicleService _vehicleService;
        private VehicleController _vehicleController;

        [OneTimeSetUp]
        public void SetUp()
        {
            var _ownerService = new OwnerService(_repository);
            var _imageService = new ImageService();
            var _modelService = new ModelService(_repository);
            _vehicleService = new VehicleService(_repository, _ownerService, _modelService, _imageService);
            _vehicleController = new VehicleController(_vehicleService);
        }

        [Test]
        public async Task ForApproval_ShouldReturnCorrectCount()
        {
            var result = await _vehicleController.ForApproval() as ViewResult;
            var resultCount = (result.Model as List<VehicleServiceModel>).Count();

            var expectedCount = _vehicleService.GetUnApprovedAsync().Result.Count();

            Assert.AreEqual(expectedCount, resultCount);
        }

        [Test]
        public async Task Details_WhenIdIsNotFound()
        {
            int id = -1;

            var model = await _vehicleController.Details(id) as NotFoundResult;

            Assert.AreEqual(404, model.StatusCode);

        }
    }
}
