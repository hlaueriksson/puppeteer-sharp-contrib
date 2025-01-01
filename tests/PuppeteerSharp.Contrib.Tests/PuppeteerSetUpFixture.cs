using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp;

/// <summary>
/// A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly.
/// </summary>
/// <seealso cref="https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html#notes"/>
[SetUpFixture]
#pragma warning disable CA1050 // Declare types in namespaces
public class PuppeteerSetUpFixture
#pragma warning restore CA1050 // Declare types in namespaces
{
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();
    }
}
