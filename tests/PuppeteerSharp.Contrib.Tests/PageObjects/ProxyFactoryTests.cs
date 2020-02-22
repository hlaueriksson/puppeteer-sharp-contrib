using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    [Collection(PuppeteerFixture.Name)]
    public class ProxyFactoryTests : PuppeteerPageBaseTest
    {
        [Fact]
        public void PageObject_returns_proxy_of_type()
        {
            var result = ProxyFactory.PageObject<FakePageObject>(Page, null);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);
        }

        [Fact]
        public void ElementObject_returns_proxy_of_type()
        {
            var result = ProxyFactory.ElementObject<FakeElementObject>(Page, null);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);
        }

        [Fact]
        public void ElementObject_returns_proxy_of_given_type()
        {
            var result = ProxyFactory.ElementObject(typeof(FakeElementObject), Page, null);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);
        }
    }
}