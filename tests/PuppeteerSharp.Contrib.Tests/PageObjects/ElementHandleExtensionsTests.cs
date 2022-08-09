using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    [Collection(PuppeteerFixture.Name)]
    public class ElementHandleExtensionsTests : PuppeteerPageBaseTest
    {
        private ElementHandle _elementHandle;

        protected override async Task SetUp()
        {
            await Page.SetContentAsync(Fake.Html);
            _elementHandle = await Page.QuerySelectorAsync("html");
        }

        [Fact]
        public async Task QuerySelectorAllAsync_returns_proxies_of_type()
        {
            var result = await _elementHandle.QuerySelectorAllAsync<FakeElementObject>("div");
            Assert.NotEmpty(result);
            Assert.All(result, x => Assert.IsAssignableFrom<FakeElementObject>(x));
            Assert.All(result, x => Assert.NotNull(x.Page));

            result = await _elementHandle.QuerySelectorAllAsync<FakeElementObject>(".missing");
            Assert.Empty(result);
        }

        [Fact]
        public async Task QuerySelectorAsync_returns_proxy_of_type()
        {
            var result = await _elementHandle.QuerySelectorAsync<FakeElementObject>(".tweet");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);
            Assert.NotNull(result.Page);

            result = await _elementHandle.QuerySelectorAsync<FakeElementObject>(".missing");
            Assert.Null(result);
        }

        [Fact]
        public async Task XPathAsync_returns_proxies_of_type()
        {
            var result = await _elementHandle.XPathAsync<FakeElementObject>("//div");
            Assert.NotEmpty(result);
            Assert.All(result, x => Assert.IsAssignableFrom<FakeElementObject>(x));
            Assert.All(result, x => Assert.NotNull(x.Page));

            result = await _elementHandle.XPathAsync<FakeElementObject>("//missing");
            Assert.Empty(result);
        }

        [Fact]
        public async Task WaitForSelectorAsync_returns_proxy_of_type()
        {
            var result = await _elementHandle.WaitForSelectorAsync<FakeElementObject>(".tweet");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);
            Assert.NotNull(result.Page);

            await Assert.ThrowsAsync<WaitTaskTimeoutException>(() => _elementHandle.WaitForSelectorAsync<FakeElementObject>(".missing", new() { Timeout = 1 }));
        }
    }
}
