using Car4U.ModelBinders;
using NUnit.Framework;

namespace Car4U.Tests.Tests.Binders
{
    [TestFixture]
    public class DecimalModelBinderProviderTests
    {
        private DecimalModelBinderProvider _binder;

        [OneTimeSetUp]
        public void SetUp()
        {
            _binder = new DecimalModelBinderProvider();
        }

        [Test]
        public void GetBinder_ShoulThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _binder.GetBinder(null));
        }
    }
}
