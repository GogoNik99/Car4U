using Car4U.Core.Contracts;
using Car4U.Core.Services;
using NUnit.Framework;

namespace Car4U.Tests.Tests.ServicesTests
{
    [TestFixture]
    public class ImageServiceTests
    {
        private IImageService _imageService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _imageService = new ImageService();
        }

        [Test]
        public void DeleteImage()
        {
            string path = @"../../../Tests/ImageRepo";
            string fileNameToCopy = "image1.jpg";
            string fileName = "testImage.jpg";

            File.Copy($"{path}/{fileNameToCopy}", $"{path}/{fileName}");

            _imageService.DeleteImg(fileName, path);

            bool result = File.Exists($"{path}/{fileName}");

            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteImage_ShouldDoNothing()
        {
            string path = @"../../../Tests/ImageRepo";
            string fileName = "test.jpg";

            _imageService.DeleteImg(null, path);

            bool result = File.Exists($"{path}/{fileName}");

            Assert.IsTrue(result);
        }
    }
}
