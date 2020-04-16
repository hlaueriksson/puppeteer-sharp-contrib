using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Contrib.Should;
using Shouldly;

namespace PuppeteerSharp.Contrib.Sample
{
    public class PuppeteerSharpRepoTests
    {
        private Browser Browser { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
        }

        [Test]
        public async Task Should_be_first_search_result_on_GitHub()
        {
            var page = await Browser.NewPageAsync();

            var startPage = await page.GoToAsync<GitHubStartPage>("https://github.com/");
            startPage.Heading.ShouldHaveContent("Built for developers");

            var headerMenu = await startPage.HeaderMenu;
            var searchPage = await headerMenu.Search("Puppeteer Sharp");

            var repositories = await searchPage.Results;
            repositories.Length.ShouldBeGreaterThan(0);
            var repository = repositories.First();
            var link = await repository.QuerySelectorAsync("a");
            var text = await repository.QuerySelectorAsync("p");
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            await link.ClickAsync();

            var repoPage = await page.WaitForNavigationAsync<GitHubRepoPage>();
            repoPage.Heading.ShouldHaveContent("Puppeteer Sharp");
            repoPage.Page.Url.ShouldBe("https://github.com/hardkoded/puppeteer-sharp");
        }

        [Test]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            var repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/hardkoded/puppeteer-sharp");
            var badge = await repoPage.BuildStatusBadge;
            await badge.ClickAsync();

            var buildPage = await page.WaitForNavigationAsync<AppVeyorBuildPage>(new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });
            var success = await buildPage.Success();
            success.ShouldBeTrue();
        }

        [Test]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            var repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await repoPage.GetLatestReleaseVersion();

            repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/GoogleChrome/puppeteer");
            var puppeteerVersion = await repoPage.GetLatestReleaseVersion();

            puppeteerSharpVersion.ShouldBe(puppeteerVersion);
        }
    }
}