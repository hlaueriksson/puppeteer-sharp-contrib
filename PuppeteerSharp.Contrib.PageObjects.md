# PuppeteerSharp.Contrib.PageObjects<!-- omit in toc -->

[![build](https://github.com/hlaueriksson/puppeteer-sharp-contrib/actions/workflows/build.yml/badge.svg)](https://github.com/hlaueriksson/puppeteer-sharp-contrib/actions/workflows/build.yml) [![CodeFactor](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib/badge)](https://www.codefactor.io/repository/github/hlaueriksson/puppeteer-sharp-contrib)

`PuppeteerSharp.Contrib.PageObjects` is a library for writing browser tests using the _page object pattern_ with the Puppeteer Sharp API.

## Content<!-- omit in toc -->

- [Page Objects](#page-objects)
- [Element Objects](#element-objects)
- [Selector Attributes](#selector-attributes)
- [Extensions for `IPage`](#extensions-for-ipage)
- [Extensions for `IElementHandle`](#extensions-for-ielementhandle)
- [Samples](#samples)
- [Further Reading](#further-reading)

## Page Objects

A page object wraps an [`PuppeteerSharp.IPage`](https://www.puppeteersharp.com/api/PuppeteerSharp.IPage.html) and should encapsulate the way tests interact with a web page.

Create page objects by inheriting `PageObject` and declare properties decorated with `[Selector]` attributes.

```csharp
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
```

## Element Objects

An element object wraps an [`PuppeteerSharp.IElementHandle`](https://www.puppeteersharp.com/api/PuppeteerSharp.IElementHandle.html) and should encapsulate the way tests interact with an element of a web page.

Create element objects by inheriting `ElementObject` and declare properties decorated with `[Selector]` attributes.

```csharp
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
```

## Selector Attributes

`[Selector]` attributes can be applied to properties on a `PageObject` or `ElementObject`.

Properties decorated with a `[Selector]` attribute must be a:

- public
- virtual
- asynchronous
- getter

that returns:

- `Task<IElementHandle>`
- `Task<IElementHandle[]>`
- `Task<ElementObject>` or
- `Task<ElementObject[]>`

Example:

```csharp
[Selector("#foo")]
public virtual Task<IElementHandle> SelectorForElementHandle { get; }

[Selector(".bar")]
public virtual Task<IElementHandle[]> SelectorForElementHandleArray { get; }

[Selector("#foo")]
public virtual Task<FooElementObject> SelectorForElementObject { get; }

[Selector(".bar")]
public virtual Task<BarElementObject[]> SelectorForElementObjectArray { get; }
```

## Extensions for `IPage`

Where `T` is a `PageObject`:

- `GoBackAsync<T>`
- `GoForwardAsync<T>`
- `GoToAsync<T>`
- `ReloadAsync<T>`
- `To<T>`
- `WaitForNavigationAsync<T>`
- `WaitForResponseAsync<T>`

Where `T` is an `ElementObject`:

- `QuerySelectorAllAsync<T>`
- `QuerySelectorAsync<T>`
- `WaitForSelectorAsync<T>`
- `WaitForXPathAsync<T>`
- `XPathAsync<T>`

## Extensions for `IElementHandle`

Where `T` is an `ElementObject`:

- `QuerySelectorAllAsync<T>`
- `QuerySelectorAsync<T>`
- `To<T>`
- `WaitForSelectorAsync<T>`
- `XPathAsync<T>`

## Samples

A sample project with `NUnit` is located in the [`samples`](https://github.com/hlaueriksson/puppeteer-sharp-contrib/tree/master/samples/PuppeteerSharp.Contrib.Sample.NUnit) folder:

- [`PageObjects.cs`](https://github.com/hlaueriksson/puppeteer-sharp-contrib/blob/master/samples/PuppeteerSharp.Contrib.Sample.NUnit/PageObjects.cs) contains the page and element objects
- [`PuppeteerSharpRepoPageObjectTests.cs`](https://github.com/hlaueriksson/puppeteer-sharp-contrib/blob/master/samples/PuppeteerSharp.Contrib.Sample.NUnit/PuppeteerSharpRepoPageObjectTests.cs) contains the tests using the page object pattern

## Further Reading

- https://martinfowler.com/bliki/PageObject.html
