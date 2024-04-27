using Car4U.Core.Contracts;
using Car4U.Core.Models.Rating;
using Car4U.Core.Services;
using Car4U.Infrastructure.Data.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.ServicesTests
{
    [TestFixture]
    public class RatingServiceTests : UnitTestsBase
    {
        private IRatingService _ratingService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _ratingService = new RatingService(_repository);
        }

        [Test]
        public async Task CreateRating()
        {
            RatingFormViewModel model = new RatingFormViewModel()
            {
                Description = "Description",
                RatingValue = 4.5m
            };
            int expectedCount = _repository.All<Rating>().Count() + 1;

            await _ratingService.CreateRatingAsync(model, Owner.Id);

            int count = _repository.All<Rating>().Count();

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public async Task GetRatingDetailsByOwnerId()
        {
            int expectedCount = _repository.All<Rating>().Where(x => x.OwnerId == Owner.Id).Count();

            int count = _ratingService.GetRatingDetailsByOwnerIdAsync(Owner.Id).Result.Count(); ;

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public async Task GetAllOwnersRatings()
        {
            int expectedCount = _repository.All<Owner>().Count();

            int count = _ratingService.GetAllOwnersRatingsAsync().Result.Count(); ;

            Assert.AreEqual(expectedCount, count);
        }
    }
}
