using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Input;

namespace PuppeteerSharp.Contrib.Sample
{
    public class GitHubStartPage : PageObject
    {
        [Selector("main h1")]
        public virtual Task<IElementHandle> Heading { get; }

        [Selector("header")]
        public virtual Task<GitHubHeader> Header { get; }

        public async Task<GitHubSearchPage> SearchAsync(string text)
        {
            var task = Page.WaitForNavigationAsync<GitHubSearchPage>();
            await (await Header).SearchAsync(text);
            return await task;
        }
    }

    public class GitHubHeader : ElementObject
    {
        [Selector("#query-builder-test")]
        public virtual Task<IElementHandle> SearchInput { get; }

        public async Task SearchAsync(string text)
        {
            var input = await SearchInput;
            if (await input.IsHiddenAsync())
            {
                await Page.ClickAsync("[aria-label=\"Toggle navigation\"][data-view-component=\"true\"]");
                await Page.ClickAsync("[data-target=\"qbsearch-input.inputButtonText\"]");
            }
            await input.TypeAsync(text);
            await input.PressAsync(Key.Enter);
            await Page.WaitForSelectorAsync("[data-testid=\"results-list\"]");
        }
    }

    public class GitHubSearchPage : PageObject
    {
        [Selector("[data-testid=\"results-list\"] > div")]
        public virtual Task<GitHubRepoListItem[]> RepoListItems { get; }

        public async Task<GitHubRepoPage> GotoAsync(GitHubRepoListItem repo)
        {
            var task = Page.WaitForNavigationAsync<GitHubRepoPage>();
            await (await repo.Link).ClickAsync();
            await Page.WaitForSelectorAsync("article h1");
            return await task;
        }
    }

    public class GitHubRepoListItem : ElementObject
    {
        [Selector("a")]
        public virtual Task<IElementHandle> Link { get; }

        [Selector("h3 + div")]
        public virtual Task<IElementHandle> Text { get; }
    }

    public class GitHubRepoPage : PageObject
    {
        [Selector("article h1")]
        public virtual Task<IElementHandle> Heading { get; }

        [Selector("#actions-tab")]
        public virtual Task<IElementHandle> Actions { get; }

        public async Task<GitHubActionsPage> GotoActionsAsync()
        {
            var task = Page.WaitForNavigationAsync<GitHubActionsPage>();
            await (await Actions).ClickAsync();
            await Page.WaitForSelectorAsync("#partial-actions-workflow-runs");
            return await task;
        }

        public async Task<string> GetLatestReleaseVersionAsync()
        {
            var latest = await Page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v\d+\.\d+\.\d+");
            var version = await latest.TextContentAsync();
            return version.Substring(version.LastIndexOf('v') + 1);
        }
    }

    public class GitHubActionsPage : PageObject
    {
        public async Task<string> GetLatestWorkflowRunStatusAsync()
        {
            var status = await Page.QuerySelectorAsync(".d-table svg");
            return await status.GetAttributeAsync("aria-label");
        }
    }
}
