# PuppeteerSharp.Contrib.PageObjects

`PuppeteerSharp.Contrib.PageObjects` is a library for writing browser tests using the _page object pattern_ with the Puppeteer Sharp API.

## Content

- [PuppeteerSharp.Contrib.PageObjects](#puppeteersharpcontribpageobjects)
  - [Content](#content)
  - [Installation](#installation)
  - [Page Objects](#page-objects)
  - [Element Objects](#element-objects)
  - [Selector Attributes](#selector-attributes)
  - [XPath Attributes](#xpath-attributes)
  - [Extensions for `Page`](#extensions-for-page)
  - [Extensions for `ElementHandle`](#extensions-for-elementhandle)
  - [Samples](#samples)
  - [Further Reading](#further-reading)

## Installation

TODO

## Page Objects

A page object wraps a [`PuppeteerSharp.Page`](https://www.puppeteersharp.com/api/PuppeteerSharp.Page.html) and should encapsulate the way tests interact with a web page.

Create page objects by inheriting `PageObject` and declare properties decorated with `[Selector]` or `[XPath]` attributes.

```csharp
public class GitHubStartPage : PageObject
{
    [Selector("h1")]
    public virtual Task<ElementHandle> Heading { get; }

    [Selector(".HeaderMenu")]
    public virtual Task<GitHubHeaderMenu> HeaderMenu { get; }
}
```

## Element Objects

An element object wraps an [`PuppeteerSharp.ElementHandle`](https://www.puppeteersharp.com/api/PuppeteerSharp.ElementHandle.html) and should encapsulate the way tests interact with an element of a web page.

Create element objects by inheriting `ElementObject` and declare properties decorated with `[Selector]` or `[XPath]` attributes.

```csharp
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
```

## Selector Attributes

`[Selector]` attributes can be applied to properties on a `PageObject` or `ElementObject`.

Properties decorated with a `[Selector]` attribute must be a:

* public
* virtual
* asynchronous
* getter

that returns:

* `Task<ElementHandle>`
* `Task<ElementHandle[]>`
* `Task<ElementObject>` or
* `Task<ElementObject[]>`

Example:

```csharp
[Selector("#foo")]
public virtual Task<ElementHandle> SelectorForElementHandle { get; }

[Selector(".bar")]
public virtual Task<ElementHandle[]> SelectorForElementHandleArray { get; }

[Selector("#foo")]
public virtual Task<FooElementObject> SelectorForElementObject { get; }

[Selector(".bar")]
public virtual Task<BarElementObject[]> SelectorForElementObjectArray { get; }
```

## XPath Attributes

`[XPath]` attributes can be applied to properties on a `PageObject` or `ElementObject`.

Properties decorated with a `[XPath]` attribute must be a:

* public
* virtual
* asynchronous
* getter

that returns:

* `Task<ElementHandle[]>` or
* `Task<ElementObject[]>`

Example:

```csharp
[XPath("//div")]
public virtual Task<ElementHandle[]> XPathForElementHandleArray { get; }

[XPath("//div")]
public virtual Task<FooElementObject[]> XPathForElementObjectArray { get; }
```

## Extensions for `Page`

Where `T` is a `PageObject`:

* `GoToAsync<T>`
* `WaitForNavigationAsync<T>`

Where `T` is an `ElementObject`:

* `QuerySelectorAllAsync<T>`
* `QuerySelectorAsync<T>`
* `WaitForSelectorAsync<T>`
* `WaitForXPathAsync<T>`
* `XPathAsync<T>`

## Extensions for `ElementHandle`

Where `T` is an `ElementObject`:

* `QuerySelectorAllAsync<T>`
* `QuerySelectorAsync<T>`
* `XPathAsync<T>`

## Samples

A sample project with `NUnit` is located in the [`samples/PuppeteerSharp.Contrib.Sample.NUnit`](/samples/PuppeteerSharp.Contrib.Sample.NUnit/) folder:

* [`PageObjects.cs`](/samples/PuppeteerSharp.Contrib.Sample.NUnit/PageObjects.cs) contains the page and element objects
* [`PuppeteerSharpRepoPageObjectTests.cs`](/samples/PuppeteerSharp.Contrib.Sample.NUnit/PuppeteerSharpRepoPageObjectTests.cs) contains the tests using the page object pattern

## Further Reading

* https://martinfowler.com/bliki/PageObject.html
