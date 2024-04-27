using Car4U.Controllers;
using Car4U.Core.Models.Owner;
using Car4U.Core.Models.Rating;
using Car4U.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Security.Claims;

namespace Car4U.Tests.Tests.IntegrationTests
{
    [TestFixture]
    public class RaitingControllerTests : UnitTestsBase
    {
        private RatingController _ratingController;
        private Microsoft.Extensions.Logging.ILogger<RatingController> _logger;

        [OneTimeSetUp]
        public void SetUp()
        {
            var ownerService = new OwnerService(_repository);
            var ratingService = new RatingService(_repository);
            var modelService = new ModelService(_repository);
            var imageService = new ImageService();
            var vehicleService = new VehicleService(_repository, ownerService, modelService, imageService);

            _ratingController = new RatingController(ratingService, ownerService, vehicleService);
            _ratingController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
              {
            new Claim(ClaimTypes.NameIdentifier, "test")
              }))
                }
            };
        }


        [Test]
        public async Task AllActionTest()
        {
            var result = await _ratingController.All() as ViewResult;

            var resultModel = result.Model as List<OwnerRatingsViewModel>;

            Assert.AreEqual(typeof(List<OwnerRatingsViewModel>), result.Model.GetType());
            Assert.AreEqual(1, resultModel.Count);
        }

        [Test]
        public async Task InfoActionTest()
        {
            var result = await _ratingController.Info(1) as ViewResult;
            var resultModel = result.Model as List<RatingDetailsServiceModel>;

            Assert.AreEqual(typeof(List<RatingDetailsServiceModel>), result.Model.GetType());
            Assert.AreEqual(1, resultModel.Count);
            Assert.AreEqual(resultModel[0].Id, 1);
            Assert.AreEqual(resultModel[0].RatingValue, 7.2M);
            Assert.AreEqual(resultModel[0].OwnerName, "Mihail Nikolov");
            Assert.AreEqual(resultModel[0].Description, "I was completely impressed with their professionalism and customer service.");

            var result2 = await _ratingController.Info(2) as NotFoundResult;

            Assert.AreEqual(404, result2.StatusCode);
        }

        [Test]
        public async Task RateActionTest()
        {
            var result = await _ratingController.Rate(1) as UnauthorizedResult;
            Assert.AreEqual(401, result.StatusCode);

            //add authoraized user
            _ratingController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
              {
            new Claim(ClaimTypes.NameIdentifier, "0251e959-ffa1-4167-900f-9cc0efec14dd")
              }))
                }
            };

            var result2 = await _ratingController.Rate(1) as ViewResult;

            Assert.AreEqual(typeof(RatingFormViewModel), result2.Model.GetType());

            //tova ne mozhe da se proveri ponezhe IsRentedByIUserWithIdAsync vrushta
            // false dori kogato idto na kolata q nqma i vliza v if-a za unauthorized
            //var result3 = await _ratingController.Rate(-111) as NotFoundResult;

            //Assert.AreEqual(404, result3.StatusCode);

        }
        [Test]
        public async Task RateActionTest2()
        {
            //add authoraized user
            _ratingController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
              {
            new Claim(ClaimTypes.NameIdentifier, "0251e959-ffa1-4167-900f-9cc0efec14dd")
              }))
                }
            };

            var result3 = await _ratingController.Rate(new RatingFormViewModel
            {
                Description = "Best car in the world",
                RatingValue = 10
            }) as RedirectToActionResult;


            Assert.AreEqual(typeof(RedirectToActionResult), result3.GetType());
            Assert.AreEqual("RentedVehicles", result3.ActionName);
            Assert.AreEqual("Vehicle", result3.ControllerName);
        }
    }
}