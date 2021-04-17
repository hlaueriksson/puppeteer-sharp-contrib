using System;
using System.Threading.Tasks;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests
{
    [CollectionDefinition(PuppeteerFixture.Name)]
    public class PuppeteerFixtureCollection : ICollectionFixture<PuppeteerFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class PuppeteerFixture : IDisposable
    {
        public const string Name = "PuppeteerFixture";

        public PuppeteerFixture()
        {
            SetUp().GetAwaiter().GetResult();
        }

        public void Dispose()
        {
        }

        private async Task SetUp()
        {
            await new BrowserFetcher().DownloadAsync();
        }
    }
}
