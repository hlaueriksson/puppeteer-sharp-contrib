using System.Threading.Tasks;
using BoDi;
using TechTalk.SpecFlow;

namespace PuppeteerSharp.Contrib.Sample
{
    [Binding]
    public class Hooks
    {
        private IObjectContainer ObjectContainer { get; }
        private Browser Browser { get; set; }

        public Hooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
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
