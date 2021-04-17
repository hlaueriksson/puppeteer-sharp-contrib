using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Input;

namespace PuppeteerSharp.Contrib.Sample
{
    public class GitHubStartPage : PageObject
    {
        [Selector("h1")]
        public virtual Task<ElementHandle> Heading { get; }

        [Selector(".HeaderMenu")]
        public virtual Task<GitHubHeaderMenu> HeaderMenu { get; }
    }

    public class GitHubHeaderMenu : ElementObject
    {
        [Selector("input.header-search-input")]
        public virtual Task<ElementHandle> SearchInput { get; }

        public async Task<GitHubSearchPage> Search(string text)
        {
            var input = await SearchInput;
            if (await input.IsHiddenAsync()) await Page.ClickAsync(".octicon-three-bars");
            await input.TypeAsync(text);
            await input.PressAsync(Key.Enter);

            return await Page.WaitForNavigationAsync<GitHubSearchPage>();
        }
    }

    public class GitHubSearchPage : PageObject
    {
        [Selector(".repo-list-item")]
        public virtual Task<GitHubRepoListItem[]> RepoListItems { get; }
    }

    public class GitHubRepoListItem : ElementObject
    {
        [Selector("a")]
        public virtual Task<ElementHandle> Link { get; }

        [Selector("p")]
        public virtual Task<ElementHandle> Text { get; }
    }

    public class GitHubRepoPage : PageObject
    {
        [Selector("article > h1")]
        public virtual Task<ElementHandle> Heading { get; }

        [Selector("img[alt='Build status']")]
        public virtual Task<ElementHandle> BuildStatusBadge { get; }

        public async Task<string> GetLatestReleaseVersion()
        {
            var latest = await Page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v\d\.\d\.\d");
            return await latest.TextContentAsync();
        }
    }

    public class AppVeyorBuildPage : PageObject
    {
        public async Task<bool> Success()
        {
            var success = await Page.QuerySelectorAsync(".project-build.project-build-status.success");
            return success.Exists();
        }
    }
}
