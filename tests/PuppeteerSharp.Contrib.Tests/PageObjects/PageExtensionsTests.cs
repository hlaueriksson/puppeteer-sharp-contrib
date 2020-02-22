using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    [Collection(PuppeteerFixture.Name)]
    public class PageExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync(Fake.Html);

        [Fact]
        public async Task GoToAsync_returns_proxy_of_type()
        {
            var result = await Page.GoToAsync<FakePageObject>("about:blank", new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank", WaitUntilNavigation.Load);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank", TimeSpan.FromSeconds(10).Milliseconds, new[] { WaitUntilNavigation.Load });
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.GoToAsync<FakePageObject>("about:blank");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);
        }

        [Fact(Skip = "Needs navigation")]
        public async Task WaitForNavigationAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForNavigationAsync<FakePageObject>(new NavigationOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);
        }

        [Fact(Skip = "Needs response")]
        public async Task WaitForResponseAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForResponseAsync<FakePageObject>(response => response.Ok, new WaitForOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);

            result = await Page.WaitForResponseAsync<FakePageObject>("about:blank", new WaitForOptions());
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakePageObject>(result);
        }

        [Fact]
        public async Task QuerySelectorAsync_returns_proxy_of_type()
        {
            var result = await Page.QuerySelectorAsync<FakeElementObject>(".tweet");
            Assert.NotNull(result);
            Assert.IsAssignableFrom<FakeElementObject>(result);
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
    }
}