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
        public void To_returns_proxy_of_type()
        {
            var result = Page.To<FakePageObject>();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());
            Assert.That(result.Page, Is.Not.Null);
            Assert.That(result.Response, Is.Null);

            Assert.Throws<ArgumentNullException>(() => ((IPage)null).To<FakePageObject>());
        }

        [Test]
        public async Task GoToAsync_returns_proxy_of_type()
        {
            var result = await Page.GoToAsync<FakePageObject>("about:blank", new NavigationOptions());
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());

            result = await Page.GoToAsync<FakePageObject>("about:blank", WaitUntilNavigation.Load);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());

            result = await Page.GoToAsync<FakePageObject>("about:blank", (int)TimeSpan.FromSeconds(10).TotalMilliseconds, [WaitUntilNavigation.Load]);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());

            result = await Page.GoToAsync<FakePageObject>("about:blank");
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());

            result = await Page.GoToAsync<FakePageObject>("https://github.com/hardkoded/puppeteer-sharp");
            Assert.That(result.Page, Is.Not.Null);
            Assert.That(result.Response, Is.Not.Null);
        }

        [Test]
        public async Task ReloadAsync_returns_proxy_of_type()
        {
            var result = await Page.ReloadAsync<FakePageObject>(new NavigationOptions());
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());

            result = await Page.ReloadAsync<FakePageObject>((int)TimeSpan.FromSeconds(10).TotalMilliseconds, [WaitUntilNavigation.Load]);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());
        }

        [Test]
        public async Task WaitForNavigationAsync_returns_proxy_of_type()
        {
            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var task = Page.WaitForNavigationAsync<FakePageObject>(new NavigationOptions());
            await Page.ClickAsync("#repository-container-header strong a");
            var result = await task;
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());
        }

        [Test]
        public async Task WaitForResponseAsync_returns_proxy_of_type()
        {
            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var task = Page.WaitForResponseAsync<FakePageObject>("https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions());
            await Page.ClickAsync("#repository-container-header strong a");
            var result = await task;
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());

            task = Page.WaitForResponseAsync<FakePageObject>(response => response.Url == "https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions());
            await Page.ClickAsync("#repository-container-header strong a");
            result = await task;
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());

            task = Page.WaitForResponseAsync<FakePageObject>(async (IResponse response) =>
            {
                await Task.Delay(1);
                return response.Url == "https://github.com/hardkoded/puppeteer-sharp";
            }, new WaitForOptions());
            await Page.ClickAsync("#repository-container-header strong a");
            result = await task;
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());
        }

        [Test]
        public async Task GoBackAsync_returns_proxy_of_type()
        {
            var result = await Page.GoBackAsync<FakePageObject>(new NavigationOptions());
            Assert.That(result, Is.Null);

            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Page.GoToAsync("about:blank");
            result = await Page.GoBackAsync<FakePageObject>(new NavigationOptions());
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());
        }

        [Test]
        public async Task GoForwardAsync_returns_proxy_of_type()
        {
            var result = await Page.GoForwardAsync<FakePageObject>(new NavigationOptions());
            Assert.That(result, Is.Null);

            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Page.GoBackAsync();
            result = await Page.GoForwardAsync<FakePageObject>(new NavigationOptions());
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakePageObject>());
        }

        // ElementObject

        [Test]
        public async Task QuerySelectorAllAsync_returns_proxies_of_type()
        {
            var result = await Page.QuerySelectorAllAsync<FakeElementObject>("div");
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.All.InstanceOf(typeof(FakeElementObject)));

            result = await Page.QuerySelectorAllAsync<FakeElementObject>(".missing");
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task QuerySelectorAsync_returns_proxy_of_type()
        {
            var result = await Page.QuerySelectorAsync<FakeElementObject>(".tweet");
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());

            result = await Page.QuerySelectorAsync<FakeElementObject>(".missing");
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task WaitForSelectorAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForSelectorAsync<FakeElementObject>(".tweet", new WaitForSelectorOptions());
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());

            result = await Page.WaitForSelectorAsync<FakeElementObject>(".tweet");
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());
        }

        [Test]
        public async Task WaitForXPathAsync_returns_proxy_of_type()
        {
            var result = await Page.WaitForXPathAsync<FakeElementObject>("//div[1]", new WaitForSelectorOptions());
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());

            result = await Page.WaitForXPathAsync<FakeElementObject>("//div[1]");
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());
        }

        [Test]
        public async Task XPathAsync_returns_proxies_of_type()
        {
            var result = await Page.XPathAsync<FakeElementObject>("//div");
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.All.InstanceOf(typeof(FakeElementObject)));

            result = await Page.XPathAsync<FakeElementObject>("//missing");
            Assert.That(result, Is.Empty);
        }
    }
}
