using Car4U.Core.Contracts;
using Car4U.Core.Services;
using Car4U.Infrastructure.Data.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.ServicesTests
{
    [TestFixture]
    public class OwnerServiceTests : UnitTestsBase
    {
        private IOwnerService _ownerService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _ownerService = new OwnerService(_repository);
        }

        [Test]
        public async Task IsOwnerAsyncShouldReturnTrue()
        {
            var isOwner = await _ownerService.IsOwnerAsync(RentedVehicle.Id, Owner.UserId);

            Assert.IsTrue(isOwner);
        }

        [Test]
        public async Task IsOwnerAsyncShouldReturnFalse()
        {
            string fakeUserId = "316646dd-1654-4396-bad8-9d6a7a0f45b0";
            var isOwner = await _ownerService.IsOwnerAsync(RentedVehicle.Id, fakeUserId);

            Assert.IsFalse(isOwner);
        }

        [Test]
        public async Task OwnerExistsAsyncShouldReturnTrue()
        {
            var ownerExists = await _ownerService.OwnerExistsAsync(Owner.UserId);

            Assert.IsTrue(ownerExists);
        }

        [Test]
        public async Task OwnerExistsAsyncShouldReturnFalse()
        {
            string fakeUserId = "316646dd-1654-4396-bad8-9d6a7a0f45b0";
            var ownerExists = await _ownerService.OwnerExistsAsync(fakeUserId);

            Assert.IsFalse(ownerExists);
        }

        [Test]
        public async Task OwnerExistsByIdAsyncShouldReturnTrue()
        {
            var ownerExistsById = await _ownerService.OwnerExistsByIdAsync(Owner.Id);

            Assert.IsTrue(ownerExistsById);
        }

        [Test]
        public async Task OwnerExistsByIdAsyncShouldReturnFalse()
        {
            var fakeId = 10;
            var ownerExistsById = await _ownerService.OwnerExistsByIdAsync(fakeId);

            Assert.IsFalse(ownerExistsById);
        }

        [Test]
        public async Task OwnerWithPhoneExistsAsyncShouldReturnTrue()
        {
            var ownerPhoneExists = await _ownerService.OwnerWithPhoneNumberExistsAsync(Owner.PhoneNumber);

            Assert.IsTrue(ownerPhoneExists);
        }

        [Test]
        public async Task OwnerWithPhoneExistsAsyncShouldReturnFalse()
        {
            var fakePhoneNumber = "0fake";
            var ownerPhoneExists = await _ownerService.OwnerWithPhoneNumberExistsAsync(fakePhoneNumber);

            Assert.IsFalse(ownerPhoneExists);
        }

        [Test]
        public async Task OwnerWithAddressExistsAsyncShouldReturnTrue()
        {
            var ownerAddressExists = await _ownerService.OwnerWithAddressExistsAsync(Owner.Address);

            Assert.IsTrue(ownerAddressExists);
        }

        [Test]
        public async Task OwnerWithAddressExistsAsyncShouldReturnFalse()
        {
            var fakeAddress = "Sofia, ul. Neofit Rilski 10, et.6, ap.6";

            var ownerAddressExists = await _ownerService.OwnerWithAddressExistsAsync(fakeAddress);

            Assert.IsFalse(ownerAddressExists);
        }

        [Test]
        public async Task OwnerShouldBeCreated()
        {
            var userId = "316646dd-1654-4396-bad8-9d6a7a0f45b0";
            var phoneNumber = "0897234568";
            var address = "Sofia, ul. Neofit Rilski 10, et.3, ap.6";

            int expectedCount = 2;
            await _ownerService.CreateAsync(userId, phoneNumber, address);
            int ownersCount = _repository.AllReadOnly<Owner>().Count();

            Assert.AreEqual(expectedCount, ownersCount);
        }

        [Test]
        public async Task GetOwnerIdAsyncShouldReturnCorrectId()
        {
            int expectedId = 1;
            string userId = Owner.UserId;
            int testId = await _ownerService.GetOwnerIdAsync(userId);

            Assert.AreEqual(expectedId, testId);
        }



    }
}
