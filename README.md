# Puppeteer Sharp Contributions

[![Build status](https://ci.appveyor.com/api/projects/status/sg69dj3wt7kl2t2h?svg=true)](https://ci.appveyor.com/project/hlaueriksson/puppeteer-sharp-contrib)
[![CodeFactor](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib/badge)](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib)

[![PuppeteerSharp.Contrib.Extensions](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Extensions.svg?label=PuppeteerSharp.Contrib.Extensions)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Extensions)
[![PuppeteerSharp.Contrib.Should](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Should.svg?label=PuppeteerSharp.Contrib.Should)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should)
[![PuppeteerSharp.Contrib.PageObjects](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.PageObjects.svg?label=PuppeteerSharp.Contrib.PageObjects)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.PageObjects)

[![PuppeteerSharp.Contrib.Extensions.Unsafe](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Extensions.Unsafe.svg?label=PuppeteerSharp.Contrib.Extensions.Unsafe)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Extensions.Unsafe)
[![PuppeteerSharp.Contrib.Should.Unsafe](https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Should.Unsafe.svg?label=PuppeteerSharp.Contrib.Should.Unsafe)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should.Unsafe)

Contributions to the Headless Chrome .NET API 🌐🧪

Puppeteer Sharp Contributions offers extensions to the Puppeteer Sharp API.
It provides a convenient way to write readable and robust browser tests in .NET

> [Puppeteer Sharp](https://github.com/hardkoded/puppeteer-sharp) is a .NET port of the official Node.JS Puppeteer API.
>
> [Puppeteer](https://github.com/puppeteer/puppeteer) is a Node library which provides a high-level API to control Chrome or Chromium over the DevTools Protocol. Puppeteer runs headless by default, but can be configured to run full (non-headless) Chrome or Chromium.

## Content

- [Puppeteer Sharp Contributions](#puppeteer-sharp-contributions)
  - [Content](#content)
  - [Introduction](#introduction)
  - [PuppeteerSharp.Contrib.Extensions](#puppeteersharpcontribextensions)
  - [PuppeteerSharp.Contrib.Should](#puppeteersharpcontribshould)
  - [PuppeteerSharp.Contrib.PageObjects](#puppeteersharpcontribpageobjects)
  - [PuppeteerSharp.Contrib.Extensions.Unsafe](#puppeteersharpcontribextensionsunsafe)
  - [PuppeteerSharp.Contrib.Should.Unsafe](#puppeteersharpcontribshouldunsafe)
  - [Samples](#samples)
  - [Upgrading](#upgrading)
  - [Attribution](#attribution)

## Introduction

`PuppeteerSharp` is a great library to automate the Chrome browser in .NET / C#.

_Puppeteer Sharp Contributions_ consists of a few libraries that helps you write browser automation tests:

* `PuppeteerSharp.Contrib.Extensions`
* `PuppeteerSharp.Contrib.Should`
* `PuppeteerSharp.Contrib.PageObjects`
* `PuppeteerSharp.Contrib.Extensions.Unsafe`
* `PuppeteerSharp.Contrib.Should.Unsafe`

These libraries contains _extension methods_ to the Puppeteer Sharp API and they are test framework agnostic.

## PuppeteerSharp.Contrib.Extensions

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.Extensions)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Extensions/)

`PuppeteerSharp.Contrib.Extensions` is a library with convenient extension methods for writing browser tests with the Puppeteer Sharp API.

:book: README: [PuppeteerSharp.Contrib.Extensions.md](PuppeteerSharp.Contrib.Extensions.md)

:boom: The _sync over async_ versions of the extension methods has been moved to the [unsafe](#puppeteersharpcontribextensionsunsafe) package.

## PuppeteerSharp.Contrib.Should

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.Should)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should/)

`PuppeteerSharp.Contrib.Should` is a should assertion library for the Puppeteer Sharp API.

:book: README: [PuppeteerSharp.Contrib.Should.md](PuppeteerSharp.Contrib.Should.md)

:boom: The _sync over async_ versions of the extension methods has been moved to the [unsafe](#puppeteersharpcontribshouldunsafe) package.

## PuppeteerSharp.Contrib.PageObjects

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.PageObjects)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.PageObjects/)

`PuppeteerSharp.Contrib.PageObjects` is a library for writing browser tests using the _page object pattern_ with the Puppeteer Sharp API.

:book: README: [PuppeteerSharp.Contrib.PageObjects.md](PuppeteerSharp.Contrib.PageObjects.md)

## PuppeteerSharp.Contrib.Extensions.Unsafe

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.Extensions.Unsafe)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Extensions.Unsafe/)

`PuppeteerSharp.Contrib.Extensions.Unsafe` contains _sync over async_ versions of the extension methods from the [safe](#puppeteersharpcontribextensions) package.

:book: README: [PuppeteerSharp.Contrib.Extensions.Unsafe.md](PuppeteerSharp.Contrib.Extensions.Unsafe.md)

## PuppeteerSharp.Contrib.Should.Unsafe

[![NuGet](https://buildstats.info/nuget/PuppeteerSharp.Contrib.Should.Unsafe)](https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should.Unsafe/)

`PuppeteerSharp.Contrib.Should.Unsafe` contains _sync over async_ versions of the extension methods from the [safe](#puppeteersharpcontribshould) package.

:book: README: [PuppeteerSharp.Contrib.Should.Unsafe.md](PuppeteerSharp.Contrib.Should.Unsafe.md)

## Samples

Sample projects are located in the [`samples`](/samples/) folder.

Examples are written with these test frameworks:

* Machine.Specifications
* MSTest
* NUnit
* SpecFlow
* Xunit

This is an example with `NUnit` and `PuppeteerSharp.Contrib.Should`:

```csharp
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;

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

            await page.GoToAsync("https://github.com/");
            var h1 = await page.QuerySelectorAsync("h1");
            await h1.ShouldHaveContentAsync("Built for developers");

            var input = await page.QuerySelectorAsync("input.header-search-input");
            if (await input.IsHiddenAsync()) await page.ClickAsync(".octicon-three-bars");
            await page.TypeAsync("input.header-search-input", "Puppeteer Sharp");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();

            var repositories = await page.QuerySelectorAllAsync(".repo-list-item");
            Assert.IsNotEmpty(repositories);
            var repository = repositories.First();
            await repository.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            var text = await repository.QuerySelectorAsync("p");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.QuerySelectorAsync("a");
            await link.ClickAsync();
            await page.WaitForNavigationAsync();

            h1 = await page.QuerySelectorAsync("article > h1");
            await h1.ShouldHaveContentAsync("Puppeteer Sharp");
            Assert.AreEqual("https://github.com/hardkoded/puppeteer-sharp", page.Url);
        }

        [Test]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            var build = await page.QuerySelectorAsync("img[alt='Build status']");
            await build.ClickAsync();
            await page.WaitForNavigationAsync(new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var success = await page.QuerySelectorAsync(".project-build.project-build-status.success");
            success.ShouldExist();
        }

        [Test]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await GetLatestReleaseVersion();

            await page.GoToAsync("https://github.com/GoogleChrome/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            Assert.AreEqual(puppeteerVersion, puppeteerSharpVersion);

            async Task<string> GetLatestReleaseVersion()
            {
                var releases = await page.QuerySelectorWithContentAsync("a", "releases");
                await releases.ClickAsync();
                await page.WaitForNavigationAsync();

                var latest = await page.QuerySelectorAsync(".release .release-header a");
                return VersionWithoutPatch(await latest.TextContentAsync());

                string VersionWithoutPatch(string version)
                {
                    var tokens = version.Split(".".ToCharArray());
                    return string.Join(".", tokens.Take(2));
                }
            }
        }
    }
}
```

This is an example with `NUnit` and `PuppeteerSharp.Contrib.PageObjects`:

```csharp
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
            var releases = await Page.QuerySelectorWithContentAsync("a", "releases");
            await releases.ClickAsync();
            await Page.WaitForNavigationAsync();

            var latest = await Page.QuerySelectorAsync(".release .release-header a");
            return VersionWithoutPatch(await latest.TextContentAsync());

            string VersionWithoutPatch(string version)
            {
                var tokens = version.Split(".".ToCharArray());
                return string.Join(".", tokens.Take(2));
            }
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
            var heading = await startPage.Heading;
            await heading.ShouldHaveContentAsync("Built for developers");

            var headerMenu = await startPage.HeaderMenu;
            var searchPage = await headerMenu.Search("Puppeteer Sharp");

            var repositories = await searchPage.RepoListItems;
            Assert.IsNotEmpty(repositories);
            var repository = repositories.First();
            var text = await repository.Text;
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            var link = await repository.Link;
            await link.ShouldHaveContentAsync("hardkoded/puppeteer-sharp");
            await link.ClickAsync();

            var repoPage = await page.WaitForNavigationAsync<GitHubRepoPage>();
            heading = await repoPage.Heading;
            await heading.ShouldHaveContentAsync("Puppeteer Sharp");
            Assert.AreEqual("https://github.com/hardkoded/puppeteer-sharp", repoPage.Page.Url);
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
            Assert.True(success);
        }

        [Test]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            var repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/hardkoded/puppeteer-sharp");
            var puppeteerSharpVersion = await repoPage.GetLatestReleaseVersion();

            repoPage = await page.GoToAsync<GitHubRepoPage>("https://github.com/GoogleChrome/puppeteer");
            var puppeteerVersion = await repoPage.GetLatestReleaseVersion();

            Assert.AreEqual(puppeteerVersion, puppeteerSharpVersion);
        }
    }
}
```

## Upgrading

> Upgrading from version `1.0.0` to `2.0.0`

If you use the _sync_ methods from `PuppeteerSharp.Contrib.Extensions` or `PuppeteerSharp.Contrib.Should`, please install:

* `PuppeteerSharp.Contrib.Extensions.Unsafe`
* `PuppeteerSharp.Contrib.Should.Unsafe`

## Attribution

Puppeteer Sharp Contributions is standing on the shoulders of giants.

It would not exist without https://github.com/hardkoded/puppeteer-sharp and https://github.com/puppeteer/puppeteer

Inspiration and experience has been drawn from the previous usage of https://github.com/featurist/coypu and https://github.com/stirno/FluentAutomation
