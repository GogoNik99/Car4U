using Car4U.Areas.Admin.Controllers;
using NUnit.Framework;

namespace Car4U.Tests.Tests.IntegrationTests.Admin
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _homeController;

        [OneTimeSetUp]
        public void SetUp()
        {
            _homeController = new HomeController();
        }

        [Test]
        public void TasksShouldNotBeNull()
        {
            var action = _homeController.Tasks();

            Assert.IsNotNull(action);
        }

    }
}
