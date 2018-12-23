using System.Threading.Tasks;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Base
{
    public abstract class PuppeteerPageBaseTest : IAsyncLifetime
    {
        public Browser Browser { get; private set; }
        public Page Page { get; private set; }

        public async Task InitializeAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            Page = await Browser.NewPageAsync();

            await SetUp();
        }

        public async Task DisposeAsync()
        {
            await TearDown();

            await Page.CloseAsync();
            await Browser.CloseAsync();
        }

        protected virtual async Task SetUp()
        {
            await Task.CompletedTask;
        }

        protected virtual async Task TearDown()
        {
            await Task.CompletedTask;
        }
    }
}