using Car4U.Areas.Admin.Controllers;
using Car4U.Core.Contracts;
using Car4U.Core.Models.Admin.User;
using Car4U.Core.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Car4U.Tests.Tests.IntegrationTests.Admin
{
    [TestFixture]
    public class UserControllerTests : UnitTestsBase
    {
        private IUserService _userService;
        private UserController _userController;

        [OneTimeSetUp]
        public void SetUp()
        {
            _userService = new UserService(_repository);
            _userController = new UserController(_userService);
        }

        [Test]
        public async Task TestAllAsync()
        {
            var result = await _userController.All() as ViewResult;

            Assert.AreEqual(typeof(List<UserInfoViewModel>), result.Model.GetType());
        }

    }
}
