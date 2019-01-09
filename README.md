# Puppeteer Sharp Contributions

[![Build status](https://ci.appveyor.com/api/projects/status/sg69dj3wt7kl2t2h?svg=true)](https://ci.appveyor.com/project/hlaueriksson/puppeteer-sharp-contrib)

> Contributions to the Headless Chrome .NET API 🌐🧪

> Puppeteer Sharp Contributions offers extensions to the Puppeteer Sharp API.
> It provides a convenient way to write readable and robust browser tests in .NET

> [Puppeteer Sharp](https://github.com/kblok/puppeteer-sharp) is a .NET port of the official Node.JS Puppeteer API.

> [Puppeteer](https://github.com/GoogleChrome/puppeteer) is a Node library which provides a high-level API to control Chrome or Chromium over the DevTools Protocol. Puppeteer runs headless by default, but can be configured to run full (non-headless) Chrome or Chromium.

## Introduction

`PuppeteerSharp` is a great library to automate the Chrome browser in .NET / C#.

_Puppeteer Sharp Contributions_ consists of two libraries that helps you write browser automation tests:

* `PuppeteerSharp.Contrib.Extensions`
* `PuppeteerSharp.Contrib.Should`

These libraries contains _extension methods_ to the Puppeteer Sharp API and they are test framework agnostic.

## Extensions

`PuppeteerSharp.Contrib.Extensions` is a library with convenient extension methods for writing browser tests with the Puppeteer Sharp API.

Extensions for `Page`:

* `QuerySelectorWithContentAsync`
* `QuerySelectorAllWithContentAsync`

_Attribute_ extensions for `ElementHandle`:

* `GetAttribute`
* `HasAttribute`
* `Href`
* `Id`
* `Name`
* `Src`
* `Value`

Extensions for `ElementHandle`:

* `ClassList`
* `ClassName`
* `Exists`
* `HasClass`
* `HasContent`
* `HasFocus`
* `InnerHtml`
* `InnerText`
* `IsChecked`
* `IsDisabled`
* `IsEnabled`
* `IsHidden`
* `IsReadOnly`
* `IsRequired`
* `IsSelected`
* `IsVisible`
* `OuterHtml`
* `QuerySelectorWithContentAsync`
* `QuerySelectorAllWithContentAsync`
* `TextContent`

Usage:

```csharp
using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Documentation
{
    public class ExtensionsTests : PuppeteerPageBaseTest
    {
        [Fact]
        public async Task Query()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar'>Bar</div>
  <div id='baz'>Baz</div>
</html>");

            var html = await Page.QuerySelectorAsync("html");

            var div = await Page.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.Equal("bar", div.Id());

            div = await html.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.Equal("bar", div.Id());

            var divs = await Page.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.Equal(new[] { "bar", "baz" }, divs.Select(x => x.Id()));

            divs = await html.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.Equal(new[] { "bar", "baz" }, divs.Select(x => x.Id()));
        }

        [Fact]
        public async Task Attributes()
        {
            await Page.SetContentAsync(@"
<html>
  <form method='post'>
      Name: <input type='text' name='name' id='name' required>
      Email: <input type='email' name='email' id='email' required>
      <input type='submit' value='Subscribe!'>
  </form>
  <img src='unsubscribe.png' />
  <a href='/unsubscribe/'>Unsubscribe</a>
</html>");

            var form = await Page.QuerySelectorAsync("form");
            Assert.Equal("post", form.GetAttribute("method"));

            var input = await Page.QuerySelectorAsync("#name");
            Assert.True(input.HasAttribute("required"));

            var link = await Page.QuerySelectorAsync("a");
            Assert.Equal("/unsubscribe/", link.Href());

            input = await Page.QuerySelectorAsync("input[type=email]");
            Assert.Equal("email", input.Id());

            input = await Page.QuerySelectorAsync("#email");
            Assert.Equal("email", input.Name());

            var img = await Page.QuerySelectorAsync("img");
            Assert.Equal("unsubscribe.png", img.Src());

            input = await Page.QuerySelectorAsync("input[type=submit]");
            Assert.Equal("Subscribe!", input.Value());
        }

        [Fact]
        public async Task Class()
        {
            await Page.SetContentAsync("<div class='foo bar' />");

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal("foo bar", div.ClassName());
            Assert.Equal(new[] { "foo", "bar" }, div.ClassList());
            Assert.True(div.HasClass("bar"));
        }

        [Fact]
        public async Task Content()
        {
            await Page.SetContentAsync(@"
<html>
  <div>
    Foo
    <span>Bar</span>
  </div>
</html>
");

            var html = await Page.QuerySelectorAsync("html");
            Assert.True(html.HasContent("Foo"));

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal("\n    Foo\n    <span>Bar</span>\n  ", div.InnerHtml());
            Assert.Equal("<div>\n    Foo\n    <span>Bar</span>\n  </div>", div.OuterHtml());
            Assert.Equal("Foo Bar", div.InnerText());
            Assert.Equal("\n    Foo\n    Bar\n  ", div.TextContent());
        }

        [Fact]
        public async Task Visibility()
        {
            await Page.SetContentAsync("<div>Foo</div>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(div.Exists());
            Assert.False(div.IsHidden());
            Assert.True(div.IsVisible());
        }

        [Fact]
        public async Task Input()
        {
            await Page.SetContentAsync(@"
<form>
  <input type='text' autofocus required>
  <input type='radio' readonly>
  <input type='checkbox' checked>
  <select>
    <option id='foo'>Foo</option>
    <option id='bar'>Bar</option>
  </select>
</form>
");

            var input = await Page.QuerySelectorAsync("input[type=text]");
            Assert.True(input.HasFocus());
            Assert.True(input.IsRequired());

            input = await Page.QuerySelectorAsync("input[type=radio]");
            Assert.False(input.IsDisabled());
            Assert.True(input.IsEnabled());
            Assert.True(input.IsReadOnly());

            input = await Page.QuerySelectorAsync("input[type=checkbox]");
            Assert.True(input.IsChecked());

            input = await Page.QuerySelectorAsync("#foo");
            Assert.True(input.IsSelected());
        }
    }
}
```

The extension methods for `ElementHandle` usually comes in overloads of three, with signatures like this:

```csharp
public static async Task<bool> HasContentAsync(this ElementHandle handle, string content)

public static bool HasContent(this ElementHandle handle, string content)

public static bool HasContent(this Task<ElementHandle> task, string content)
```

## Should

`PuppeteerSharp.Contrib.Should` is a should assertion library for the Puppeteer Sharp API.

Should assertions for `ElementHandle`:

* `ShouldBeChecked`
* `ShouldBeDisabled`
* `ShouldBeEnabled`
* `ShouldBeHidden`
* `ShouldBeReadOnly`
* `ShouldBeRequired`
* `ShouldBeSelected`
* `ShouldBeVisible`
* `ShouldExist`
* `ShouldHaveAttribute`
* `ShouldHaveClass`
* `ShouldHaveContent`
* `ShouldHaveFocus`
* `ShouldHaveValue`
* `ShouldNotBeChecked`
* `ShouldNotBeReadOnly`
* `ShouldNotBeRequired`
* `ShouldNotBeSelected`
* `ShouldNotExist`
* `ShouldNotHaveAttribute`
* `ShouldNotHaveClass`
* `ShouldNotHaveContent`
* `ShouldNotHaveFocus`
* `ShouldNotHaveValue`

Usage:

```csharp
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Documentation
{
    public class ShouldTests : PuppeteerPageBaseTest
    {
        [Fact]
        public async Task Attributes()
        {
            await Page.SetContentAsync("<div data-foo='bar' />");

            var div = await Page.QuerySelectorAsync("div");
            div
                .ShouldHaveAttribute("data-foo")
                .ShouldNotHaveAttribute("data-bar");
        }

        [Fact]
        public async Task Class()
        {
            await Page.SetContentAsync("<div class='foo' />");

            var div = await Page.QuerySelectorAsync("div");
            div
                .ShouldHaveClass("foo")
                .ShouldNotHaveClass("bar");
        }

        [Fact]
        public async Task Content()
        {
            await Page.SetContentAsync("<div>Foo</div>");

            var div = await Page.QuerySelectorAsync("div");
            div
                .ShouldHaveContent("Foo")
                .ShouldNotHaveContent("Bar");
        }

        [Fact]
        public async Task Visibility()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar' style='display:none'>Bar</div>
</html>");

            var html = await Page.QuerySelectorAsync("html");
            html.ShouldExist();

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeVisible();

            div = await Page.QuerySelectorAsync("#bar");
            div.ShouldBeHidden();
        }

        [Fact]
        public async Task Input()
        {
            await Page.SetContentAsync(@"
<form>
  <input type='text' autofocus required value='Foo Bar'>
  <input type='radio' readonly>
  <input type='checkbox' checked>
  <select>
    <option id='foo'>Foo</option>
    <option id='bar'>Bar</option>
  </select>
</form>
");

            var input = await Page.QuerySelectorAsync("input[type=text]");
            input
                .ShouldHaveFocus()
                .ShouldBeRequired()
                .ShouldHaveValue("Foo Bar");

            input = await Page.QuerySelectorAsync("input[type=radio]");
            input
                .ShouldBeEnabled()
                .ShouldBeReadOnly();

            input = await Page.QuerySelectorAsync("input[type=checkbox]");
            input.ShouldBeChecked();

            input = await Page.QuerySelectorAsync("#foo");
            input.ShouldBeSelected();
        }
    }
}
```

The should assertions for `ElementHandle` usually comes in overloads of three, with signatures like this:

```csharp
public static async Task ShouldHaveContentAsync(this ElementHandle handle, string content, string message = null)

public static ElementHandle ShouldHaveContent(this ElementHandle handle, string content, string message = null)

public static void ShouldHaveContent(this Task<ElementHandle> task, string content, string message = null)
```

Together with inverted **not** variants:

```csharp
public static async Task ShouldNotHaveContentAsync(this ElementHandle handle, string content, string message = null)

public static ElementHandle ShouldNotHaveContent(this ElementHandle handle, string content, string message = null)

public static void ShouldNotHaveContent(this Task<ElementHandle> task, string content, string message = null)
```

## Samples

Sample projects are located in the [`samples`](/samples/) folder:

* `PuppeteerSharp.Contrib.Sample.Machine.Specifications`
* `PuppeteerSharp.Contrib.Sample.NUnit`
* `PuppeteerSharp.Contrib.Sample.SpecFlow`
* `PuppeteerSharp.Contrib.Sample.Xunit`

All projects runs the following scenarios:

1. Search for Puppeteer Sharp on GitHub
2. Check that the Puppeteer Sharp master branch builds
3. Compare the Puppeteer and Puppeteer Sharp versions

### Xunit

Xunit seems to handle `async` / `await` best of all test frameworks.

Implement `IAsyncLifetime` to get async setup and teardown methods.

This example uses `Shouldly` for general should assertions.

```csharp
using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Should;
using Shouldly;
using Xunit;

namespace PuppeteerSharp.Contrib.Sample
{
    public class PuppeteerSharpRepoTests : IAsyncLifetime
    {
        private Browser Browser { get; set; }

        public async Task InitializeAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
        }

        public async Task DisposeAsync()
        {
            await Browser.CloseAsync();
        }

        [Fact]
        public async Task Should_be_first_search_result_on_GitHub()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/");
            page.QuerySelectorAsync("h1").ShouldHaveContent("Built for developers");

            var input = await page.QuerySelectorAsync("input.header-search-input");
            if (input.IsHidden()) await page.ClickAsync(".octicon-three-bars");
            await page.TypeAsync("input.header-search-input", "Puppeteer Sharp");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();

            var repositories = await page.QuerySelectorAllAsync(".repo-list-item");
            repositories.Length.ShouldBeGreaterThan(0);
            var repository = repositories.First();
            var link = await repository.QuerySelectorAsync("a");
            var text = await repository.QuerySelectorAsync("p");
            repository.ShouldHaveContent("kblok/puppeteer-sharp");
            text.ShouldHaveContent("Headless Chrome .NET API");
            await link.ClickAsync();
            await page.WaitForNavigationAsync();

            page.QuerySelectorAsync("h1").ShouldHaveContent("kblok/puppeteer-sharp");
            page.Url.ShouldBe("https://github.com/kblok/puppeteer-sharp");
        }

        [Fact]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/kblok/puppeteer-sharp");

            var build = await page.QuerySelectorAsync("img[alt='Build status']");
            await build.ClickAsync();
            await page.WaitForNavigationAsync(new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var success = await page.QuerySelectorAsync(".project-build.project-build-status.success");
            success.ShouldExist();
        }

        [Fact]
        public async Task Should_be_up_to_date_with_the_Puppeteer_version()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/kblok/puppeteer-sharp");
            var puppeteerSharpVersion = await GetLatestReleaseVersion();

            await page.GoToAsync("https://github.com/GoogleChrome/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            puppeteerSharpVersion.ShouldBe(puppeteerVersion);

            async Task<string> GetLatestReleaseVersion()
            {
                var releases = await page.QuerySelectorWithContentAsync("a", "releases");
                await releases.ClickAsync();
                await page.WaitForNavigationAsync();

                var latest = await page.QuerySelectorAsync(".release .release-header a");
                return VersionWithoutPatch(latest.TextContent());

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

### NUnit

NUnit supports `async` / `await`.
You need to use the **async versions** of the extension methods from `PuppeteerSharp.Contrib.Extensions` and `PuppeteerSharp.Contrib.Should`!
Otherwise the tests will _hang_.

Make the signatures of the setup and teardown methods return `async Task`.

This example uses `Shouldly` for general should assertions.

```csharp
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;
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

            await page.GoToAsync("https://github.com/");
            var h1 = await page.QuerySelectorAsync("h1");
            await h1.ShouldHaveContentAsync("Built for developers");

            var input = await page.QuerySelectorAsync("input.header-search-input");
            if (await input.IsHiddenAsync()) await page.ClickAsync(".octicon-three-bars");
            await page.TypeAsync("input.header-search-input", "Puppeteer Sharp");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();

            var repositories = await page.QuerySelectorAllAsync(".repo-list-item");
            repositories.Length.ShouldBeGreaterThan(0);
            var repository = repositories.First();
            var link = await repository.QuerySelectorAsync("a");
            var text = await repository.QuerySelectorAsync("p");
            await repository.ShouldHaveContentAsync("kblok/puppeteer-sharp");
            await text.ShouldHaveContentAsync("Headless Chrome .NET API");
            await link.ClickAsync();
            await page.WaitForNavigationAsync();

            h1 = await page.QuerySelectorAsync("h1");
            await h1.ShouldHaveContentAsync("kblok/puppeteer-sharp");
            page.Url.ShouldBe("https://github.com/kblok/puppeteer-sharp");
        }

        [Test]
        public async Task Should_have_successful_build_status()
        {
            var page = await Browser.NewPageAsync();

            await page.GoToAsync("https://github.com/kblok/puppeteer-sharp");

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

            await page.GoToAsync("https://github.com/kblok/puppeteer-sharp");
            var puppeteerSharpVersion = await GetLatestReleaseVersion();

            await page.GoToAsync("https://github.com/GoogleChrome/puppeteer");
            var puppeteerVersion = await GetLatestReleaseVersion();

            puppeteerSharpVersion.ShouldBe(puppeteerVersion);

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

### Machine.Specifications

Machine.Specifications **does not** support `async` / `await`.
You need to work around this with the `.Await()` and `.Result()` extension methods.
Otherwise the tests will be _false positives_.

This example uses `Machine.Specifications.Should` for general should assertions.

```csharp
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

                page.QuerySelectorAsync("h1").ShouldHaveContent("kblok/puppeteer-sharp");
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
```

```csharp
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Sample
{
    public static class TaskExtensions
    {
        internal static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}
```

### SpecFlow

SpecFlow supports `async` / `await`.
Use Xunit as the unit test provider! Depend on the `SpecFlow.xUnit` NuGet package and configure the `App.config` file.

The setup and teardown methods are specified with the `[BeforeScenario]` and `[AfterScenario]` attributes.
Make the signatures return `async Task`.
Use the `IObjectContainer` for step definition dependency injection.

This example uses `FluentAssertions` for general should assertions.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="specFlow" type="TechTalk.SpecFlow.Configuration.ConfigurationSectionHandler, TechTalk.SpecFlow"/>
  </configSections>

  <specFlow>
    <unitTestProvider name="XUnit" />
  </specFlow>
</configuration>
```

```csharp
using System.Threading.Tasks;
using BoDi;
using TechTalk.SpecFlow;

namespace PuppeteerSharp.Contrib.Sample
{
    [Binding]
    public class Hooks
    {
        private IObjectContainer ObjectContainer { get; }
        private Browser Browser { get; set; }

        public Hooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            ObjectContainer.RegisterInstanceAs(Browser);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await Browser.CloseAsync();
        }
    }
}
```

```gherkin
Feature: PuppeteerSharpRepo

Scenario: Searching for the repo on GitHub
	Given I go to the GitHub start page
	When I search for "Puppeteer Sharp"
	Then the repo should be the first search result

Scenario: Master branch build status
	Given I go to the Puppeteer Sharp repo on GitHub
	When I check the build status on the master branch
	Then the build status should be success

Scenario: Latest release version
	Given I go to the Puppeteer Sharp repo on GitHub
	And I check the latest release version
	And I go to the Puppeteer repo on GitHub
	And I check the latest release version
	Then the latest release version should be up to date with Puppeteer
```

```csharp
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
            Page.QuerySelectorAsync("h1").ShouldHaveContent("Built for developers");
        }

        [When(@"I search for ""(.*)""")]
        public async Task WhenISearchFor(string query)
        {
            var input = await Page.QuerySelectorAsync("input.header-search-input");
            if (input.IsHidden()) await Page.ClickAsync(".octicon-three-bars");
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
            var link = await repository.QuerySelectorAsync("a");
            var text = await repository.QuerySelectorAsync("p");
            repository.ShouldHaveContent("kblok/puppeteer-sharp");
            text.ShouldHaveContent("Headless Chrome .NET API");
            await link.ClickAsync();
            await Page.WaitForNavigationAsync();

            Page.QuerySelectorAsync("h1").ShouldHaveContent("kblok/puppeteer-sharp");
            Page.Url.Should().Be("https://github.com/kblok/puppeteer-sharp");
        }

        [Given(@"I go to the Puppeteer Sharp repo on GitHub")]
        public async Task GivenIGoToThePuppeteerSharpRepoOnGitHub()
        {
            await Page.GoToAsync("https://github.com/kblok/puppeteer-sharp");
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
            var releases = await Page.QuerySelectorWithContentAsync("a", "releases");
            await releases.ClickAsync();
            await Page.WaitForNavigationAsync();

            var latest = await Page.QuerySelectorAsync(".release .release-header a");
            LatestReleaseVersion.Add(Page.Url, VersionWithoutPatch(latest.TextContent()));

            string VersionWithoutPatch(string version)
            {
                var tokens = version.Split(".".ToCharArray());
                return string.Join(".", tokens.Take(2));
            }
        }

        [Given(@"I go to the Puppeteer repo on GitHub")]
        public async Task GivenIGoToThePuppeteerRepoOnGitHub()
        {
            await Page.GoToAsync("https://github.com/GoogleChrome/puppeteer");
        }

        [Then(@"the latest release version should be up to date with Puppeteer")]
        public void ThenTheLatestReleaseVersionShouldBeUpToDateWithPuppeteer()
        {
            var puppeteerSharpVersion = LatestReleaseVersion["https://github.com/kblok/puppeteer-sharp/releases"];
            var puppeteerVersion = LatestReleaseVersion["https://github.com/GoogleChrome/puppeteer/releases"];

            puppeteerSharpVersion.Should().Be(puppeteerVersion);
        }
    }
}
```

## Attribution

Puppeteer Sharp Contributions is standing on the shoulders of giants.

It would not exist without https://github.com/kblok/puppeteer-sharp and https://github.com/GoogleChrome/puppeteer

Inspiration and experience has been drawn from the previous usage of https://github.com/featurist/coypu and https://github.com/stirno/FluentAutomation
