using System.Threading.Tasks;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Base
{
    public abstract class PuppeteerPageBaseTest : IClassFixture<PuppeteerFixture>, IAsyncLifetime
    {
        private Browser Browser { get; set; }
        private BrowserContext Context { get; set; }
        protected Page Page { get; private set; }

        public async Task InitializeAsync()
        {
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            Context = await Browser.CreateIncognitoBrowserContextAsync();
            Page = await Context.NewPageAsync();

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