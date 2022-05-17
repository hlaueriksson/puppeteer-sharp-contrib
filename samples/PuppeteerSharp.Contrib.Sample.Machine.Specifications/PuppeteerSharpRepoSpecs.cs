using System.Linq;
using System.Threading.Tasks;
using Machine.Specifications;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Sample
{
    [Subject("PuppeteerSharp")]
    public class PuppeteerSharpRepoSpecs
    {
        static Browser Browser;

        Establish context = async () =>
        {
            await new BrowserFetcher().DownloadAsync();
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
        };

        Cleanup after = async () => await Browser.CloseAsync();

        class When_searching_for_the_repo_on_GitHub
        {
            It should_be_the_first_search_result = async () =>
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
                repositories.Length.ShouldBeGreaterThan(0);
                var repository = repositories.First();
                await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
                var text = await repository.QuerySelectorAsync("p");
                await text.ShouldHaveContentAsync("Headless Chrome .NET API");
                var link = await repository.QuerySelectorAsync("a");
                await link.ClickAsync();
                await page.WaitForNavigationAsync();

                heading = await page.QuerySelectorAsync("article > h1");
                await heading.ShouldHaveContentAsync("Puppeteer Sharp");
                page.Url.ShouldEqual("https://github.com/hardkoded/puppeteer-sharp");
            };
        }

        class When_viewing_the_repo_on_GitHub
        {
            It should_have_successful_build_status = async () =>
            {
                var page = await Browser.NewPageAsync();

                await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

                var build = await page.QuerySelectorAsync("img[alt='Build status']");
                await build.ClickAsync();
                await page.WaitForNavigationAsync(new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

                var success = await page.QuerySelectorAsync(".project-build.project-build-status.success");
                success.ShouldExist();
            };

            It should_be_up_to_date_with_the_Puppeteer_version = async () =>
            {
                var page = await Browser.NewPageAsync();

                await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
                var puppeteerSharpVersion = await GetLatestReleaseVersion();

                await page.GoToAsync("https://github.com/puppeteer/puppeteer");
                var puppeteerVersion = await GetLatestReleaseVersion();

                puppeteerSharpVersion.ShouldEqual(puppeteerVersion);

                async Task<string> GetLatestReleaseVersion()
                {
                    var latest = await page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v?\d+\.\d\.\d");
                    var version = await latest.TextContentAsync();
                    return version.TrimStart('v');
                }
            };
        }
    }
}
