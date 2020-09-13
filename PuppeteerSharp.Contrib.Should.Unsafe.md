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

| NuGet            |       | [![PuppeteerSharp.Contrib.Should.Unsafe][1]][2]                                       |
| :--------------- | ----: | :------------------------------------------------------------------------------------ |
| Package Manager  | `PM>` | `Install-Package PuppeteerSharp.Contrib.Should.Unsafe -Version 3.0.0`                 |
| .NET CLI         | `>`   | `dotnet add package PuppeteerSharp.Contrib.Should.Unsafe --version 3.0.0`             |
| PackageReference |       | `<PackageReference Include="PuppeteerSharp.Contrib.Should.Unsafe" Version="3.0.0" />` |
| Paket CLI        | `>`   | `paket add PuppeteerSharp.Contrib.Should.Unsafe --version 3.0.0`                      |

[1]: https://img.shields.io/nuget/v/PuppeteerSharp.Contrib.Should.Unsafe.svg?label=PuppeteerSharp.Contrib.Should.Unsafe
[2]: https://www.nuget.org/packages/PuppeteerSharp.Contrib.Should.Unsafe

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
