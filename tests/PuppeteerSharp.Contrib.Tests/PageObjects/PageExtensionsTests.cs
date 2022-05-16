using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    [Collection(PuppeteerFixture.Name)]
    public class PageExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync(Fake.Html);

        // PageObject

        [Fact]
        public async Task GoToAsync_returns_proxy_of_type()
        {
            var result = await Page.GoToAsync<FakePageObject>("about:blank", new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank", WaitUntilNavigation.Load);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank", (int) TimeSpan.FromSeconds(10).TotalMilliseconds, new[] { WaitUntilNavigation.Load });
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("https://github.com/hardkoded/puppeteer-sharp");
            Assert.NotNull(result.Page);
            Assert.NotNull(result.Response);
        }

        [Fact]
        public async Task WaitForNavigationAsync_returns_proxy_of_type()
        {
            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Page.ClickAsync("h2 > strong > a");
            var result = await Page.WaitForNavigationAsync<FakePageObject>(new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);
        }

        // ElementObject

        [Fact]
        public async Task QuerySelectorAllAsync_returns_proxies_of_type()
        {
            var result = await Page.QuerySelectorAllAsync<FakeElementObject>("div");
            Assert.NotEmpty(result);
            Assert.All(result, x => Assert.IsAssignableFrom<FakeElementObject>(x));

            result = await Page.QuerySelectorAllAsync<FakeElementObject>(".missing");
            Assert.Empty(result);
        }

        [Fact]
        public async Task QuerySelectorAsync_returns_proxy_of_type()
        {
            var result = await Page.QuerySelectorAsync<FakeElementObject>(".tweet");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);

            result = await Page.QuerySelectorAsync<FakeElementObject>(".missing");
            Assert.Null(result);
        }

        [Fact]
        public async Task WaitForSelectorAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForSelectorAsync<FakeElementObject>(".tweet", new WaitForSelectorOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);

            result = await Page.WaitForSelectorAsync<FakeElementObject>(".tweet");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);
        }

        [Fact]
        public async Task WaitForXPathAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForXPathAsync<FakeElementObject>("//div[1]", new WaitForSelectorOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);

            result = await Page.WaitForXPathAsync<FakeElementObject>("//div[1]");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);
        }

        [Fact]
        public async Task XPathAsync_returns_proxies_of_type()
        {
            var result = await Page.XPathAsync<FakeElementObject>("//div");
            Assert.NotEmpty(result);
            Assert.All(result, x => Assert.IsAssignableFrom<FakeElementObject>(x));

            result = await Page.XPathAsync<FakeElementObject>("//missing");
            Assert.Empty(result);
        }
    }
}
