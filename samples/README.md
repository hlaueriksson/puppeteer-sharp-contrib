# Puppeteer Sharp Contributions Samples

The sample projects are divided into test frameworks used:

* `PuppeteerSharp.Contrib.Sample.Machine.Specifications`
* `PuppeteerSharp.Contrib.Sample.MSTest`
* `PuppeteerSharp.Contrib.Sample.NUnit`
* `PuppeteerSharp.Contrib.Sample.SpecFlow`
* `PuppeteerSharp.Contrib.Sample.Xunit`

All projects runs the following scenarios:

1. Search for Puppeteer Sharp on GitHub
2. Check that the Puppeteer Sharp master branch builds
3. Compare the Puppeteer and Puppeteer Sharp versions

## Content

- [Puppeteer Sharp Contributions Samples](#puppeteer-sharp-contributions-samples)
  - [Content](#content)
  - [Machine.Specifications](#machinespecifications)
  - [MSTest](#mstest)
  - [NUnit](#nunit)
  - [SpecFlow](#specflow)
  - [Xunit](#xunit)

## Machine.Specifications

* [`PuppeteerSharpRepoSpecs.cs`](/samples/PuppeteerSharp.Contrib.Sample.Machine.Specifications/PuppeteerSharpRepoSpecs.cs) contains specs using the `PuppeteerSharp.Contrib.Extensions` + `PuppeteerSharp.Contrib.Should` libraries

Machine.Specifications **does not** support `async` / `await`.

You can work around this limitation with the [`Await`](https://github.com/machine/machine.specifications/blob/master/src/Machine.Specifications/TaskSpecificationExtensions.cs#L28) and [`Await<T>`](https://github.com/machine/machine.specifications/blob/master/src/Machine.Specifications/TaskSpecificationExtensions.cs#L10) extension methods.

:heavy_check_mark: You may use the _sync_ versions of the extension methods from `PuppeteerSharp.Contrib.Extensions` and `PuppeteerSharp.Contrib.Should`.

## MSTest

* [`PuppeteerSharpRepoTests.cs`](/samples/PuppeteerSharp.Contrib.Sample.MSTest/PuppeteerSharpRepoTests.cs) contains tests using the `PuppeteerSharp.Contrib.Extensions` + `PuppeteerSharp.Contrib.Should` libraries

MSTest supports `async` / `await`.

:exclamation: You must use the **async** versions of the extension methods from `PuppeteerSharp.Contrib.Extensions` and `PuppeteerSharp.Contrib.Should`!

## NUnit

* [`PuppeteerSharpRepoTests.cs`](/samples/PuppeteerSharp.Contrib.Sample.NUnit/PuppeteerSharpRepoTests.cs) contains tests using the `PuppeteerSharp.Contrib.Extensions` + `PuppeteerSharp.Contrib.Should` libraries
* [`PageObjects.cs`](/samples/PuppeteerSharp.Contrib.Sample.NUnit/PageObjects.cs) and [`PuppeteerSharpRepoPageObjectTests.cs`](/samples/PuppeteerSharp.Contrib.Sample.NUnit/PuppeteerSharpRepoTests.cs) contains tests using the page object pattern with `PuppeteerSharp.Contrib.PageObjects`

NUnit supports `async` / `await`.

:exclamation: You must use the **async** versions of the extension methods from `PuppeteerSharp.Contrib.Extensions` and `PuppeteerSharp.Contrib.Should`!

## SpecFlow

* [`PuppeteerSharpRepoSteps.cs`](/samples/PuppeteerSharp.Contrib.Sample.SpecFlow/StepDefinitions/PuppeteerSharpRepoSteps.cs) contains step definitions using the `PuppeteerSharp.Contrib.Extensions` + `PuppeteerSharp.Contrib.Should` libraries

SpecFlow supports `async` / `await`.

:heavy_check_mark: You may use the _sync_ versions of the extension methods from `PuppeteerSharp.Contrib.Extensions` and `PuppeteerSharp.Contrib.Should` if you use **Xunit** as the unit test provider!

## Xunit

* [`PuppeteerSharpRepoTests.cs`](/samples/PuppeteerSharp.Contrib.Sample.Xunit/PuppeteerSharpRepoTests.cs) contains tests using the `PuppeteerSharp.Contrib.Extensions` + `PuppeteerSharp.Contrib.Should` libraries

Xunit supports `async` / `await`.

:heavy_check_mark: You may use the _sync_ versions of the extension methods from `PuppeteerSharp.Contrib.Extensions` and `PuppeteerSharp.Contrib.Should`.
