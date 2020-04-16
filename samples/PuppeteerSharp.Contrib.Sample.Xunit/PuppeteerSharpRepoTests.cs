using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using Shouldly;
using Xunit;

namespace PuppeteerSharp.Contrib.Sample
{
    public class PuppeteerSharpRepoTests : IAsyncLifetime
    {
        private Browser Browser { get; set; }

        public async Task InitializeAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
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
            page.QuerySelectorAsync("h1").ShouldHaveContent("Built for developers");

            var input = await page.QuerySelectorAsync("input.header-search-input");
            if (input.IsHidden()) await page.ClickAsync(".octicon-three-bars");
            await page.TypeAsync("input.header-search-input", "Puppeteer Sharp");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();

            var repositories = await page.QuerySelectorAllAsync(".repo-list-item");
            repositories.Length.ShouldBeGreaterThan(0);
            var repository = repositories.First();
            var link = await repository.QuerySelectorAsync("a");
            var text = await repository.QuerySelectorAsync("p");
            repository.ShouldHaveContent("hardkoded/puppeteer-sharp");
            text.ShouldHaveContent("Headless Chrome .NET API");
            await link.ClickAsync();
            await page.WaitForNavigationAsync();

            page.QuerySelectorAsync("article > h1").ShouldHaveContent("Puppeteer Sharp");
            page.Url.ShouldBe("https://github.com/hardkoded/puppeteer-sharp");
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

            await page.GoToAsync("https://github.com/GoogleChrome/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            puppeteerSharpVersion.ShouldBe(puppeteerVersion);

            async Task<string> GetLatestReleaseVersion()
            {
                var releases = await page.QuerySelectorWithContentAsync("a", "releases");
                await releases.ClickAsync();
                await page.WaitForNavigationAsync();

                var latest = await page.QuerySelectorAsync(".release .release-header a");
                return VersionWithoutPatch(latest.TextContent());

                string VersionWithoutPatch(string version)
                {
                    var tokens = version.Split(".".ToCharArray());
                    return string.Join(".", tokens.Take(2));
                }
            }
        }
    }
}