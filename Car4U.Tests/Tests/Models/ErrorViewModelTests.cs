using Car4U.Models;
using NUnit.Framework;

namespace Car4U.Tests.Tests.Models
{
    [TestFixture]
    public class ErrorViewModelTests
    {
        [Test]
        public void RequestIdIsNull()
        {
            ErrorViewModel viewModel = new ErrorViewModel();
            viewModel.RequestId = null;

            Assert.IsFalse(viewModel.ShowRequestId);
        }
    }
}
