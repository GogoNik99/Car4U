using Car4U.Core.Extensions;
using Car4U.Infrastructure.Data.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.Extensions
{
    public class IQueryableExtensionsTests : UnitTestsBase
    {
        [Test]
        public void IQueryableExtensionsTest()
        {
            var vehicles = _repository.All<Vehicle>();

            var vehiclesAfterExtensions = vehicles.ProjectToVehicleServiceModel();

            Assert.AreEqual(vehicles.Count(), vehiclesAfterExtensions.Count());
        }
    }
}
