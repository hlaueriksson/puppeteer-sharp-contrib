using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Sample
{
    public class PuppeteerSharpRepoPageObjectTests
    {
        private IBrowser Browser { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            await new BrowserFetcher().DownloadAsync();
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
            var heading = await startPage.Heading;
            await heading.ShouldHaveContentAsync("Build and ship software on a single, collaborative platform");

            var searchPage = await startPage.SearchAsync("Puppeteer Sharp");
            var repositories = await searchPage.RepoListItems;
            Assert.That(repositories, Is.Not.Empty);
            var repository = repositories.First();
            var text = await repository.Text;
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.Link;
            await link.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");

            var repoPage = await searchPage.GotoAsync(repository);
            heading = await repoPage.Heading;
            await heading.ShouldHaveContentAsync("Puppeteer Sharp");
            Assert.That(repoPage.Page.Url, Is.EqualTo("https://github.com/hardkoded/puppeteer-sharp"));
        }

        [Test]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            var repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/hardkoded/puppeteer-sharp");

            var actionsPage = await repoPage.GotoActionsAsync();
            var status = await actionsPage.GetLatestWorkflowRunStatusAsync();
            Assert.That(status, Does.Contain("completed successfully"));
        }

        [Test]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            var repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/puppeteer/puppeteer");
            var puppeteerVersion = await repoPage.GetLatestReleaseVersionAsync();

            repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await repoPage.GetLatestReleaseVersionAsync();

            Assert.That(puppeteerSharpVersion, Is.EqualTo(puppeteerVersion));
        }
    }
}
