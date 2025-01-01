using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class ElementHandleExtensionsTests : PuppeteerPageBaseTest
    {
        private IElementHandle _elementHandle;

        protected override async Task SetUp()
        {
            await Page.SetContentAsync(Fake.Html);
            _elementHandle = await Page.QuerySelectorAsync("html");
        }

        [Test]
        public async Task To_returns_proxy_of_type()
        {
            var element = await _elementHandle.QuerySelectorAsync(".tweet");
            var result = element.To<FakeElementObject>();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());
            Assert.That(result.Page, Is.Not.Null);
            Assert.That(result.Element, Is.Not.Null);

            Assert.Throws<ArgumentNullException>(() => ((IElementHandle)null).To<FakeElementObject>());
        }

        [Test]
        public async Task QuerySelectorAllAsync_returns_proxies_of_type()
        {
            var result = await _elementHandle.QuerySelectorAllAsync<FakeElementObject>("div");
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.All.InstanceOf(typeof(FakeElementObject)));
            Assert.That(result.Select(x => x.Page), Is.All.Not.Null);

            result = await _elementHandle.QuerySelectorAllAsync<FakeElementObject>(".missing");
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task QuerySelectorAsync_returns_proxy_of_type()
        {
            var result = await _elementHandle.QuerySelectorAsync<FakeElementObject>(".tweet");
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());
            Assert.That(result.Page, Is.Not.Null);

            result = await _elementHandle.QuerySelectorAsync<FakeElementObject>(".missing");
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task XPathAsync_returns_proxies_of_type()
        {
            var result = await _elementHandle.XPathAsync<FakeElementObject>("//div");
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.All.InstanceOf(typeof(FakeElementObject)));
            Assert.That(result.Select(x => x.Page), Is.All.Not.Null);

            result = await _elementHandle.XPathAsync<FakeElementObject>("//missing");
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task WaitForSelectorAsync_returns_proxy_of_type()
        {
            var result = await _elementHandle.WaitForSelectorAsync<FakeElementObject>(".tweet");
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());
            Assert.That(result.Page, Is.Not.Null);

            Assert.ThrowsAsync<WaitTaskTimeoutException>(async () => await _elementHandle.WaitForSelectorAsync<FakeElementObject>(".missing", new() { Timeout = 1 }));
        }
    }
}
