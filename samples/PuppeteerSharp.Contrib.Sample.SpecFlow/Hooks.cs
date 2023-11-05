using System.Threading.Tasks;
using BoDi;
using TechTalk.SpecFlow;

namespace PuppeteerSharp.Contrib.Sample
{
    [Binding]
    public class Hooks(IObjectContainer objectContainer)
    {
        private IObjectContainer ObjectContainer { get; } = objectContainer;
        private IBrowser Browser { get; set; }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await new BrowserFetcher().DownloadAsync();
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            ObjectContainer.RegisterInstanceAs(Browser);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await Browser.CloseAsync();
        }
    }
}
