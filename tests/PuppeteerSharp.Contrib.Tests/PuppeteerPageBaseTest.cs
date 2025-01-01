using System.Threading.Tasks;
using NUnit.Framework;

namespace PuppeteerSharp.Contrib.Tests
{
    public abstract class PuppeteerPageBaseTest
    {
        private IBrowser Browser { get; set; }
        private IBrowserContext Context { get; set; }
        protected IPage Page { get; private set; }

        [SetUp]
        public async Task CreatePageAsync()
        {
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            Context = await Browser.CreateBrowserContextAsync();
            Page = await Context.NewPageAsync();

            await SetUp();
        }

        [TearDown]
        public async Task ClosePageAsync()
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
