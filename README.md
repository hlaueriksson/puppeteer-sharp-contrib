# Puppeteer Sharp Contributions<!-- omit in toc -->

[![build](https://github.com/hlaueriksson/puppeteer-sharp-contrib/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/puppeteer-sharp-contrib/actions/workflows/build.yml)
[![CodeFactor](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib/badge)](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib)

[![PuppeteerSharp.Contrib.Extensions](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Extensions.svg?label=PuppeteerSharp.Contrib.Extensions)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Extensions)
[![PuppeteerSharp.Contrib.Should](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Should.svg?label=PuppeteerSharp.Contrib.Should)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should)
[![PuppeteerSharp.Contrib.PageObjects](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.PageObjects.svg?label=PuppeteerSharp.Contrib.PageObjects)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.PageObjects)

Contributions to the Headless Chrome .NET API 🌐🧪

Puppeteer Sharp Contributions offers extensions to the Puppeteer Sharp API.
It provides a convenient way to write readable and robust browser tests in .NET

> [Puppeteer Sharp](https://github.com/hardkoded/puppeteer-sharp) is a .NET port of the official Node.JS Puppeteer API.
>
> [Puppeteer](https://github.com/puppeteer/puppeteer) is a Node library which provides a high-level API to control Chrome or Chromium over the DevTools Protocol. Puppeteer runs headless by default, but can be configured to run full (non-headless) Chrome or Chromium.

## Content<!-- omit in toc -->

- [Introduction](#introduction)
- [PuppeteerSharp.Contrib.Extensions](#puppeteersharpcontribextensions)
- [PuppeteerSharp.Contrib.Should](#puppeteersharpcontribshould)
- [PuppeteerSharp.Contrib.PageObjects](#puppeteersharpcontribpageobjects)
- [Samples](#samples)
- [Upgrading](#upgrading)
- [Attribution](#attribution)

## Introduction

`PuppeteerSharp` is a great library to automate the Chrome browser in .NET / C#.

_Puppeteer Sharp Contributions_ consists of a few libraries that helps you write browser automation tests:

- `PuppeteerSharp.Contrib.Extensions`
- `PuppeteerSharp.Contrib.Should`
- `PuppeteerSharp.Contrib.PageObjects`

These libraries contains _extension methods_ to the Puppeteer Sharp API and they are test framework agnostic.

## PuppeteerSharp.Contrib.Extensions

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.Extensions)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Extensions/)

`PuppeteerSharp.Contrib.Extensions` is a library with convenient extension methods for writing browser tests with the Puppeteer Sharp API.

:book: README: [PuppeteerSharp.Contrib.Extensions.md](PuppeteerSharp.Contrib.Extensions.md)

## PuppeteerSharp.Contrib.Should

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.Should)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should/)

`PuppeteerSharp.Contrib.Should` is a should assertion library for the Puppeteer Sharp API.

:book: README: [PuppeteerSharp.Contrib.Should.md](PuppeteerSharp.Contrib.Should.md)

## PuppeteerSharp.Contrib.PageObjects

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.PageObjects)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.PageObjects/)

`PuppeteerSharp.Contrib.PageObjects` is a library for writing browser tests using the _page object pattern_ with the Puppeteer Sharp API.

:book: README: [PuppeteerSharp.Contrib.PageObjects.md](PuppeteerSharp.Contrib.PageObjects.md)

## Samples

Sample projects are located in the [`samples`](/samples/) folder.

Examples are written with these test frameworks:

- Machine.Specifications
- MSTest
- NUnit
- SpecFlow
- Xunit

This is an example with `NUnit` and `PuppeteerSharp.Contrib.Should`:

```csharp
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Input;

namespace PuppeteerSharp.Contrib.Sample
{
    public class PuppeteerSharpRepoTests
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

            await page.GoToAsync("https://github.com/");
            var heading = await page.QuerySelectorAsync("main h1");
            await heading.ShouldHaveContentAsync("Let’s build");

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
            Assert.That(repositories, Is.Not.Empty);
            var repository = repositories.First();
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            var text = await repository.QuerySelectorAsync("h3 + div");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.QuerySelectorAsync("a");
            await link.ClickAsync();
            await page.WaitForSelectorAsync("article > h1");

            heading = await page.QuerySelectorAsync("article > h1");
            await heading.ShouldHaveContentAsync("Puppeteer Sharp");
            Assert.That(page.Url, Is.EqualTo("https://github.com/hardkoded/puppeteer-sharp"));
        }

        [Test]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            await page.ClickAsync("#actions-tab");
            await page.WaitForSelectorAsync("#partial-actions-workflow-runs");

            var status = await page.QuerySelectorAsync(".checks-list-item-icon svg");
            var label = await status.GetAttributeAsync("aria-label");
            Assert.That(label, Is.EqualTo("completed successfully"));
        }

        [Test]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await GetLatestReleaseVersion();

            await page.GoToAsync("https://github.com/puppeteer/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            Assert.That(puppeteerSharpVersion, Is.EqualTo(puppeteerVersion));

            async Task<string> GetLatestReleaseVersion()
            {
                var latest = await page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v?\d+\.\d\.\d");
                var version = await latest.TextContentAsync();
                return version.Substring(version.LastIndexOf('v') + 1);
            }
        }
    }
}
```

This is an example with `NUnit` and `PuppeteerSharp.Contrib.PageObjects`:

```csharp
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
            await Page.WaitForSelectorAsync("article > h1");
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
        [Selector("article > h1")]
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
            var latest = await Page.QuerySelectorWithContentAsync("a[href*='releases'] span", @"v?\d+\.\d\.\d");
            var version = await latest.TextContentAsync();
            return version.Substring(version.LastIndexOf('v') + 1);
        }
    }

    public class GitHubActionsPage : PageObject
    {
        public async Task<string> GetLatestWorkflowRunStatusAsync()
        {
            var status = await Page.QuerySelectorAsync(".checks-list-item-icon svg");
            return await status.GetAttributeAsync("aria-label");
        }
    }
}
```

```csharp
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
            await heading.ShouldHaveContentAsync("Let’s build");

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
            Assert.That(status, Is.EqualTo("completed successfully"));
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
```

## Upgrading

> :arrow_up: Upgrading from version `5.0.0` to `6.0.0`

Since [v8.0.0](https://github.com/hardkoded/puppeteer-sharp/releases/tag/v8.0.0) of PuppeteerSharp, the public API relies on interfaces.

Therefor, change the use of:

- ~~`Page`~~ to `IPage`
- ~~`ElementHandle`~~ to `IElementHandle`

**PuppeteerSharp.Contrib.PageObjects**

Since [v10.1.0](https://github.com/hardkoded/puppeteer-sharp/releases/tag/v10.1.0) of PuppeteerSharp, the `XPathAsync` and `WaitForXPathAsync` methods were replaced in favor of the `xpath/` selector handler.

Therefor, change the use of:

- ~~`[XPath]`~~ attribute to `[Selector]`
- ~~`XPathAsync`~~ method to `QuerySelectorAsync`
- ~~`WaitForXPathAsync`~~ method to `WaitForSelectorAsync`

## Attribution

Puppeteer Sharp Contributions is standing on the shoulders of giants.

It would not exist without https://github.com/hardkoded/puppeteer-sharp and https://github.com/puppeteer/puppeteer
