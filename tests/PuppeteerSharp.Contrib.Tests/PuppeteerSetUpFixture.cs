using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp;

/// <summary>
/// A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly.
/// </summary>
/// <seealso cref="https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html#notes"/>
[SetUpFixture]
public class PuppeteerSetUpFixture
{
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        using var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();
    }
}
