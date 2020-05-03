using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Sample
{
    [TestClass]
    public class PuppeteerSharpRepoTests
    {
        private Browser Browser { get; set; }

        [TestInitialize]
        public async Task TestInitialize()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
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
            var h1 = await page.QuerySelectorAsync("h1");
            await h1.ShouldHaveContentAsync("Built for developers");

            var input = await page.QuerySelectorAsync("input.header-search-input");
            if (await input.IsHiddenAsync()) await page.ClickAsync(".octicon-three-bars");
            await page.TypeAsync("input.header-search-input", "Puppeteer Sharp");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();

            var repositories = await page.QuerySelectorAllAsync(".repo-list-item");
            Assert.IsTrue(repositories.Length > 0);
            var repository = repositories.First();
            var link = await repository.QuerySelectorAsync("a");
            var text = await repository.QuerySelectorAsync("p");
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            await link.ClickAsync();
            await page.WaitForNavigationAsync();

            h1 = await page.QuerySelectorAsync("article > h1");
            await h1.ShouldHaveContentAsync("Puppeteer Sharp");
            Assert.AreEqual("https://github.com/hardkoded/puppeteer-sharp", page.Url);
        }

        [TestMethod]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            var build = await page.QuerySelectorAsync("img[alt='Build status']");
            await build.ClickAsync();
            await page.WaitForNavigationAsync(new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var success = await page.QuerySelectorAsync(".project-build.project-build-status.success");
            success.ShouldExist();
        }

        [TestMethod]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await GetLatestReleaseVersion();

            await page.GoToAsync("https://github.com/GoogleChrome/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            Assert.AreEqual(puppeteerVersion, puppeteerSharpVersion);

            async Task<string> GetLatestReleaseVersion()
            {
                var releases = await page.QuerySelectorWithContentAsync("a", "releases");
                await releases.ClickAsync();
                await page.WaitForNavigationAsync();

                var latest = await page.QuerySelectorAsync(".release .release-header a");
                return VersionWithoutPatch(await latest.TextContentAsync());

                string VersionWithoutPatch(string version)
                {
                    var tokens = version.Split(".".ToCharArray());
                    return string.Join(".", tokens.Take(2));
                }
            }
        }
    }
}