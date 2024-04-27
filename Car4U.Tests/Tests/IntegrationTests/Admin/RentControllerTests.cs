using Car4U.Areas.Admin.Controllers;
using Car4U.Core.Contracts;
using Car4U.Core.Models.Rent;
using Car4U.Core.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Car4U.Tests.Tests.IntegrationTests.Admin
{
    public class RentControllerTests : UnitTestsBase
    {
        private IRentService _rentService;
        private RentController _rentController;

        [OneTimeSetUp]
        public void SetUp()
        {
            _rentService = new RentService(_repository);
            _rentController = new RentController(_rentService);
        }

        [Test]
        public async Task TestAllAsync()
        {
            var result = await _rentController.All() as ViewResult;

            Assert.AreEqual(typeof(List<RentViewModel>), result.Model.GetType());
        }
    }
}
