# PuppeteerSharp.Contrib.Should<!-- omit in toc -->

[![build](https://github.com/hlaueriksson/puppeteer-sharp-contrib/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/puppeteer-sharp-contrib/actions/workflows/build.yml) [![CodeFactor](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib/badge)](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib)

`PuppeteerSharp.Contrib.Should` is a should assertion library for the Puppeteer Sharp API.

## Content<!-- omit in toc -->

- [Should assertions for `IPage`](#should-assertions-for-ipage)
- [Should extensions for `IResponse`](#should-extensions-for-iresponse)
- [Should assertions for `IElementHandle`](#should-assertions-for-ielementhandle)
- [Failures](#failures)
- [Samples](#samples)

## Should assertions for `IPage`

- `ShouldHaveContentAsync`
- `ShouldHaveTitleAsync`
- `ShouldHaveUrlAsync`
- `ShouldNotHaveContentAsync`
- `ShouldNotHaveTitleAsync`
- `ShouldNotHaveUrlAsync`

## Should extensions for `IResponse`

- `ShouldBeRedirection`
- `ShouldBeSuccessful`
- `ShouldHaveClientError`
- `ShouldHaveError`
- `ShouldHaveServerError`
- `ShouldHaveStatusCode`
- `ShouldHaveUrl`
- `ShouldNotHaveStatusCode`
- `ShouldNotHaveUrl`

## Should assertions for `IElementHandle`

- `ShouldBeCheckedAsync`
- `ShouldBeDisabledAsync`
- `ShouldBeEmptyAsync`
- `ShouldBeEnabledAsync`
- `ShouldBeHiddenAsync`
- `ShouldBeReadOnlyAsync`
- `ShouldBeRequiredAsync`
- `ShouldBeSelectedAsync`
- `ShouldBeVisibleAsync`
- `ShouldExist`
- `ShouldHaveAttributeAsync`
- `ShouldHaveAttributeValueAsync`
- `ShouldHaveClassAsync`
- `ShouldHaveContentAsync`
- `ShouldHaveFocusAsync`
- `ShouldHaveValueAsync`
- `ShouldNotBeCheckedAsync`
- `ShouldNotBeEmptyAsync`
- `ShouldNotBeReadOnlyAsync`
- `ShouldNotBeRequiredAsync`
- `ShouldNotBeSelectedAsync`
- `ShouldNotExist`
- `ShouldNotHaveAttributeAsync`
- `ShouldNotHaveAttributeValueAsync`
- `ShouldNotHaveClassAsync`
- `ShouldNotHaveContentAsync`
- `ShouldNotHaveFocusAsync`
- `ShouldNotHaveValueAsync`

## Failures

The following failing examples will throw an exception with a message explaining why the assertion failed.

```csharp
await Page.SetContentAsync(@"
<html>
  <body>
   <div id='foo'>Foo</div>
  <body>
</html>");

var div = await Page.QuerySelectorAsync("#foo");
await div.ShouldHaveContentAsync("Bar");
```

> Expected element to have content "Bar", but it did not.

```csharp
await Page.SetContentAsync(@"
<html>
  <body>
   <form>
    <input id='foo' value='Foo' />
   </form>
  <body>
</html>");

var input = await Page.QuerySelectorAsync("#foo");
await input.ShouldHaveValueAsync("Bar", "that would be the perfect example");
```

> Expected element to have value "Bar" because that would be the perfect example, but found "Foo".

## Samples

Sample projects are located in the [`samples`](https://github.com/hlaueriksson/puppeteer-sharp-contrib/tree/master/samples) folder.

This is an example with `NUnit`:

```csharp
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Sample
{
    public class ShouldTests
    {
        IBrowser Browser { get; set; }
        IPage Page { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            await new BrowserFetcher().DownloadAsync();
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
");

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
