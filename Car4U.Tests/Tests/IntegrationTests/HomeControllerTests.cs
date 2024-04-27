using Car4U.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Security.Claims;

namespace Car4U.Tests.Tests.IntegrationTests
{
    public class HomeControllerTests : UnitTestsBase
    {
        private HomeController _homeController;
        private Microsoft.Extensions.Logging.ILogger<HomeController> _logger;

        [OneTimeSetUp]
        public void SetUp()
        {
            var serviceProvider = new ServiceCollection()
             .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<HomeController>();
            _logger = logger;

            _homeController = new HomeController(logger);
            _homeController.ControllerContext = new ControllerContext
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
        public void ErrorActionTest1()
        {
            var result = _homeController.Error(404) as ViewResult;

            Assert.AreEqual("Error404", result.ViewName);
        }


        [Test]
        public void ErrorActionTest2()
        {
            var result = _homeController.Error(400) as ViewResult;

            Assert.AreEqual("Error400", result.ViewName);
        }


        [Test]
        public void ErrorActionTest3()
        {
            var result = _homeController.Error(500) as ViewResult;

            Assert.AreEqual("Error500", result.ViewName);
        }

    }
}