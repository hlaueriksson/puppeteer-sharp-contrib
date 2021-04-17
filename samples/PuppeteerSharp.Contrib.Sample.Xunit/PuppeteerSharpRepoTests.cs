using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using Xunit;

namespace PuppeteerSharp.Contrib.Sample
{
    public class PuppeteerSharpRepoTests : IAsyncLifetime
    {
        private Browser Browser { get; set; }

        public async Task InitializeAsync()
        {
            await new BrowserFetcher().DownloadAsync();
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
        }

        public async Task DisposeAsync()
        {
            await Browser.CloseAsync();
        }

        [Fact]
        public async Task Should_be_first_search_result_on_GitHub()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/");
            var heading = await page.QuerySelectorAsync("h1");
            await heading.ShouldHaveContentAsync("Where the world builds software");

            var input = await page.QuerySelectorAsync("input.header-search-input");
            if (await input.IsHiddenAsync()) await page.ClickAsync(".octicon-three-bars");
            await page.TypeAsync("input.header-search-input", "Puppeteer Sharp");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();

            var repositories = await page.QuerySelectorAllAsync(".repo-list-item");
            Assert.NotEmpty(repositories);
            var repository = repositories.First();
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            var text = await repository.QuerySelectorAsync("p");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.QuerySelectorAsync("a");
            await link.ClickAsync();
            await page.WaitForNavigationAsync();

            heading = await page.QuerySelectorAsync("article > h1");
            await heading.ShouldHaveContentAsync("Puppeteer Sharp");
            Assert.Equal("https://github.com/hardkoded/puppeteer-sharp", page.Url);
        }

        [Fact]
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

        [Fact]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await GetLatestReleaseVersion();

            await page.GoToAsync("https://github.com/puppeteer/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            Assert.Equal(puppeteerVersion, puppeteerSharpVersion);

            async Task<string> GetLatestReleaseVersion()
            {
                var latest = await page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v\d\.\d\.\d");
                return await latest.TextContentAsync();
            }
        }
    }
}
