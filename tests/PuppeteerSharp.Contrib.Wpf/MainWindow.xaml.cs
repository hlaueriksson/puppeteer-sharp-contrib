using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Browser Browser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var url = Url.Text;
            var selector = Selector.Text;

            await InitializeAsync();

            var page = await GetPage(url);
            var element = await GetElement(page, selector);

            TextBox.Text = GetText();

            await DisposeAsync();

            string GetText()
            {
                var result = new StringBuilder();
                result.AppendLine("Url: " + url);
                result.AppendLine("Selector: " + selector);
                result.AppendLine();

                if (element == null) return result.ToString();

                result.AppendLine("Id: " + element.Id());
                result.AppendLine("ClassName: " + element.ClassName());
                result.AppendLine("InnerHtml: " + element.InnerHtml());
                result.AppendLine("OuterHtml: " + element.OuterHtml());
                result.AppendLine("InnerText: " + element.InnerText());
                result.AppendLine("TextContent: " + element.TextContent());
                return result.ToString();
            }
        }

        private async Task InitializeAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision).ConfigureAwait(false);
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            }).ConfigureAwait(false);
        }

        private async Task DisposeAsync()
        {
            await Browser.CloseAsync().ConfigureAwait(false);
        }

        private async Task<Page> GetPage(string url)
        {
            var page = await Browser.NewPageAsync().ConfigureAwait(false);
            await page.GoToAsync(url).ConfigureAwait(false);

            return page;
        }

        private async Task<ElementHandle> GetElement(Page page, string selector)
        {
            return await page.QuerySelectorAsync(selector).ConfigureAwait(false);
        }
    }
}