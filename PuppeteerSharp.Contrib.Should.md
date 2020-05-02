# PuppeteerSharp.Contrib.Should

`PuppeteerSharp.Contrib.Should` is a should assertion library for the Puppeteer Sharp API.

## Content

- [PuppeteerSharp.Contrib.Should](#puppeteersharpcontribshould)
  - [Content](#content)
  - [Installation](#installation)
  - [Should assertions for `ElementHandle`](#should-assertions-for-elementhandle)
  - [Samples](#samples)

## Installation

| NuGet            |       | [![PuppeteerSharp.Contrib.Should][1]][2]                                       |
| :--------------- | ----: | :----------------------------------------------------------------------------- |
| Package Manager  | `PM>` | `Install-Package PuppeteerSharp.Contrib.Should -Version 1.0.0`                 |
| .NET CLI         | `>`   | `dotnet add package PuppeteerSharp.Contrib.Should --version 1.0.0`             |
| PackageReference |       | `<PackageReference Include="PuppeteerSharp.Contrib.Should" Version="1.0.0" />` |
| Paket CLI        | `>`   | `paket add PuppeteerSharp.Contrib.Should --version 1.0.0`                      |

[1]: https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Should.svg?label=PuppeteerSharp.Contrib.Should
[2]: https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should

## Should assertions for `ElementHandle`

* `ShouldBeCheckedAsync`
* `ShouldBeDisabledAsync`
* `ShouldBeEnabledAsync`
* `ShouldBeHiddenAsync`
* `ShouldBeReadOnlyAsync`
* `ShouldBeRequiredAsync`
* `ShouldBeSelectedAsync`
* `ShouldBeVisibleAsync`
* `ShouldExist`
* `ShouldHaveAttributeAsync`
* `ShouldHaveClassAsync`
* `ShouldHaveContentAsync`
* `ShouldHaveFocusAsync`
* `ShouldHaveValueAsync`
* `ShouldNotBeCheckedAsync`
* `ShouldNotBeReadOnlyAsync`
* `ShouldNotBeRequiredAsync`
* `ShouldNotBeSelectedAsync`
* `ShouldNotExist`
* `ShouldNotHaveAttributeAsync`
* `ShouldNotHaveClassAsync`
* `ShouldNotHaveContentAsync`
* `ShouldNotHaveFocusAsync`
* `ShouldNotHaveValueAsync`

## Samples

Sample projects are located in the [`samples`](/samples/) folder.

This is an example with `NUnit`:

```csharp
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Sample
{
    public class ShouldTests
    {
        Browser Browser { get; set; }
        Page Page { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            Page = await Browser.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
        }

        [Test]
        public async Task Attributes()
        {
            await Page.SetContentAsync("<div data-foo='bar' />");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveAttributeAsync("data-foo");
            await div.ShouldNotHaveAttributeAsync("data-bar");
        }

        [Test]
        public async Task Class()
        {
            await Page.SetContentAsync("<div class='foo' />");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveClassAsync("foo");
            await div.ShouldNotHaveClassAsync("bar");
        }

        [Test]
        public async Task Content()
        {
            await Page.SetContentAsync("<div>Foo</div>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveContentAsync("Foo");
            await div.ShouldNotHaveContentAsync("Bar");
        }

        [Test]
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
            await div.ShouldBeVisibleAsync();

            div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldBeHiddenAsync();
        }

        [Test]
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
", new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var input = await Page.QuerySelectorAsync("input[type=text]");
            await input.ShouldHaveFocusAsync();
            await input.ShouldBeRequiredAsync();
            await input.ShouldHaveValueAsync("Foo Bar");

            input = await Page.QuerySelectorAsync("input[type=radio]");
            await input.ShouldBeEnabledAsync();
            await input.ShouldBeReadOnlyAsync();

            input = await Page.QuerySelectorAsync("input[type=checkbox]");
            await input.ShouldBeCheckedAsync();

            input = await Page.QuerySelectorAsync("#foo");
            await input.ShouldBeSelectedAsync();
        }
    }
}
```
