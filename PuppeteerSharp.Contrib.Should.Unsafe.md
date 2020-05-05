# PuppeteerSharp.Contrib.Should.Unsafe

`PuppeteerSharp.Contrib.Should.Unsafe` is a should assertion library for the Puppeteer Sharp API.

:warning: These extension methods are the _sync over async_ versions of the originals from the [PuppeteerSharp.Contrib.Should](PuppeteerSharp.Contrib.Should.md) package.
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

## Should assertions for `ElementHandle`

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
