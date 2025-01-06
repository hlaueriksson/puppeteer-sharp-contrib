using System.Linq;
using System.Threading.Tasks;
using Machine.Specifications;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Input;

namespace PuppeteerSharp.Contrib.Sample
{
    [Subject("PuppeteerSharp")]
    public class PuppeteerSharpRepoSpecs
    {
        static IBrowser Browser;

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
                var heading = await page.QuerySelectorAsync("main h1");
                await heading.ShouldHaveContentAsync("Build and ship software on a single, collaborative platform");

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
                repositories.Length.ShouldBeGreaterThan(0);
                var repository = repositories.First();
                await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
                var text = await repository.QuerySelectorAsync("h3 + div");
                await text.ShouldHaveContentAsync("Headless Chrome .NET API");
                var link = await repository.QuerySelectorAsync("a");
                await link.ClickAsync();
                await page.WaitForSelectorAsync("article h1");

                heading = await page.QuerySelectorAsync("article h1");
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

                await page.ClickAsync("#actions-tab");
                await page.WaitForSelectorAsync("#partial-actions-workflow-runs");

                var status = await page.QuerySelectorAsync(".d-table svg");
                var label = await status.GetAttributeAsync("aria-label");
                label.ShouldContain("completed successfully");
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
                    var latest = await page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v\d+\.\d+\.\d+");
                    var version = await latest.TextContentAsync();
                    return version.Substring(version.LastIndexOf('v') + 1);
                }
            };
        }
    }
}
