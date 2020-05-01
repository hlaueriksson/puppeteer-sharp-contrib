using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    [Collection(PuppeteerFixture.Name)]
    public class ProxyFactoryTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp()
        {
            await Page.SetContentAsync(Fake.Html);
        }

        [Fact]
        public void PageObject_returns_proxy_of_type()
        {
            var result = ProxyFactory.PageObject<FakePageObject>(Page, null);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);
        }

        [Fact]
        public async Task ElementObject_returns_proxy_of_type()
        {
            var elementHandle = await Page.QuerySelectorAsync(".tweet");

            var result = ProxyFactory.ElementObject<FakeElementObject>(Page, elementHandle);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);

            result = ProxyFactory.ElementObject<FakeElementObject>(Page, null);
            Assert.Null(result);
        }

        [Fact]
        public async Task ElementObject_returns_proxy_of_given_type()
        {
            var elementHandle = await Page.QuerySelectorAsync(".tweet");

            var result = ProxyFactory.ElementObject(typeof(FakeElementObject), Page, elementHandle);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);

            result = ProxyFactory.ElementObject(typeof(FakeElementObject), Page, null);
            Assert.Null(result);
        }

        [Fact]
        public async Task ElementObjectArray_returns_proxy_of_given_type()
        {
            var elementHandles = await Page.QuerySelectorAllAsync("div");

            var result = ProxyFactory.ElementObjectArray(typeof(FakeElementObject), Page, elementHandles);
            Assert.NotEmpty(result);
            Assert.All(result.Cast<ElementObject>(), x => Assert.IsAssignableFrom<FakeElementObject>(x));

            result = ProxyFactory.ElementObjectArray(typeof(FakeElementObject), Page, new ElementHandle[0]);
            Assert.Empty(result);
        }
    }
}
