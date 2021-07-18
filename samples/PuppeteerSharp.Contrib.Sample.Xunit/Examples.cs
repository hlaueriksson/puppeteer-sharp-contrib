using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using Xunit;

namespace PuppeteerSharp.Documentation
{
    public class Examples : IAsyncLifetime
    {
        private Browser _browser;
        private Page _page;

        public async Task InitializeAsync()
        {
            await new BrowserFetcher().DownloadAsync();
            _browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            _page = await _browser.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            await _page.CloseAsync();
            await _browser.CloseAsync();
        }

        [Fact]
        public async Task using_Browser()
        {
            var options = new LaunchOptions { Headless = true };
            await using var browser = await Puppeteer.LaunchAsync(options);
            // ...
        }

        [Fact]
        public async Task using_Page()
        {
            var options = new LaunchOptions { Headless = true };
            await using var browser = await Puppeteer.LaunchAsync(options);
            await using var page = await browser.NewPageAsync();
            // ...
        }

        [Fact]
        public async Task navigation()
        {
            await _page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await _page.GoBackAsync();
            await _page.GoForwardAsync();
            await _page.ReloadAsync();
        }

        [Fact]
        public async Task timeout()
        {
            var timeout = (int) TimeSpan.FromSeconds(30).TotalMilliseconds; // default value
            _page.DefaultNavigationTimeout = timeout;
            _page.DefaultTimeout = timeout;
            var options = new NavigationOptions { Timeout = timeout };

            await _page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp", options);
            await _page.GoBackAsync(options);
            await _page.GoForwardAsync(options);
            await _page.ReloadAsync(options);
        }

        [Fact]
        public async Task wait()
        {
            var timeout = (int) TimeSpan.FromSeconds(3).TotalMilliseconds;

            var requestTask = _page.WaitForRequestAsync("https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions { Timeout = timeout });
            var responseTask = _page.WaitForResponseAsync("https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions { Timeout = timeout });
            await _page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Task.WhenAll(requestTask, responseTask);

            await _page.ClickAsync("h1 > strong > a");
            await _page.WaitForNavigationAsync(new NavigationOptions { Timeout = timeout });

            await _page.WaitForExpressionAsync("1 + 1 === 2", new WaitForFunctionOptions { Timeout = timeout });
            await _page.WaitForFunctionAsync("() => window.location.href === 'https://github.com/hardkoded/puppeteer-sharp'", new WaitForFunctionOptions { Timeout = timeout });
            await _page.WaitForSelectorAsync("#readme", new WaitForSelectorOptions { Timeout = timeout });
            await _page.WaitForXPathAsync("//*[@id='readme']", new WaitForSelectorOptions { Timeout = timeout });
            await _page.WaitForTimeoutAsync(timeout);

            // WaitUntilNavigation
            new NavigationOptions().WaitUntil = new[]
            {
                WaitUntilNavigation.Load,
                WaitUntilNavigation.DOMContentLoaded,
                WaitUntilNavigation.Networkidle0,
                WaitUntilNavigation.Networkidle2
            };

            // Frame
            var frame = _page.MainFrame;

            await frame.WaitForExpressionAsync("1 + 1 === 2", new WaitForFunctionOptions { Timeout = timeout });
            await frame.WaitForFunctionAsync("() => window.location.href === 'https://github.com/hardkoded/puppeteer-sharp'", new WaitForFunctionOptions { Timeout = timeout });
            await frame.WaitForSelectorAsync("#readme", new WaitForSelectorOptions { Timeout = timeout });
            await frame.WaitForXPathAsync("//*[@id='readme']", new WaitForSelectorOptions { Timeout = timeout });
            await frame.WaitForTimeoutAsync(timeout);
        }

        [Fact]
        public async Task values_from_Page()
        {
            var url = _page.Url;
            var title = await _page.GetTitleAsync();
            var content = await _page.GetContentAsync();
            var cookies = await _page.GetCookiesAsync();
        }

        [Fact]
        public async Task form()
        {
            await _page.GoToAsync("https://www.techlistic.com/p/selenium-practice-form.html");

            // input / text
            await _page.TypeAsync("input[name='firstname']", "Puppeteer");

            // input / radio
            await _page.ClickAsync("#exp-6");

            // input / checkbox
            await _page.ClickAsync("#profession-1");

            // select / option
            await _page.SelectAsync("#continents", "Europe");

            // input / file
            var file = await _page.QuerySelectorAsync("#photo");
            await file.UploadFileAsync(@"c:\temp\test.jpg");

            // button
            await _page.ClickAsync("#submit");
        }

        [Fact]
        public async Task query()
        {
            await _page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            var element = await _page.QuerySelectorAsync("div#readme");
            var elements = await _page.QuerySelectorAllAsync("div");
            Assert.NotNull(element);
            Assert.NotEmpty(elements);

            var missingElement = await _page.QuerySelectorAsync("div#missing");
            var missingElements = await _page.QuerySelectorAllAsync("div.missing");
            Assert.Null(missingElement);
            Assert.Empty(missingElements);

            var elementInElement = await element.QuerySelectorAsync("h1");
            var elementsInElement = await element.QuerySelectorAllAsync("h1");
            Assert.NotNull(elementInElement);
            Assert.NotEmpty(elementsInElement);
        }

        [Fact]
        public async Task evaluate()
        {
            await _page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var element = await _page.QuerySelectorAsync("h1 > strong > a");

            var outerHtml = await element.EvaluateFunctionAsync<string>("e => e.outerHTML");
            var innerText = await element.EvaluateFunctionAsync<string>("e => e.innerText");
            var url = await element.EvaluateFunctionAsync<string>("e => e.getAttribute('href')");
            var hasContent = await element.EvaluateFunctionAsync<bool>("(e, value) => e.textContent.includes(value)", "puppeteer-sharp");
            Assert.Equal("<a data-pjax=\"#js-repo-pjax-container\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>", outerHtml);
            Assert.Equal("puppeteer-sharp", innerText);
            Assert.Equal("/hardkoded/puppeteer-sharp", url);
            Assert.True(hasContent);

            outerHtml = await _page.EvaluateFunctionAsync<string>("e => e.outerHTML", element);
            innerText = await _page.EvaluateFunctionAsync<string>("e => e.innerText", element);
            url = await _page.EvaluateFunctionAsync<string>("e => e.getAttribute('href')", element);
            hasContent = await _page.EvaluateFunctionAsync<bool>("(e, value) => e.textContent.includes(value)", element, "puppeteer-sharp");
            Assert.Equal("<a data-pjax=\"#js-repo-pjax-container\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>", outerHtml);
            Assert.Equal("puppeteer-sharp", innerText);
            Assert.Equal("/hardkoded/puppeteer-sharp", url);
            Assert.True(hasContent);

            outerHtml = await _page.EvaluateExpressionAsync<string>($"document.querySelector({"'h1 > strong > a'"}).outerHTML");
            innerText = await _page.EvaluateExpressionAsync<string>($"document.querySelector({"'h1 > strong > a'"}).innerText");
            url = await _page.EvaluateExpressionAsync<string>($"document.querySelector({"'h1 > strong > a'"}).getAttribute('href')");
            hasContent = await _page.EvaluateExpressionAsync<bool>($"document.querySelector({"'h1 > strong > a'"}).textContent.includes({"'puppeteer-sharp'"})");
            Assert.Equal("<a data-pjax=\"#js-repo-pjax-container\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>", outerHtml);
            Assert.Equal("puppeteer-sharp", innerText);
            Assert.Equal("/hardkoded/puppeteer-sharp", url);
            Assert.True(hasContent);

            outerHtml = await (await element.GetPropertyAsync("outerHTML")).JsonValueAsync<string>();
            innerText = await (await element.GetPropertyAsync("innerText")).JsonValueAsync<string>();
            url = await (await element.GetPropertyAsync("href")).JsonValueAsync<string>();
            hasContent = await (await element.GetPropertyAsync("textContent")).EvaluateFunctionAsync<bool>("(p, value) => p.includes(value)", "puppeteer-sharp");
            Assert.Equal("<a data-pjax=\"#js-repo-pjax-container\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>", outerHtml);
            Assert.Equal("puppeteer-sharp", innerText);
            Assert.Equal("https://github.com/hardkoded/puppeteer-sharp", url);
            Assert.True(hasContent);
        }
    }
}
