using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using TechTalk.SpecFlow;

namespace PuppeteerSharp.Contrib.Sample.StepDefinitions
{
    [Binding]
    public class PuppeteerSharpRepoSteps
    {
        private Browser Browser { get; }
        private Page Page { get; set; }
        private Dictionary<string, string> LatestReleaseVersion { get; } = new Dictionary<string, string>();

        public PuppeteerSharpRepoSteps(Browser browser)
        {
            Browser = browser;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            Page = await Browser.NewPageAsync();
        }

        [Given(@"I go to the GitHub start page")]
        public async Task GivenIGoToTheGitHubStartPage()
        {
            await Page.GoToAsync("https://github.com/");
            var heading = await Page.QuerySelectorAsync("h1");
            await heading.ShouldHaveContentAsync("Where the world builds software");
        }

        [When(@"I search for ""(.*)""")]
        public async Task WhenISearchFor(string query)
        {
            var input = await Page.QuerySelectorAsync("input.header-search-input");
            if (await input.IsHiddenAsync()) await Page.ClickAsync(".octicon-three-bars");
            await Page.TypeAsync("input.header-search-input", query);
            await Page.Keyboard.PressAsync("Enter");
            await Page.WaitForNavigationAsync();
        }

        [Then(@"the repo should be the first search result")]
        public async Task ThenTheRepoShouldBeTheFirstSearchResult()
        {
            var repositories = await Page.QuerySelectorAllAsync(".repo-list-item");
            repositories.Length.Should().BeGreaterThan(0);
            var repository = repositories.First();
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            var text = await repository.QuerySelectorAsync("p");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.QuerySelectorAsync("a");
            await link.ClickAsync();
            await Page.WaitForNavigationAsync();

            var heading = await Page.QuerySelectorAsync("article > h1");
            await heading.ShouldHaveContentAsync("Puppeteer Sharp");
            Page.Url.Should().Be("https://github.com/hardkoded/puppeteer-sharp");
        }

        [Given(@"I go to the Puppeteer Sharp repo on GitHub")]
        public async Task GivenIGoToThePuppeteerSharpRepoOnGitHub()
        {
            await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
        }

        [When(@"I check the build status on the master branch")]
        public async Task WhenICheckTheBuildStatusOnTheMasterBranch()
        {
            var build = await Page.QuerySelectorAsync("img[alt='Build status']");
            await build.ClickAsync();
            await Page.WaitForNavigationAsync(new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });
        }

        [Then(@"the build status should be success")]
        public async Task ThenTheBuildStatusShouldBeSuccess()
        {
            var success = await Page.QuerySelectorAsync(".project-build.project-build-status.success");
            success.ShouldExist();
        }

        [Given(@"I check the latest release version")]
        public async Task GivenICheckTheLatestReleaseVersion()
        {
            var latest = await Page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v\d\.\d\.\d");
            LatestReleaseVersion.Add(Page.Url, await latest.TextContentAsync());
        }

        [Given(@"I go to the Puppeteer repo on GitHub")]
        public async Task GivenIGoToThePuppeteerRepoOnGitHub()
        {
            await Page.GoToAsync("https://github.com/puppeteer/puppeteer");
        }

        [Then(@"the latest release version should be up to date with Puppeteer")]
        public void ThenTheLatestReleaseVersionShouldBeUpToDateWithPuppeteer()
        {
            var puppeteerSharpVersion = LatestReleaseVersion["https://github.com/hardkoded/puppeteer-sharp"];
            var puppeteerVersion = LatestReleaseVersion["https://github.com/puppeteer/puppeteer"];

            puppeteerSharpVersion.Should().Be(puppeteerVersion);
        }
    }
}
