using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{

    public class PageExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync(Fake.Html);

        // PageObject

        [Test]
        public async Task GoToAsync_returns_proxy_of_type()
        {
            var result = await Page.GoToAsync<FakePageObject>("about:blank", new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank", WaitUntilNavigation.Load);
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank", (int)TimeSpan.FromSeconds(10).TotalMilliseconds, new[] { WaitUntilNavigation.Load });
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank");
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("https://github.com/hardkoded/puppeteer-sharp");
            Assert.NotNull(result.Page);
            Assert.NotNull(result.Response);
        }

        [Test]
        public async Task ReloadAsync_returns_proxy_of_type()
        {
            var result = await Page.ReloadAsync<FakePageObject>(new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);

            result = await Page.ReloadAsync<FakePageObject>((int)TimeSpan.FromSeconds(10).TotalMilliseconds, new[] { WaitUntilNavigation.Load });
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);
        }

        [Test]
        public async Task WaitForNavigationAsync_returns_proxy_of_type()
        {
            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Page.ClickAsync("#repository-container-header strong a");
            var result = await Page.WaitForNavigationAsync<FakePageObject>(new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);
        }

        [Test]
        public async Task WaitForResponseAsync_returns_proxy_of_type() // TODO: Flaky
        {
            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Page.ClickAsync("#repository-container-header strong a");
            var result = await Page.WaitForResponseAsync<FakePageObject>("https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);

            await Page.ClickAsync("#repository-container-header strong a");
            result = await Page.WaitForResponseAsync<FakePageObject>(response => response.Url == "https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);

            await Page.ClickAsync("#repository-container-header strong a");
            result = await Page.WaitForResponseAsync<FakePageObject>(async (Response response) => (await response.TextAsync()).Contains("Puppeteer Sharp"), new WaitForOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);
        }

        [Test]
        public async Task GoBackAsync_returns_proxy_of_type()
        {
            var result = await Page.GoBackAsync<FakePageObject>(new NavigationOptions());
            Assert.Null(result);

            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Page.GoToAsync("about:blank");
            result = await Page.GoBackAsync<FakePageObject>(new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);
        }

        [Test]
        public async Task GoForwardAsync_returns_proxy_of_type()
        {
            var result = await Page.GoForwardAsync<FakePageObject>(new NavigationOptions());
            Assert.Null(result);

            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Page.GoBackAsync();
            result = await Page.GoForwardAsync<FakePageObject>(new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakePageObject>(result);
        }

        // ElementObject

        [Test]
        public async Task QuerySelectorAllAsync_returns_proxies_of_type()
        {
            var result = await Page.QuerySelectorAllAsync<FakeElementObject>("div");
            Assert.IsNotEmpty(result);
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(FakeElementObject));

            result = await Page.QuerySelectorAllAsync<FakeElementObject>(".missing");
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task QuerySelectorAsync_returns_proxy_of_type()
        {
            var result = await Page.QuerySelectorAsync<FakeElementObject>(".tweet");
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);

            result = await Page.QuerySelectorAsync<FakeElementObject>(".missing");
            Assert.Null(result);
        }

        [Test]
        public async Task WaitForSelectorAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForSelectorAsync<FakeElementObject>(".tweet", new WaitForSelectorOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);

            result = await Page.WaitForSelectorAsync<FakeElementObject>(".tweet");
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);
        }

        [Test]
        public async Task WaitForXPathAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForXPathAsync<FakeElementObject>("//div[1]", new WaitForSelectorOptions());
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);

            result = await Page.WaitForXPathAsync<FakeElementObject>("//div[1]");
            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);
        }

        [Test]
        public async Task XPathAsync_returns_proxies_of_type()
        {
            var result = await Page.XPathAsync<FakeElementObject>("//div");
            Assert.IsNotEmpty(result);
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(FakeElementObject));

            result = await Page.XPathAsync<FakeElementObject>("//missing");
            Assert.IsEmpty(result);
        }
    }
}
