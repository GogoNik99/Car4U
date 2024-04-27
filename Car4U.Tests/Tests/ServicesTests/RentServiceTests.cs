using Car4U.Core.Contracts;
using Car4U.Core.Services;
using Car4U.Infrastructure.Data.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.ServicesTests
{
    [TestFixture]
    public class RentServiceTests : UnitTestsBase
    {
        private IRentService _rentService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _rentService = new RentService(_repository);
        }

        [Test]
        public async Task GetAllRentsAsync_ShouldReturnCorrectData()
        {
            var rents = await _rentService.GetAllRentsAsync();

            Assert.IsNotNull(rents);

            var rentedVehiclesInDb = _repository.AllReadOnly<Vehicle>()
                .Where(v => v.RenterId != null);

            Assert.AreEqual(rentedVehiclesInDb.Count(), rents.Count());

            var resultVehicle = rents.ToList().Find(v => v.Id == RentedVehicle.Id);

            Assert.IsNotNull(resultVehicle);

            var ownerExpectedName = $"{RentedVehicle.Owner.User.FirstName} {RentedVehicle.Owner.User.LastName}";

            Assert.AreEqual(ownerExpectedName, resultVehicle.OwnerName);

            var renterExpectedName = $"{RentedVehicle.Renter.FirstName} {RentedVehicle.Renter.LastName}";

            Assert.AreEqual(renterExpectedName, resultVehicle.RenterName);

            var modelExpectedName = RentedVehicle.Model.Name;

            Assert.AreEqual(modelExpectedName, resultVehicle.ModelName);

            Assert.AreEqual(RentedVehicle.Owner.PhoneNumber, resultVehicle.PhoneNumber);

            Assert.AreEqual(RentedVehicle.Owner.User.Email, resultVehicle.OwnerEmail);


        }
    }
}
