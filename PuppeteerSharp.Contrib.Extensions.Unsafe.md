# PuppeteerSharp.Contrib.Extensions.Unsafe

`PuppeteerSharp.Contrib.Extensions.Unsafe` is a library with convenient extension methods for writing browser tests with the Puppeteer Sharp API.

:warning: These extension methods are the _sync over async_ versions of the originals from the [PuppeteerSharp.Contrib.Extensions](PuppeteerSharp.Contrib.Extensions.md) package.
They may be convenient, but can be considered _unsafe_ since you [run the risk of a deadlock](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md#avoid-using-taskresult-and-taskwait).

:heavy_check_mark: Works with:

* [Machine.Specifications](https://www.nuget.org/packages/Machine.Specifications/)
* [SpecFlow.xUnit](https://www.nuget.org/packages/SpecFlow.xUnit/)
* [xunit](https://www.nuget.org/packages/xunit/)

:x: Fails with:

* [MSTest](https://www.nuget.org/packages/MSTest.TestFramework/)
* [NUnit](https://www.nuget.org/packages/NUnit/)
* [SpecFlow.NUnit](https://www.nuget.org/packages/SpecFlow.NUnit/)

## Installation

TODO

## Extensions for `ElementHandle`

Attributes:

* `ClassList`
* `ClassName`
* `GetAttribute`
* `Href`
* `Id`
* `Name`
* `Src`
* `Value`

Content:

* `InnerHtml`
* `InnerText`
* `OuterHtml`
* `TextContent`

Evaluation:

* `Exists`
* `HasAttribute`
* `HasClass`
* `HasContent`
* `HasFocus`
* `IsChecked`
* `IsDisabled`
* `IsEnabled`
* `IsHidden`
* `IsReadOnly`
* `IsRequired`
* `IsSelected`
* `IsVisible`
