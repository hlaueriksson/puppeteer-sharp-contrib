using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Documentation
{
    public class ShouldTests : IAsyncLifetime// : PuppeteerPageBaseTest
    {
        private Browser Browser { get; set; }
        private BrowserContext Context { get; set; }
        private Page Page { get; set; }

        public async Task InitializeAsync()
        {
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            Context = await Browser.CreateIncognitoBrowserContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            await Page.CloseAsync();
            await Browser.CloseAsync();
        }

        [Fact]
        public async Task Attributes()
        {
            await Page.SetContentAsync("<div data-foo='bar' />");

            var div = await Page.QuerySelectorAsync("div");
            div
                .ShouldHaveAttribute("data-foo")
                .ShouldNotHaveAttribute("data-bar");
        }

        [Fact]
        public async Task Class()
        {
            await Page.SetContentAsync("<div class='foo' />");

            var div = await Page.QuerySelectorAsync("div");
            div
                .ShouldHaveClass("foo")
                .ShouldNotHaveClass("bar");
        }

        [Fact]
        public async Task Content()
        {
            await Page.SetContentAsync("<div>Foo</div>");

            var div = await Page.QuerySelectorAsync("div");
            div
                .ShouldHaveContent("Foo")
                .ShouldNotHaveContent("Bar");
        }

        [Fact]
        public async Task Visibility()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar' style='display:none'>Bar</div>
</html>");

            var html = await Page.QuerySelectorAsync("html");
            html.ShouldExist();

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeVisible();

            div = await Page.QuerySelectorAsync("#bar");
            div.ShouldBeHidden();
        }


        [Fact]
        public async Task Input()
        {
            await Page.SetContentAsync(@"
<form>
  <input type='text' autofocus value='Foo Bar'>
  <input type='radio' readonly>
  <input type='checkbox' checked>
  <select>
    <option id='foo'>Foo</option>
    <option id='bar'>Bar</option>
  </select>
</form>
");

            var input = await Page.QuerySelectorAsync("input[type=checkbox]");
            input.ShouldBeChecked();

            input = await Page.QuerySelectorAsync("input[type=radio]");
            input
                .ShouldBeEnabled()
                .ShouldBeReadOnly();

            input = await Page.QuerySelectorAsync("#foo");
            input.ShouldBeSelected();

            input = await Page.QuerySelectorAsync("input[type=text]");
            input
                .ShouldHaveFocus()
                .ShouldHaveValue("Foo Bar");
        }
    }
}