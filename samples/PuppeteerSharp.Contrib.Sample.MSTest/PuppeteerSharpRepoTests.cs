using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Input;

namespace PuppeteerSharp.Contrib.Sample
{
    [TestClass]
    public class PuppeteerSharpRepoTests
    {
        private Browser Browser { get; set; }

        [TestInitialize]
        public async Task TestInitialize()
        {
            await new BrowserFetcher().DownloadAsync();
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            await Browser.CloseAsync();
        }

        [TestMethod]
        public async Task Should_be_first_search_result_on_GitHub()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/");
            var heading = await page.QuerySelectorAsync("main h1");
            await heading.ShouldHaveContentAsync("Let’s build");

            var input = await page.QuerySelectorAsync("#query-builder-test");
            if (await input.IsHiddenAsync())
            {
                await page.ClickAsync("[aria-label=\"Toggle navigation\"][data-view-component=\"true\"]");
                await page.ClickAsync("[data-target=\"qbsearch-input.inputButtonText\"]");
            }
            await input.TypeAsync("Puppeteer Sharp");
            await page.Keyboard.PressAsync(Key.Enter);
            await page.WaitForSelectorAsync("[data-testid=\"results-list\"]");

            var repositories = await page.QuerySelectorAllAsync("[data-testid=\"results-list\"] > div");
            Assert.IsTrue(repositories.Length > 0);
            var repository = repositories.First();
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            var text = await repository.QuerySelectorAsync("h3 + div");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.QuerySelectorAsync("a");
            await link.ClickAsync();
            await page.WaitForSelectorAsync("article > h1");

            heading = await page.QuerySelectorAsync("article > h1");
            await heading.ShouldHaveContentAsync("Puppeteer Sharp");
            Assert.AreEqual("https://github.com/hardkoded/puppeteer-sharp", page.Url);
        }

        [TestMethod]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            await page.ClickAsync("#actions-tab");
            await page.WaitForSelectorAsync("#partial-actions-workflow-runs");

            var status = await page.QuerySelectorAsync(".checks-list-item-icon svg");
            var label = await status.GetAttributeAsync("aria-label");
            Assert.AreEqual("completed successfully", label);
        }

        [TestMethod]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await GetLatestReleaseVersion();

            await page.GoToAsync("https://github.com/puppeteer/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            Assert.AreEqual(puppeteerVersion, puppeteerSharpVersion);

            async Task<string> GetLatestReleaseVersion()
            {
                var latest = await page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v?\d+\.\d\.\d");
                var version = await latest.TextContentAsync();
                return version.Substring(version.LastIndexOf('v') + 1);
            }
        }
    }
}
