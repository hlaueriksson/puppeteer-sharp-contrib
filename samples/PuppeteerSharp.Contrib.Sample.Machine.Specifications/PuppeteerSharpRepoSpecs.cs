using System.Linq;
using Machine.Specifications;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Sample
{
    [Subject("PuppeteerSharp")]
    public class PuppeteerSharpRepoSpecs
    {
        static Browser Browser;

        Establish context = () =>
        {
            new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision).Await();
            Browser = Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            }).Await();
        };

        Cleanup after = () => Browser.CloseAsync().Await();

        class When_searching_for_the_repo_on_GitHub
        {
            It should_be_the_first_search_result = () =>
            {
                Page page = Browser.NewPageAsync().Await();

                page.GoToAsync("https://github.com/").Await();
                page.QuerySelectorAsync("h1").ShouldHaveContent("Built for developers");

                ElementHandle input = page.QuerySelectorAsync("input.header-search-input").Await();
                if (input.IsHidden()) page.ClickAsync(".octicon-three-bars").Await();
                page.TypeAsync("input.header-search-input", "Puppeteer Sharp").Await();
                page.Keyboard.PressAsync("Enter").Await();
                page.WaitForNavigationAsync().Await();

                ElementHandle[] repositories = page.QuerySelectorAllAsync(".repo-list-item").Await();
                repositories.Length.ShouldBeGreaterThan(0);
                var repository = repositories.First();
                repository.ShouldHaveContent("hardkoded/puppeteer-sharp");
                ElementHandle text = repository.QuerySelectorAsync("p").Await();
                text.ShouldHaveContent("Headless Chrome .NET API");
                ElementHandle link = repository.QuerySelectorAsync("a").Await();
                link.ClickAsync().Await();
                page.WaitForNavigationAsync().Await();

                page.QuerySelectorAsync("article > h1").ShouldHaveContent("Puppeteer Sharp");
                page.Url.ShouldEqual("https://github.com/hardkoded/puppeteer-sharp");
            };
        }

        class When_viewing_the_repo_on_GitHub
        {
            It should_have_successful_build_status = () =>
            {
                Page page = Browser.NewPageAsync().Await();

                page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp").Await();

                ElementHandle build = page.QuerySelectorAsync("img[alt='Build status']").Await();
                build.ClickAsync().Await();
                page.WaitForNavigationAsync(new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } }).Await();

                ElementHandle success = page.QuerySelectorAsync(".project-build.project-build-status.success").Await();
                success.ShouldExist();
            };

            It should_be_up_to_date_with_the_Puppeteer_version = () =>
            {
                Page page = Browser.NewPageAsync().Await();

                page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp").Await();
                var puppeteerSharpVersion = GetLatestReleaseVersion();

                page.GoToAsync("https://github.com/GoogleChrome/puppeteer").Await();
                var puppeteerVersion = GetLatestReleaseVersion();

                puppeteerSharpVersion.ShouldEqual(puppeteerVersion);

                string GetLatestReleaseVersion()
                {
                    ElementHandle releases = page.QuerySelectorWithContentAsync("a", "releases").Await();
                    releases.ClickAsync().Await();
                    page.WaitForNavigationAsync().Await();

                    ElementHandle latest = page.QuerySelectorAsync(".release .release-header a").Await();
                    return VersionWithoutPatch(latest.TextContent());

                    string VersionWithoutPatch(string version)
                    {
                        var tokens = version.Split(".".ToCharArray());
                        return string.Join(".", tokens.Take(2));
                    }
                }
            };
        }
    }
}
