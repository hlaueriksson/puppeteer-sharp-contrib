using System;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Tests.Base
{
    public class PuppeteerFixture : IDisposable
    {
        public PuppeteerFixture()
        {
            SetUp().GetAwaiter().GetResult();
        }

        public void Dispose()
        {
        }

        private async Task SetUp()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
        }
    }
}