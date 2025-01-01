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

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());
        }

        [Test]
        public async Task ElementObject_returns_proxy_of_type()
        {
            var elementHandle = await Page.QuerySelectorAsync(".tweet");

            var result = ProxyFactory.ElementObject<FakeElementObject>(Page, elementHandle);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());

            result = ProxyFactory.ElementObject<FakeElementObject>(Page, null);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ElementObject_returns_proxy_of_given_type()
        {
            var elementHandle = await Page.QuerySelectorAsync(".tweet");

            var result = ProxyFactory.ElementObject(typeof(FakeElementObject), Page, elementHandle);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());

            result = ProxyFactory.ElementObject(typeof(FakeElementObject), Page, null);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ElementObjectArray_returns_proxy_of_given_type()
        {
            var elementHandles = await Page.QuerySelectorAllAsync("div");

            var result = ProxyFactory.ElementObjectArray(typeof(FakeElementObject), Page, elementHandles);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.All.InstanceOf(typeof(FakeElementObject)));

            result = ProxyFactory.ElementObjectArray(typeof(FakeElementObject), Page, []);
            Assert.That(result, Is.Empty);
        }
    }
}
