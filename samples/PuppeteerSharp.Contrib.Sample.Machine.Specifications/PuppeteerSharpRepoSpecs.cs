using System.Linq;
using Machine.Specifications;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Sample
{
    [Subject("PuppeteerSharp")]
    public class PuppeteerSharpRepoSpecs
    {
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
                var page = Browser.NewPageAsync().Result();

                page.GoToAsync("https://github.com/").Await();
                page.QuerySelectorAsync("h1").ShouldHaveContent("Built for developers");

                var input = page.QuerySelectorAsync("input.header-search-input").Result();
                if (input.IsHidden()) page.ClickAsync(".octicon-three-bars").Await();
                page.TypeAsync("input.header-search-input", "Puppeteer Sharp").Await();
                page.Keyboard.PressAsync("Enter").Await();
                page.WaitForNavigationAsync().Await();

                var repositories = page.QuerySelectorAllAsync(".repo-list-item").Result();
                repositories.Length.ShouldBeGreaterThan(0);
                var repository = repositories.First();
                var link = repository.QuerySelectorAsync("a").Result();
                var text = repository.QuerySelectorAsync("p").Result();
                repository.ShouldHaveContent("kblok/puppeteer-sharp");
                text.ShouldHaveContent("Headless Chrome .NET API");
                link.ClickAsync().Await();
                page.WaitForNavigationAsync().Await();

                page.QuerySelectorAsync("article > h1").ShouldHaveContent("Puppeteer Sharp");
                page.Url.ShouldEqual("https://github.com/kblok/puppeteer-sharp");
            };
        }

        class When_viewing_the_repo_on_GitHub
        {
            It should_have_successful_build_status = () =>
            {
                var page = Browser.NewPageAsync().Result();

                page.GoToAsync("https://github.com/kblok/puppeteer-sharp").Await();

                var build = page.QuerySelectorAsync("img[alt='Build status']").Result();
                build.ClickAsync().Await();
                page.WaitForNavigationAsync(
                    new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } }).Await();

                var success = page.QuerySelectorAsync(".project-build.project-build-status.success").Result();
                success.ShouldExist();
            };

            It should_be_up_to_date_with_the_Puppeteer_version = () =>
            {
                var page = Browser.NewPageAsync().Result();

                page.GoToAsync("https://github.com/kblok/puppeteer-sharp").Await();
                var puppeteerSharpVersion = GetLatestReleaseVersion();

                page.GoToAsync("https://github.com/GoogleChrome/puppeteer").Await();
                var puppeteerVersion = GetLatestReleaseVersion();

                puppeteerSharpVersion.ShouldEqual(puppeteerVersion);

                string GetLatestReleaseVersion()
                {
                    var releases = page.QuerySelectorWithContentAsync("a", "releases").Result();
                    releases.ClickAsync().Await();
                    page.WaitForNavigationAsync().Await();

                    var latest = page.QuerySelectorAsync(".release .release-header a").Result();
                    return VersionWithoutPatch(latest.TextContent());

                    string VersionWithoutPatch(string version)
                    {
                        var tokens = version.Split(".".ToCharArray());
                        return string.Join(".", tokens.Take(2));
                    }
                }
            };
        }

        static Browser Browser;
    }
}