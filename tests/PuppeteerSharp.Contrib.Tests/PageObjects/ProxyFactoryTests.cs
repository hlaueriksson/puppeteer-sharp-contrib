using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class ProxyFactoryTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp()
        {
            await Page.SetContentAsync(Fake.Html);
        }

        [Test]
        public void PageObject_returns_proxy_of_type()
        {
            var result = ProxyFactory.PageObject<FakePageObject>(Page, null);

            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);
        }

        [Test]
        public async Task ElementObject_returns_proxy_of_type()
        {
            var elementHandle = await Page.QuerySelectorAsync(".tweet");

            var result = ProxyFactory.ElementObject<FakeElementObject>(Page, elementHandle);
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);

            result = ProxyFactory.ElementObject<FakeElementObject>(Page, null);
            Assert.Null(result);
        }

        [Test]
        public async Task ElementObject_returns_proxy_of_given_type()
        {
            var elementHandle = await Page.QuerySelectorAsync(".tweet");

            var result = ProxyFactory.ElementObject(typeof(FakeElementObject), Page, elementHandle);
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);

            result = ProxyFactory.ElementObject(typeof(FakeElementObject), Page, null);
            Assert.Null(result);
        }

        [Test]
        public async Task ElementObjectArray_returns_proxy_of_given_type()
        {
            var elementHandles = await Page.QuerySelectorAllAsync("div");

            var result = ProxyFactory.ElementObjectArray(typeof(FakeElementObject), Page, elementHandles);
            Assert.IsNotEmpty(result);
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(FakeElementObject));

            result = ProxyFactory.ElementObjectArray(typeof(FakeElementObject), Page, []);
            Assert.IsEmpty(result);
        }
    }
}
