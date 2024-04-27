using Car4U.Controllers;
using Car4U.Core.Models.Vehicle;
using Car4U.Core.Services;
using Car4U.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Security.Claims;

namespace Car4U.Tests.Tests.IntegrationTests
{
    [TestFixture]
    public class VehicleControllerTests : UnitTestsBase
    {
        private VehicleController _vehicleController;
        private Microsoft.Extensions.Logging.ILogger<VehicleController> _logger;

        void RefreshTestControllerContext()
        {
            var serviceProvider = new ServiceCollection()
             .AddLogging()
             .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<VehicleController>();
            _logger = logger;

            var ownerService = new OwnerService(_repository);
            var ratingService = new RatingService(_repository);
            var modelService = new ModelService(_repository);
            var imageService = new ImageService();
            var vehicleService = new VehicleService(_repository, ownerService, modelService, imageService);

            _vehicleController = new VehicleController(vehicleService, _logger, ownerService);

            _vehicleController.ControllerContext = new ControllerContext
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
            RefreshTestControllerContext();
            var result = await _vehicleController.All(new Core.Models.Vehicle.AllVehiclesQueryModel
           ()) as ViewResult;

            Assert.AreEqual(typeof(AllVehiclesQueryModel), result.Model.GetType());
        }

        [Test]
        public async Task AllActionTest3()
        {
            RefreshTestControllerContext();
            var result = await _vehicleController.All(new Core.Models.Vehicle.AllVehiclesQueryModel
            {
                FuelType = "Electric"
            }) as ViewResult;

            var resultModel = result.Model as AllVehiclesQueryModel;

            Assert.AreEqual(resultModel.Vehicles.Count(), resultModel.Vehicles.Select(x => x.Fuel == "Electric").Count());
        }

        [Test]
        public async Task DetailsActionTest()
        {
            RefreshTestControllerContext();
            var result = await _vehicleController.Details(1) as ViewResult;

            Assert.AreEqual(typeof(VehicleDetailsViewModel), result.Model.GetType());
        }

        [Test]
        public async Task DetailsActionTest2()
        {
            RefreshTestControllerContext();
            //test inactive car
            await _repository.AddAsync<Vehicle>(new Vehicle()
            {
                Id = 61,
                Description = "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5",
                IsActive = false,
                FuelTypeId = Electric.Id,
                ImageFileName = "Peugeot.jpg",
                Manufacturer = "France",
                ModelId = Peugeot.Id,
                OwnerId = Owner.Id,
                Price = 200,
                RenterId = RenterUser.Id
            });
            await _repository.SaveChangesAsync();

            var result = await _vehicleController.Details(61) as BadRequestResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public async Task RentedVehiclesActionTest()
        {
            RefreshTestControllerContext();
            //add authoraized user renter
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                     {
                         new Claim(ClaimTypes.NameIdentifier, "0251e959-ffa1-4167-900f-9cc0efec14dd")
                     }))
                }
            };

            var result = await _vehicleController.RentedVehicles() as ViewResult;

            Assert.AreEqual(typeof(List<VehicleServiceModel>), result.Model.GetType());
            Assert.IsTrue((result.Model as List<VehicleServiceModel>).Count > 1);
        }

        [Test]
        public async Task OwnedVehiclesActionTest()
        {
            RefreshTestControllerContext();
            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };

            var result = await _vehicleController.OwnedVehicles() as ViewResult;

            Assert.AreEqual(typeof(List<VehicleServiceModel>), result.Model.GetType());
            Assert.IsTrue((result.Model as List<VehicleServiceModel>).Count > 1);
        }

        [Test]
        public async Task RegisterVehiclesActionTest()
        {
            RefreshTestControllerContext();
            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };

            var result = await _vehicleController.Register() as ViewResult;

            Assert.AreEqual(typeof(VehicleFormModel), result.Model.GetType());
        }
        [Test]
        public async Task RegisterVehiclesActionTest2()
        {
            RefreshTestControllerContext();

            var result = await _vehicleController.Register() as ViewResult;

            Assert.IsFalse(result.ViewData.ModelState.IsValid);
            Assert.AreEqual("Not registered as Owner", result.ViewData.ModelState["Owner"].Errors[0].ErrorMessage);
        }
        [Test]
        public async Task RegisterVehiclesActionTest3()
        {
            RefreshTestControllerContext();
            var result = await _vehicleController.Register(new VehicleFormModel
            {
                Description = "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest",
                id = 11,
                Manifacturer = "Opel",
                ModelName = "Opel",
                Price = 150M,
                FuelTypeId = 1
            }) as ViewResult;

            Assert.IsFalse(result.ViewData.ModelState.IsValid);
            Assert.AreEqual("Not registered as Owner", result.ViewData.ModelState["Owner"].Errors[0].ErrorMessage);

        }
        [Test]
        public async Task RegisterVehiclesActionTest4()
        {
            RefreshTestControllerContext();
            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };
            var result = await _vehicleController.Register(new VehicleFormModel
            {
                Description = "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest",
                id = 11,
                Manifacturer = "Opel",
                ModelName = "Opel",
                Price = 150M,
                FuelTypeId = 1111
            }) as ViewResult;

            Assert.IsFalse(result.ViewData.ModelState.IsValid);
            Assert.AreEqual("There is no such fuel type!", result.ViewData.ModelState["FuelTypeId"].Errors[0].ErrorMessage);
        }
        [Test]
        public async Task RegisterVehiclesActionTest5()
        {
            RefreshTestControllerContext();
            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };
            var result = await _vehicleController.Register(new VehicleFormModel
            {
                Description = "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest",
                id = 11,
                Manifacturer = "Opel",
                ModelName = "Opel",
                Price = 150M,
                FuelTypeId = 1
            }) as RedirectToActionResult;

            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
            Assert.AreEqual("OwnedVehicles", result.ActionName);
            Assert.AreEqual("Vehicle", result.ControllerName);
        }

        [Test]
        public async Task EditVehiclesActionTest2()
        {
            RefreshTestControllerContext();

            var result = await _vehicleController.Edit(1111) as NotFoundResult;
            Assert.AreEqual(404, result.StatusCode);
        }
        [Test]
        public async Task EditVehiclesActionTest1()
        {
            RefreshTestControllerContext();

            var result = await _vehicleController.Edit(1) as UnauthorizedResult;
            Assert.AreEqual(401, result.StatusCode);
        }
        [Test]
        public async Task EditVehiclesActionTest3()
        {
            RefreshTestControllerContext();
            //add authoraized user renter
            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };

            var result = await _vehicleController.Edit(1) as ViewResult;


            Assert.AreEqual(typeof(VehicleFormModel), result.Model.GetType());
        }
        [Test]
        public async Task RentVehiclesActionTest1()
        {
            RefreshTestControllerContext();

            var result = await _vehicleController.Edit(111111) as NotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }
        [Test]
        public async Task ReturnVehiclesActionTest1()
        {
            RefreshTestControllerContext();

            var result = await _vehicleController.Return(111111) as NotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }
        [Test]
        public async Task DeleteVehiclesActionTest1()
        {
            RefreshTestControllerContext();

            var result = await _vehicleController.Delete(111111) as NotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }
        [Test]
        public async Task DeleteVehiclesActionTest2()
        {
            RefreshTestControllerContext();

            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };

            var result = await _vehicleController.Delete(1) as ViewResult;


            Assert.AreEqual(typeof(VehicleDeleteDetailsViewModel), result.Model.GetType());
        }

        [Test]
        public async Task ReturnVehiclesActionTest2()
        {
            RefreshTestControllerContext();


            var result = await _vehicleController.Return(1) as UnauthorizedResult;

            Assert.AreEqual(401, result.StatusCode);
        }
        [Test]
        public async Task RentVehiclesActionTest2()
        {
            RefreshTestControllerContext();


            var result = await _vehicleController.Rent(1) as BadRequestResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public async Task EditVehiclesActionTest4()
        {
            RefreshTestControllerContext();


            var result = await _vehicleController.Edit(new VehicleFormModel(), 11111) as NotFoundResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public async Task EditVehiclesActionTest5()
        {
            RefreshTestControllerContext();
            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };

            var result = await _vehicleController.Edit(new VehicleFormModel
            {
                Description = "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest",
                FuelTypeId = 1,
                Price = 151M,
                Manifacturer = "Honda",
                ModelName = "Civic"
            }, 1) as RedirectToActionResult;

            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());

            Assert.AreEqual("Details", result.ActionName);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [Test]
        public async Task DeleteVehiclesActionTest5()
        {
            RefreshTestControllerContext();
            //add authoraized user owner
            _vehicleController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                      {
                           new Claim(ClaimTypes.NameIdentifier, "fd09b928-e634-4d61-a792-f2531b5c1c30")
                      }))
                }
            };

            var result = await _vehicleController.Delete(new VehicleDeleteDetailsViewModel
            {
                Id = 1
            }) as RedirectToActionResult;

            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());

            Assert.AreEqual("OwnedVehicles", result.ActionName);

            RentedVehicle = new Vehicle()
            {
                Id = 1,
                Description = "Двигател 1.5 Turbo (140 кс) Automatic. Начало на производство Юли, 2018 г - Край на производство Февруари, 2020 г. Тип каросерия Хечбек, Брой места 5, Брой врати 5",
                IsActive = true,
                FuelTypeId = Electric.Id,
                ImageFileName = "Peugeot.jpg",
                Manufacturer = "France",
                ModelId = Peugeot.Id,
                OwnerId = Owner.Id,
                Price = 200,
                RenterId = RenterUser.Id
            };
            await _repository.AddAsync<Vehicle>(RentedVehicle);
            await _repository.SaveChangesAsync();
        }
    }
}