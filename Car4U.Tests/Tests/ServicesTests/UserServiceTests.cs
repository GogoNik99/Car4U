using Car4U.Core.Contracts;
using Car4U.Core.Services;
using Car4U.Infrastructure.Data.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.ServicesTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService _userService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _userService = new UserService(_repository);
        }

        [Test]
        public async Task All_ShouldReturnCorrectDataAndUsers()
        {
            var result = await _userService.AllUsersAsync();

            var usersCount = _repository.All<ApplicationUser>().Count();
            var resulUsers = result.ToList();

            Assert.AreEqual(usersCount, resulUsers.Count());

            var ownersCount = _repository.All<Owner>().Count();
            var resultOwners = resulUsers.Where(u => u.IsOwner == true);

            Assert.AreEqual(ownersCount, resultOwners.Count());

            var ownerUser = resultOwners
                .FirstOrDefault(o => o.Email == Owner.User.Email);

            Assert.IsNotNull(ownerUser);
            var ownerFullName = $"{Owner.User.FirstName} {Owner.User.LastName}";
            Assert.AreEqual(ownerUser.UserFullName, ownerFullName);
        }
    }
}
