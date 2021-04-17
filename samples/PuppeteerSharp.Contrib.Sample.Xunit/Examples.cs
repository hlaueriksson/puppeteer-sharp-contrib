using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using Xunit;

namespace PuppeteerSharp.Documentation
{
    public class Examples
    {
        [Fact]
        public async Task download_Browser()
        {
            await new BrowserFetcher().DownloadAsync();
        }

        [Fact]
        public async Task<Browser> Browser()
        {
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            return browser;
        }

        [Fact]
        public async Task close_Browser()
        {
            var browser = await Browser();

            await browser.CloseAsync();
        }

        [Fact]
        public async Task using_Browser()
        {
            var options = new LaunchOptions { Headless = true };
            using (var browser = await Puppeteer.LaunchAsync(options))
            {
                // ...
            }
        }

        [Fact]
        public async Task<Page> Page()
        {
            var browser = await Browser();
            var page = await browser.NewPageAsync();

            return page;
        }

        [Fact]
        public async Task close_Page()
        {
            var page = await Page();

            await page.CloseAsync();
        }

        [Fact]
        public async Task using_Page()
        {
            var browser = await Browser();

            using (var page = await browser.NewPageAsync())
            {
                // ...
            }
        }

        [Fact]
        public async Task navigation()
        {
            var page = await Page();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await page.GoBackAsync();
            await page.GoForwardAsync();
            await page.ReloadAsync();
        }

        [Fact]
        public async Task timeout()
        {
            var page = await Page();

            var timeout = (int) TimeSpan.FromSeconds(30).TotalMilliseconds; // default value
            page.DefaultNavigationTimeout = timeout;
            page.DefaultTimeout = timeout;
            var options = new NavigationOptions { Timeout = timeout };

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp", options);
            await page.GoBackAsync(options);
            await page.GoForwardAsync(options);
            await page.ReloadAsync(options);
        }

        [Fact]
        public async Task wait()
        {
            var page = await Page();
            var timeout = (int) TimeSpan.FromSeconds(3).TotalMilliseconds;

            var requestTask = page.WaitForRequestAsync("https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions { Timeout = timeout });
            var responseTask = page.WaitForResponseAsync("https://github.com/hardkoded/puppeteer-sharp", new WaitForOptions { Timeout = timeout });
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Task.WhenAll(requestTask, responseTask);

            await page.ClickAsync("h1 > strong > a");
            await page.WaitForNavigationAsync(new NavigationOptions { Timeout = timeout });

            await page.WaitForExpressionAsync("1 + 1 === 2", new WaitForFunctionOptions { Timeout = timeout });
            await page.WaitForFunctionAsync("() => window.location.href === 'https://github.com/hardkoded/puppeteer-sharp'", new WaitForFunctionOptions { Timeout = timeout });
            await page.WaitForSelectorAsync("#readme", new WaitForSelectorOptions { Timeout = timeout });
            await page.WaitForXPathAsync("//*[@id='readme']", new WaitForSelectorOptions { Timeout = timeout });
            await page.WaitForTimeoutAsync(timeout);

            // WaitUntilNavigation
            new NavigationOptions().WaitUntil = new[]
            {
                WaitUntilNavigation.Load,
                WaitUntilNavigation.DOMContentLoaded,
                WaitUntilNavigation.Networkidle0,
                WaitUntilNavigation.Networkidle2
            };

            // Frame
            var frame = page.MainFrame;

            await frame.WaitForExpressionAsync("1 + 1 === 2", new WaitForFunctionOptions { Timeout = timeout });
            await frame.WaitForFunctionAsync("() => window.location.href === 'https://github.com/hardkoded/puppeteer-sharp'", new WaitForFunctionOptions { Timeout = timeout });
            await frame.WaitForSelectorAsync("#readme", new WaitForSelectorOptions { Timeout = timeout });
            await frame.WaitForXPathAsync("//*[@id='readme']", new WaitForSelectorOptions { Timeout = timeout });
            await frame.WaitForTimeoutAsync(timeout);
        }

        [Fact]
        public async Task values_from_Page()
        {
            var page = await Page();

            var url = page.Url;
            var title = await page.GetTitleAsync();
            var content = await page.GetContentAsync();
            var cookies = await page.GetCookiesAsync();
        }

        [Fact]
        public async Task form()
        {
            var page = await Page();
            await page.GoToAsync("https://www.techlistic.com/p/selenium-practice-form.html");

            // input / text
            await page.TypeAsync("input[name='firstname']", "Puppeteer");

            // input / radio
            await page.ClickAsync("#exp-6");

            // input / checkbox
            await page.ClickAsync("#profession-1");

            // select / option
            await page.SelectAsync("#continents", "Europe");

            // input / file
            var file = await page.QuerySelectorAsync("#photo");
            await file.UploadFileAsync(@"c:\temp\test.jpg");

            // button
            await page.ClickAsync("#submit");
        }

        [Fact]
        public async Task query()
        {
            var page = await Page();
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            var element = await page.QuerySelectorAsync("div#readme");
            var elements = await page.QuerySelectorAllAsync("div");
            Assert.NotNull(element);
            Assert.NotEmpty(elements);

            var missingElement = await page.QuerySelectorAsync("div#missing");
            var missingElements = await page.QuerySelectorAllAsync("div.missing");
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
            var page = await Page();
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var element = await page.QuerySelectorAsync("h1 > strong > a");

            var outerHtml = await element.EvaluateFunctionAsync<string>("e => e.outerHTML");
            var innerText = await element.EvaluateFunctionAsync<string>("e => e.innerText");
            var url = await element.EvaluateFunctionAsync<string>("e => e.getAttribute('href')");
            var hasContent = await element.EvaluateFunctionAsync<bool>("(e, value) => e.textContent.includes(value)", "puppeteer-sharp");
            Assert.Equal("<a data-pjax=\"#js-repo-pjax-container\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>", outerHtml);
            Assert.Equal("puppeteer-sharp", innerText);
            Assert.Equal("/hardkoded/puppeteer-sharp", url);
            Assert.True(hasContent);

            outerHtml = await page.EvaluateFunctionAsync<string>("e => e.outerHTML", element);
            innerText = await page.EvaluateFunctionAsync<string>("e => e.innerText", element);
            url = await page.EvaluateFunctionAsync<string>("e => e.getAttribute('href')", element);
            hasContent = await page.EvaluateFunctionAsync<bool>("(e, value) => e.textContent.includes(value)", element, "puppeteer-sharp");
            Assert.Equal("<a data-pjax=\"#js-repo-pjax-container\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>", outerHtml);
            Assert.Equal("puppeteer-sharp", innerText);
            Assert.Equal("/hardkoded/puppeteer-sharp", url);
            Assert.True(hasContent);

            outerHtml = await page.EvaluateExpressionAsync<string>($"document.querySelector({"'h1 > strong > a'"}).outerHTML");
            innerText = await page.EvaluateExpressionAsync<string>($"document.querySelector({"'h1 > strong > a'"}).innerText");
            url = await page.EvaluateExpressionAsync<string>($"document.querySelector({"'h1 > strong > a'"}).getAttribute('href')");
            hasContent = await page.EvaluateExpressionAsync<bool>($"document.querySelector({"'h1 > strong > a'"}).textContent.includes({"'puppeteer-sharp'"})");
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
