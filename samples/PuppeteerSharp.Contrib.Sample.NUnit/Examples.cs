using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PuppeteerSharp.Contrib.Sample
{
    public class Examples
    {
        static async Task<IBrowser> Browser()
        {
            await new BrowserFetcher().DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
            });

            // SupportedBrowser
            _ = new[] { SupportedBrowser.Chrome, SupportedBrowser.Firefox, SupportedBrowser.Chromium };

            // Platform
            _ = new[] { Platform.MacOS, Platform.MacOSArm64, Platform.Linux, Platform.Win32, Platform.Win64 };

            return browser;
        }

        [Test]
        public async Task close_Browser()
        {
            var browser = await Browser();

            await browser.CloseAsync();
        }

        [Test]
        public async Task using_Browser()
        {
            await using var browser = await Puppeteer.LaunchAsync(new());
            // ...
        }

        static async Task<IPage> Page()
        {
            var browser = await Browser();
            var page = await browser.NewPageAsync();

            return page;
        }

        [Test]
        public async Task using_Page()
        {
            await using var browser = await Puppeteer.LaunchAsync(new());
            await using var page = await browser.NewPageAsync();
            // ...
        }

        [Test]
        public async Task close_Page()
        {
            var page = await Page();

            await page.CloseAsync();
        }

        [Test]
        public async Task navigation()
        {
            var page = await Page();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await page.GoBackAsync();
            await page.GoForwardAsync();
            await page.ReloadAsync();
        }

        [Test]
        public async Task timeout()
        {
            var page = await Page();

            var timeout = (int)TimeSpan.FromSeconds(30).TotalMilliseconds; // default value
            page.DefaultNavigationTimeout = timeout;
            page.DefaultTimeout = timeout;

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp", timeout);
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp", new NavigationOptions { Timeout = timeout });
        }

        [Test]
        public async Task wait()
        {
            var page = await Page();
            var timeout = (int)TimeSpan.FromSeconds(3).TotalMilliseconds;

            var tasks = new Task[]
            {
                /*
                page.WaitForDevicePromptAsync(new() { Timeout = timeout }),
                */
                page.WaitForExpressionAsync("1 + 1 === 2", new() { Timeout = timeout }),
                /*
                page.WaitForFileChooserAsync(new() { Timeout = timeout }),
                */
                page.WaitForFrameAsync("https://github.com/hardkoded/puppeteer-sharp", new() { Timeout = timeout }),
                /*
                page.WaitForFunctionAsync("() => window.location.href === 'https://github.com/hardkoded/puppeteer-sharp'", new WaitForFunctionOptions { Timeout = timeout }),
                page.WaitForNavigationAsync(new() { Timeout = timeout }),
                page.WaitForNetworkIdleAsync(new() { Timeout = timeout }),
                */
                page.WaitForRequestAsync("https://github.com/hardkoded/puppeteer-sharp", new() { Timeout = timeout }),
                page.WaitForResponseAsync("https://github.com/hardkoded/puppeteer-sharp", new() { Timeout = timeout }),
                page.WaitForSelectorAsync("article", new() { Timeout = timeout }),
                //page.WaitForXPathAsync(), // Obsolete
            };
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Task.WhenAll(tasks);

            // Frame
            var frame = page.MainFrame;

            tasks =
            [
                /*
                frame.WaitForDevicePromptAsync(new() { Timeout = timeout }),
                */
                frame.WaitForExpressionAsync("1 + 1 === 2", new() { Timeout = timeout }),
                frame.WaitForFunctionAsync("() => window.location.href === 'https://github.com/hardkoded/puppeteer-sharp'", new WaitForFunctionOptions { Timeout = timeout }),
                frame.WaitForNavigationAsync(new() { Timeout = timeout }),
                frame.WaitForSelectorAsync("article", new() { Timeout = timeout }),
                //frame.WaitForXPathAsync(), // Obsolete
            ];
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            await Task.WhenAll(tasks);

            // WaitUntilNavigation
            _ = new[] { WaitUntilNavigation.Load, WaitUntilNavigation.DOMContentLoaded, WaitUntilNavigation.Networkidle0, WaitUntilNavigation.Networkidle2 };

            // WaitForFunctionPollingOption
            _ = new[] { WaitForFunctionPollingOption.Raf, WaitForFunctionPollingOption.Mutation };
        }

        [Test]
        public async Task values_from_Page()
        {
            var page = await Page();
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            _ = page.Url;
            await page.GetContentAsync();
            await page.GetCookiesAsync();
            await page.GetTitleAsync();

            await page.PdfDataAsync();
            await page.ScreenshotDataAsync();
        }

        [Test]
        public async Task values_from_ElementHandle()
        {
            var page = await Page();
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            var element = await page.QuerySelectorAsync("main h1");

            await element.GetPropertiesAsync();
            await element.GetPropertyAsync("href");
            await element.JsonValueAsync();

            await element.ScreenshotDataAsync();
        }

        [Test]
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
            await file.UploadFileAsync(@"..\..\..\..\..\icon.png");

            // button
            await page.ClickAsync("#submit");

            // other
            await page.BringToFrontAsync();
            await page.FocusAsync("#submit");
            await page.HoverAsync("#main");
            await page.TapAsync("#main");

            // IElementHandle
            var element = await page.QuerySelectorAsync("main");
            await element.ClickAsync();
            /*
            await element.DragAndDropAsync();
            */
            await element.FocusAsync();
            await element.HoverAsync();
            await element.PressAsync("Control");
            /*
            await element.SelectAsync();
            */
            await element.TapAsync();
            await element.TypeAsync("");
            await element.UploadFileAsync();
        }

        [Test]
        public async Task query()
        {
            var page = await Page();
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            var element = await page.QuerySelectorAsync("article");
            var elements = await page.QuerySelectorAllAsync("div");
            Assert.That(element, Is.Not.Null);
            Assert.That(elements, Is.Not.Empty);

            var missingElement = await page.QuerySelectorAsync("div#missing");
            var missingElements = await page.QuerySelectorAllAsync("div.missing");
            Assert.That(missingElement, Is.Null);
            Assert.That(missingElements, Is.Empty);

            var elementInElement = await element.QuerySelectorAsync("h1");
            var elementsInElement = await element.QuerySelectorAllAsync("h1");
            Assert.That(elementInElement, Is.Not.Null);
            Assert.That(elementsInElement, Is.Not.Empty);

            // other
            var handle = await page.QuerySelectorAllHandleAsync("article");
            await page.QueryObjectsAsync(handle);
            await element.QuerySelectorAllHandleAsync("h1");
        }

        [Test]
        public async Task evaluate()
        {
            var page = await Page();
            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            var outerHtml = await page.EvaluateExpressionAsync<string>($"document.querySelector({"'#repository-container-header strong a'"}).outerHTML");
            var innerText = await page.EvaluateExpressionAsync<string>($"document.querySelector({"'#repository-container-header strong a'"}).innerText");
            var url = await page.EvaluateExpressionAsync<string>($"document.querySelector({"'#repository-container-header strong a'"}).getAttribute('href')");
            var hasContent = await page.EvaluateExpressionAsync<bool>($"document.querySelector({"'#repository-container-header strong a'"}).textContent.includes({"'puppeteer-sharp'"})");
            Assert.That(outerHtml, Is.EqualTo("<a data-pjax=\"#repo-content-pjax-container\" data-turbo-frame=\"repo-content-turbo-frame\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>"));
            Assert.That(innerText, Is.EqualTo("puppeteer-sharp"));
            Assert.That(url, Is.EqualTo("/hardkoded/puppeteer-sharp"));
            Assert.That(hasContent);

            await page.EvaluateExpressionHandleAsync("document.body");
            await page.EvaluateExpressionOnNewDocumentAsync("document.body");
            await page.EvaluateFunctionHandleAsync("() => 1 + 1 === 2");
            await page.EvaluateFunctionOnNewDocumentAsync("() => 1 + 1 === 2");

            var element = await page.QuerySelectorAsync("#repository-container-header strong a");

            outerHtml = await page.EvaluateFunctionAsync<string>("e => e.outerHTML", element);
            innerText = await page.EvaluateFunctionAsync<string>("e => e.innerText", element);
            url = await page.EvaluateFunctionAsync<string>("e => e.getAttribute('href')", element);
            hasContent = await page.EvaluateFunctionAsync<bool>("(e, value) => e.textContent.includes(value)", element, "puppeteer-sharp");
            Assert.That(outerHtml, Is.EqualTo("<a data-pjax=\"#repo-content-pjax-container\" data-turbo-frame=\"repo-content-turbo-frame\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>"));
            Assert.That(innerText, Is.EqualTo("puppeteer-sharp"));
            Assert.That(url, Is.EqualTo("/hardkoded/puppeteer-sharp"));
            Assert.That(hasContent);

            outerHtml = await element.EvaluateFunctionAsync<string>("e => e.outerHTML");
            innerText = await element.EvaluateFunctionAsync<string>("e => e.innerText");
            url = await element.EvaluateFunctionAsync<string>("e => e.getAttribute('href')");
            hasContent = await element.EvaluateFunctionAsync<bool>("(e, value) => e.textContent.includes(value)", "puppeteer-sharp");
            Assert.That(outerHtml, Is.EqualTo("<a data-pjax=\"#repo-content-pjax-container\" data-turbo-frame=\"repo-content-turbo-frame\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>"));
            Assert.That(innerText, Is.EqualTo("puppeteer-sharp"));
            Assert.That(url, Is.EqualTo("/hardkoded/puppeteer-sharp"));
            Assert.That(hasContent);

            outerHtml = await (await element.GetPropertyAsync("outerHTML")).JsonValueAsync<string>();
            innerText = await (await element.GetPropertyAsync("innerText")).JsonValueAsync<string>();
            url = await (await element.GetPropertyAsync("href")).JsonValueAsync<string>();
            hasContent = await (await element.GetPropertyAsync("textContent")).EvaluateFunctionAsync<bool>("(p, value) => p.includes(value)", "puppeteer-sharp");
            Assert.That(outerHtml, Is.EqualTo("<a data-pjax=\"#repo-content-pjax-container\" data-turbo-frame=\"repo-content-turbo-frame\" href=\"/hardkoded/puppeteer-sharp\">puppeteer-sharp</a>"));
            Assert.That(innerText, Is.EqualTo("puppeteer-sharp"));
            Assert.That(url, Is.EqualTo("https://github.com/hardkoded/puppeteer-sharp"));
            Assert.That(hasContent);

            await element.EvaluateFunctionHandleAsync("() => 1 + 1 === 2");
        }

        [Test]
        public async Task is_()
        {
            var page = await Page();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            Assert.That(page.IsClosed, Is.False);
            Assert.That(page.IsJavaScriptEnabled, Is.True);
            Assert.That(page.IsServiceWorkerBypassed, Is.False);
            //page.IsDragInterceptionEnabled // Obsolete

            var frame = page.MainFrame;
            Assert.That(frame.Detached, Is.False);

            var element = page.QuerySelectorAsync("#include_email");
            Assert.That(element.IsCompleted, Is.False);
            Assert.That(element.IsCompletedSuccessfully, Is.False);
            Assert.That(element.IsCanceled, Is.False);
            Assert.That(element.IsFaulted, Is.False);
        }
    }
}
