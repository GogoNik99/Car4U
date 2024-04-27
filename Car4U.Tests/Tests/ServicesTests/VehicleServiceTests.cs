using Car4U.Core.Contracts;
using Car4U.Core.Models.Vehicle;
using Car4U.Core.Services;
using Car4U.Infrastructure.Data.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.ServicesTests
{
    [TestFixture]
    public class VehicleServiceTests : UnitTestsBase
    {
        private IVehicleService _vehicleService;

        [OneTimeSetUp]
        public void SetUp()
        {
            var _ownerService = new OwnerService(_repository);
            var _imageService = new ImageService();
            var _modelService = new ModelService(_repository);
            _vehicleService = new VehicleService(_repository, _ownerService, _modelService, _imageService);
        }

        [Test]
        public async Task AllModelNames_ShouldReturnCorrectResult()
        {
            var result = await _vehicleService.AllModelNamesAsync();

            var dbModels = _context.Models;

            Assert.AreEqual(dbModels.Count(), result.Count());

            var modelNames = dbModels.Select(m => m.Name);

            Assert.That(modelNames.Contains(result.FirstOrDefault()));
        }

        [Test]
        public async Task AllFuelTypeNames_ShouldReturnCorrectResult()
        {
            var result = await _vehicleService.AllFuelTypeNamesAsync();

            var dbFuelTypes = _context.FuelTypes;

            Assert.AreEqual(dbFuelTypes.Count(), result.Count());

            var FuelTypeNames = dbFuelTypes.Select(m => m.Name);

            Assert.That(FuelTypeNames.Contains(result.FirstOrDefault()));
        }

        [Test]
        public async Task AllVehiclesByRenter_ShouldReturnCorrectVehicles()
        {
            var renterId = RenterUser.Id;

            var result = await _vehicleService.AllVehiclesByRenter(renterId);

            Assert.IsNotNull(result);

            var vehiclesInDbContext = _context.Vehicles
                .Where(v => v.RenterId == renterId);

            Assert.AreEqual(vehiclesInDbContext.Count(), result.Count());
        }

        [Test]
        public async Task AllFuelTypes_ShouldReturnCorrectData()
        {
            List<VehicleFuelTypeServiceModel> expectedResult = _repository.All<FuelType>()
                .Select(x => new VehicleFuelTypeServiceModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            List<VehicleFuelTypeServiceModel> result = (await _vehicleService.AllFuelTypesAsync()).ToList();
            Assert.IsNotNull(result);
            Assert.That(result.Count() > 0);
            Assert.AreEqual(expectedResult.Count(), result.Count());
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].Id, result[i].Id);
                Assert.AreEqual(expectedResult[i].Name, result[i].Name);
            }
        }

        [Test]
        public async Task AllModels_ShouldReturnCorrectData()
        {
            List<VehicleModelServiceModel> expectedResult = _repository.All<Model>()
                .Select(x => new VehicleModelServiceModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            List<VehicleModelServiceModel> result = (await _vehicleService.AllModelsAsync()).ToList();
            Assert.IsNotNull(result);
            Assert.That(result.Count() > 0);
            Assert.AreEqual(expectedResult.Count(), result.Count());
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].Id, result[i].Id);
                Assert.AreEqual(expectedResult[i].Name, result[i].Name);
            }
        }

        [Test]
        public async Task AllVehiclesByOwner_ShouldReturnCorrectData()
        {
            string realUserID = Owner.UserId;
            List<VehicleServiceModel> expectedResult = _repository.AllReadOnly<Vehicle>()
                    .Where(v => v.Owner.UserId == realUserID)
                    .Select(v => new VehicleServiceModel()
                    {
                        Id = v.Id,
                        Description = v.Description,
                        Fuel = v.FuelType.Name,
                        ImageFileName = v.ImageFileName,
                        IsRented = v.RenterId != null,
                        Manifacturer = v.Manufacturer,
                        Name = v.Model.Name,
                        Price = v.Price,
                        Rating = v.Owner.Rating,
                        IsActive = v.IsActive
                    }).ToList();

            List<VehicleServiceModel> result = (await _vehicleService.AllVehiclesByOwner(realUserID)).ToList();
            Assert.IsNotNull(result);
            Assert.That(result.Count() > 0);
            Assert.AreEqual(expectedResult.Count(), result.Count());
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].Id, result[i].Id);
                Assert.AreEqual(expectedResult[i].Description, result[i].Description);
                Assert.AreEqual(expectedResult[i].Fuel, result[i].Fuel);
                Assert.AreEqual(expectedResult[i].ImageFileName, result[i].ImageFileName);
                Assert.AreEqual(expectedResult[i].IsRented, result[i].IsRented);
                Assert.AreEqual(expectedResult[i].Manifacturer, result[i].Manifacturer);
                Assert.AreEqual(expectedResult[i].Name, result[i].Name);
                Assert.AreEqual(expectedResult[i].Price, result[i].Price);
                Assert.AreEqual(expectedResult[i].Rating, result[i].Rating);
                Assert.AreEqual(expectedResult[i].IsActive, result[i].IsActive);
            }
        }

        [Test]
        public async Task AllVehiclesByOwner_ShouldReturnNoData()
        {
            string fakeUserID = "fakeID";
            var result = await _vehicleService.AllVehiclesByOwner(fakeUserID);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public async Task AllVehiclesByRenter_ShouldReturnCorrectData()
        {
            string realUserID = RenterUser.Id;
            List<VehicleServiceModel> expectedResult = _repository.AllReadOnly<Vehicle>()
                    .Where(v => v.RenterId == realUserID)
                    .Select(v => new VehicleServiceModel()
                    {
                        Id = v.Id,
                        Description = v.Description,
                        Fuel = v.FuelType.Name,
                        ImageFileName = v.ImageFileName,
                        IsRented = v.RenterId != null,
                        Manifacturer = v.Manufacturer,
                        Name = v.Model.Name,
                        Price = v.Price,
                        Rating = v.Owner.Rating
                    }).ToList();

            List<VehicleServiceModel> result = (await _vehicleService.AllVehiclesByRenter(realUserID)).ToList();
            Assert.IsNotNull(result);
            Assert.That(result.Count() > 0);
            Assert.AreEqual(expectedResult.Count(), result.Count());
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResult[i].Id, result[i].Id);
                Assert.AreEqual(expectedResult[i].Description, result[i].Description);
                Assert.AreEqual(expectedResult[i].Fuel, result[i].Fuel);
                Assert.AreEqual(expectedResult[i].ImageFileName, result[i].ImageFileName);
                Assert.AreEqual(expectedResult[i].IsRented, result[i].IsRented);
                Assert.AreEqual(expectedResult[i].Manifacturer, result[i].Manifacturer);
                Assert.AreEqual(expectedResult[i].Name, result[i].Name);
                Assert.AreEqual(expectedResult[i].Price, result[i].Price);
                Assert.AreEqual(expectedResult[i].Rating, result[i].Rating);
                Assert.AreEqual(expectedResult[i].IsActive, result[i].IsActive);
            }
        }

        [Test]
        public async Task AllVehiclesByRenter_ShouldReturnNoData()
        {
            string fakeUserID = "fakeID";
            var result = await _vehicleService.AllVehiclesByRenter(fakeUserID);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public async Task Create_ShouldCreateVehicleAndNewModel()
        {
            VehicleFormModel model = new VehicleFormModel()
            {
                id = 10,
                Manifacturer = "Manifacturer",
                Description = "Description",
                ModelName = "New model name",
                Price = 200,
                FuelTypeId = 1,
            };

            int expectedCountModels = _repository.AllReadOnly<Model>().Count() + 1;
            int expectedCountVehicles = _repository.AllReadOnly<Vehicle>().Count() + 1;

            await _vehicleService.CreateAsync(model, Owner.Id);
            int countVehicles = _repository.AllReadOnly<Vehicle>().Count();
            int countModels = _repository.AllReadOnly<Model>().Count();

            Assert.AreEqual(expectedCountModels, countModels);
            Assert.AreEqual(expectedCountVehicles, countVehicles);
        }

        [Test]
        public async Task Exists_ShouldReturnTrueAsync()
        {
            bool result = await _vehicleService.ExistsAsync(RentedVehicle.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task FuelTypeExists_ShouldReturnTrue()
        {
            bool result = await _vehicleService.FuelTypeExists(Petrol.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetVehicleDetails()
        {
            var expectedDetails = _repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == RentedVehicle.Id)
                .Select(v => new VehicleDetailsViewModel()
                {
                    Id = v.Id,
                    Description = v.Description,
                    Fuel = v.FuelType.Name,
                    ImageFileName = v.ImageFileName,
                    IsRented = v.RenterId != null,
                    Manifacturer = v.Manufacturer,
                    Name = v.Model.Name,
                    Price = v.Price,
                    Rating = v.Owner.Rating,
                    IsActive = v.IsActive,
                    Owner = new Car4U.Core.Models.Owner.OwnerServiceModel()
                    {
                        Name = $"{v.Owner.User.FirstName} {v.Owner.User.LastName}",
                        Address = v.Owner.Address,
                        Email = v.Owner.User.Email,
                        PhoneNumber = v.Owner.PhoneNumber
                    }
                }).First();

            var details = await _vehicleService.GetVehiclesDetailsAsync(RentedVehicle.Id);
            Assert.AreEqual(expectedDetails.Id, details.Id);
            Assert.AreEqual(expectedDetails.Description, details.Description);
            Assert.AreEqual(expectedDetails.Fuel, details.Fuel);
            Assert.AreEqual(expectedDetails.ImageFileName, details.ImageFileName);
            Assert.AreEqual(expectedDetails.IsRented, details.IsRented);
            Assert.AreEqual(expectedDetails.Manifacturer, details.Manifacturer);
            Assert.AreEqual(expectedDetails.Name, details.Name);
            Assert.AreEqual(expectedDetails.Price, details.Price);
            Assert.AreEqual(expectedDetails.Rating, details.Rating);
            Assert.AreEqual(expectedDetails.IsActive, details.IsActive);
            Assert.AreEqual(expectedDetails.Owner.Name, details.Owner.Name);
            Assert.AreEqual(expectedDetails.Owner.Address, details.Owner.Address);
            Assert.AreEqual(expectedDetails.Owner.Email, details.Owner.Email);
            Assert.AreEqual(expectedDetails.Owner.PhoneNumber, details.Owner.PhoneNumber);
        }

        [Test]
        public async Task IsRentedByIUserWithId()
        {
            var result = await _vehicleService.IsRentedByIUserWithIdAsync(RentedVehicle.Id, RenterUser.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasOwnerWithId()
        {
            var result = await _vehicleService.HasOwnerWithIdAsync(RentedVehicle.Id, OwnerUser.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetVehicleFormById()
        {
            VehicleFormModel expectedResult = _repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == RentedVehicle.Id)
                .Select(v => new VehicleFormModel
                {
                    id = v.Id,
                    Description = v.Description,
                    FuelTypeId = v.FuelTypeId,
                    Manifacturer = v.Manufacturer,
                    ModelName = v.Model.Name,
                    Price = v.Price
                })
                .FirstOrDefault();

            var result = await _vehicleService.GetVehicleFormById(RentedVehicle.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult.id, result.id);
            Assert.AreEqual(expectedResult.Description, result.Description);
            Assert.AreEqual(expectedResult.FuelTypeId, result.FuelTypeId);
            Assert.AreEqual(expectedResult.Manifacturer, result.Manifacturer);
            Assert.AreEqual(expectedResult.ModelName, result.ModelName);
            Assert.AreEqual(expectedResult.Price, result.Price);
        }

        [Test]
        public async Task Edit_ShouldCreateNewModel()
        {
            VehicleFormModel model = new VehicleFormModel()
            {
                id = VehicleToEdit.Id,
                Manifacturer = "New Manifacturer",
                Description = "New Description",
                ModelName = "New name",
                Price = 200,
                FuelTypeId = 1,
            };

            var expectedVehicle = new Vehicle()
            {
                Price = model.Price,
                Manufacturer = model.Manifacturer,
                Description = model.Description,
                IsActive = false,
                FuelTypeId = model.FuelTypeId,
                Model = new Model()
                {
                    Name = model.ModelName
                }
            };

            int expectedModelCount = _repository.All<Model>().Count() + 1;

            await _vehicleService.EditAsync(VehicleToEdit.Id, model);
            var result = await _repository.GetByIdAsync<Vehicle>(VehicleToEdit.Id);
            int modelCount = _repository.All<Model>().Count();

            Assert.AreEqual(expectedVehicle.Price, result.Price);
            Assert.AreEqual(expectedVehicle.Manufacturer, result.Manufacturer);
            Assert.AreEqual(expectedVehicle.FuelTypeId, result.FuelTypeId);
            Assert.AreEqual(expectedVehicle.Description, result.Description);
            Assert.AreEqual(expectedVehicle.IsActive, result.IsActive);
            Assert.AreEqual(expectedVehicle.Model.Name, result.Model.Name);
            Assert.AreEqual(expectedModelCount, modelCount);
        }

        [Test]
        public async Task Rent()
        {
            int vehicleIdToRent = NotRentedVehicle.Id;
            string renterUserId = RenterUser.Id;

            await _vehicleService.RentAsync(vehicleIdToRent, renterUserId);
            var result = _repository.All<Vehicle>().Where(x => x.Id == vehicleIdToRent).FirstOrDefault();

            Assert.AreEqual(renterUserId, result.RenterId);
        }

        [Test]
        public async Task IsRented()
        {
            var result = await _vehicleService.IsRentedAsync(RentedVehicle.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task Return()
        {
            int vehicleIdToreturn = RentedVehicle.Id;

            await _vehicleService.ReturnAsync(vehicleIdToreturn);
            var result = _repository.All<Vehicle>().Where(x => x.Id == vehicleIdToreturn).FirstOrDefault();

            Assert.IsNull(result.RenterId);
        }

        [Test]
        public async Task DeleteVehicle()
        {
            int vehicleIdToDelete = VehicleToDelete.Id;
            var expectedCount = _repository.All<Vehicle>().Count() - 1;

            await _vehicleService.DeleteVehicleAsync(vehicleIdToDelete);
            var count = _repository.All<Vehicle>().Count();

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public async Task GetDeleteDetailsVehicle()
        {
            int vehicleId = RentedVehicle.Id;
            var expectedVehicle = _repository.AllReadOnly<Vehicle>()
                .Where(v => v.Id == vehicleId)
                .Select(v => new VehicleDeleteDetailsViewModel
                {
                    Description = v.Description,
                    Id = v.Id,
                    ImageName = v.ImageFileName,
                    ModelName = v.Model.Name
                })
                .FirstOrDefault();

            var resultVehicle = await _vehicleService.GetDeleteDetailsAsync(vehicleId);

            Assert.IsNotNull(resultVehicle);
            Assert.AreEqual(expectedVehicle.Id, resultVehicle.Id);
            Assert.AreEqual(expectedVehicle.Description, resultVehicle.Description);
            Assert.AreEqual(expectedVehicle.ImageName, resultVehicle.ImageName);
            Assert.AreEqual(expectedVehicle.ModelName, resultVehicle.ModelName);
        }

        [Test]
        public void GetUnApproved()
        {
            int expectedCount = _repository.All<Vehicle>()
                .Where(x => x.IsActive == false)
                .Count();

            int count = _vehicleService.GetUnApprovedAsync()
                .Result
                .Count();

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public async Task ApproveVehicle()
        {
            await _vehicleService.ApproveVehicleAsync(VehicleToDelete.Id);

            var vehicle = _repository.All<Vehicle>().FirstOrDefault(x => x.Id == VehicleToDelete.Id);

            Assert.IsTrue(vehicle.IsActive);
        }

        [Test]
        public async Task IsVehicleApproved()
        {
            var result = await _vehicleService.IsVehicleApproved(VehicleToDelete.Id);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetVehicleById()
        {
            var result = await _vehicleService.GetVehicleByIdAsync(RentedVehicle.Id);

            Assert.AreEqual(result.Id, RentedVehicle.Id);
        }
    }
}
