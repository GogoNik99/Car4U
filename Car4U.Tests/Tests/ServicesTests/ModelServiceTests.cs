using Car4U.Core.Contracts;
using Car4U.Core.Services;
using Car4U.Infrastructure.Data.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.ServicesTests
{
    [TestFixture]
    public class ModelServiceTests : UnitTestsBase
    {
        private IModelService _modelService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _modelService = new ModelService(_repository);
        }

        [Test]
        public async Task ModelExistsAsyncShouldReturnTrue()
        {
            var result = await _modelService.ModelExistsAsync(Opel.Name);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ModelExistsAsyncShouldReturnFalse()
        {
            string fakeName = "Lada";
            var result = await _modelService.ModelExistsAsync(fakeName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetModelIdAsyncShouldReturnCorrectId()
        {
            int expectedResult = 2;

            var actualResult = await _modelService.GetModelIdAsync(Opel.Name);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public async Task CreateModelShouldCreateNewModel()
        {
            string name = "Golf 3";

            int countBeforeCreating = _repository.AllReadOnly<Model>().ToList().Count();

            await _modelService.CreateModelAsync(name);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, countBeforeCreating + 1);
        }


    }
}
