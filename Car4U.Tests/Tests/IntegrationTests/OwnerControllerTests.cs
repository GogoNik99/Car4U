using Car4U.Controllers;
using Car4U.Core.Models.Owner;
using Car4U.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Security.Claims;

namespace Car4U.Tests.Tests.IntegrationTests
{
    [TestFixture]
    public class OwnerControllerTests : UnitTestsBase
    {
        private OwnerController _ownerController;
        private Microsoft.Extensions.Logging.ILogger<OwnerController> _logger;

        [OneTimeSetUp]
        public void SetUp()
        {
            var serviceProvider = new ServiceCollection()
             .AddLogging()
             .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<OwnerController>();
            _logger = logger;

            var ownerService = new OwnerService(_repository);
            _ownerController = new OwnerController(ownerService, logger);
            _ownerController.ControllerContext = new ControllerContext
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
        public void BecomeActionTest1()
        {
            var result = _ownerController.Become() as ViewResult;

            Assert.AreEqual(typeof(OwnerFormModel), result.Model.GetType());
        }

        [Test]
        public async Task BecomeActionTest2()
        {

            var result = await _ownerController.Become(new OwnerFormModel
            {
                Address = "ul maichina slava nomer 3",
                PhoneNumber = "0888868775"
            }) as RedirectToActionResult;

            //da se razmenqt indeksa i kontrollera
            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
            Assert.AreEqual("HomeController", result.ActionName);
            Assert.AreEqual("Index", result.ControllerName);
        }

        [Test]
        public async Task BecomeActionTest3()
        {

            var result = await _ownerController.Become(new OwnerFormModel
            {
                Address = "ul maichina slava nomer 3",
                PhoneNumber = "+35952835632"
            }) as ViewResult;

            Assert.IsFalse(result.ViewData.ModelState.IsValid);
            Assert.AreEqual("This phonenumber exists", result.ViewData.ModelState["PhoneNumber"].Errors[0].ErrorMessage);

            var result2 = await _ownerController.Become(new OwnerFormModel
            {
                Address = "Sofia, j.k. Tolstoi, Building 52, Entrance D, ap. 98",
                PhoneNumber = "+35953331631"
            }) as ViewResult;

            Assert.IsFalse(result2.ViewData.ModelState.IsValid);
            Assert.AreEqual("This address already exists", result2.ViewData.ModelState["Address"].Errors[0].ErrorMessage);
        }

    }
}