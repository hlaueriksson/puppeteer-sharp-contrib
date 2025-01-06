using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Input;
using TechTalk.SpecFlow;

namespace PuppeteerSharp.Contrib.Sample.StepDefinitions
{
    [Binding]
    public class PuppeteerSharpRepoSteps(IBrowser browser)
    {
        private IBrowser Browser { get; } = browser;
        private IPage Page { get; set; }
        private Dictionary<string, string> LatestReleaseVersion { get; } = [];

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            Page = await Browser.NewPageAsync();
        }

        [Given(@"I go to the GitHub start page")]
        public async Task GivenIGoToTheGitHubStartPage()
        {
            await Page.GoToAsync("https://github.com/");
            var heading = await Page.QuerySelectorAsync("main h1");
            await heading.ShouldHaveContentAsync("Build and ship software on a single, collaborative platform");
        }

        [When(@"I search for ""(.*)""")]
        public async Task WhenISearchFor(string query)
        {
            var input = await Page.QuerySelectorAsync("#query-builder-test");
            if (await input.IsHiddenAsync())
            {
                await Page.ClickAsync("[aria-label=\"Toggle navigation\"][data-view-component=\"true\"]");
                await Page.ClickAsync("[data-target=\"qbsearch-input.inputButtonText\"]");
            }
            await input.TypeAsync(query);
            await Page.Keyboard.PressAsync(Key.Enter);
            await Page.WaitForSelectorAsync("[data-testid=\"results-list\"]");
        }

        [Then(@"the repo should be the first search result")]
        public async Task ThenTheRepoShouldBeTheFirstSearchResult()
        {
            var repositories = await Page.QuerySelectorAllAsync("[data-testid=\"results-list\"] > div");
            repositories.Length.Should().BeGreaterThan(0);
            var repository = repositories.First();
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            var text = await repository.QuerySelectorAsync("h3 + div");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.QuerySelectorAsync("a");
            await link.ClickAsync();
            await Page.WaitForSelectorAsync("article h1");

            var heading = await Page.QuerySelectorAsync("article h1");
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
            await Page.ClickAsync("#actions-tab");
            await Page.WaitForSelectorAsync("#partial-actions-workflow-runs");
        }

        [Then(@"the build status should be success")]
        public async Task ThenTheBuildStatusShouldBeSuccess()
        {
            var status = await Page.QuerySelectorAsync(".d-table svg");
            var label = await status.GetAttributeAsync("aria-label");
            label.Should().Contain("completed successfully");
        }

        [Given(@"I check the latest release version")]
        public async Task GivenICheckTheLatestReleaseVersion()
        {
            var latest = await Page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v\d+\.\d+\.\d+");
            var version = await latest.TextContentAsync();
            LatestReleaseVersion.Add(Page.Url, version.Substring(version.LastIndexOf('v') + 1));
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
