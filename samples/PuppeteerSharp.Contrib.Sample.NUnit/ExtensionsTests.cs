using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Sample
{
    public class ExtensionsTests
    {
        IBrowser Browser { get; set; }
        IPage Page { get; set; }

        [SetUp]
        public async Task SetUp()
        {
            await new BrowserFetcher().DownloadAsync();
            Browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            Page = await Browser.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
        }

        [Test]
        public async Task Query()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar'>Bar</div>
  <div id='baz'>Baz</div>
</html>");

            var html = await Page.QuerySelectorAsync("html");

            var div = await Page.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.That(await div.IdAsync(), Is.EqualTo("bar"));

            div = await html.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.That(await div.IdAsync(), Is.EqualTo("bar"));

            var divs = await Page.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.That(await Task.WhenAll(divs.Select(x => x.IdAsync())), Is.EqualTo(new[] { "bar", "baz" }));

            divs = await html.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.That(await Task.WhenAll(divs.Select(x => x.IdAsync())), Is.EqualTo(new[] { "bar", "baz" }));
        }

        [Test]
        public async Task Attributes()
        {
            await Page.SetContentAsync(@"
<html>
  <form method='post'>
      Name: <input type='text' name='name' id='name' required>
      Email: <input type='email' name='email' id='email' required>
      <input type='submit' value='Subscribe!'>
  </form>
  <img src='unsubscribe.png' />
  <a href='/unsubscribe/'>Unsubscribe</a>
</html>");

            var form = await Page.QuerySelectorAsync("form");
            Assert.That(await form.GetAttributeAsync("method"), Is.EqualTo("post"));

            var input = await Page.QuerySelectorAsync("#name");
            Assert.That(await input.HasAttributeAsync("required"));

            var link = await Page.QuerySelectorAsync("a");
            Assert.That(await link.HrefAsync(), Is.EqualTo("/unsubscribe/"));

            input = await Page.QuerySelectorAsync("input[type=email]");
            Assert.That(await input.IdAsync(), Is.EqualTo("email"));

            input = await Page.QuerySelectorAsync("#email");
            Assert.That(await input.NameAsync(), Is.EqualTo("email"));

            var img = await Page.QuerySelectorAsync("img");
            Assert.That(await img.SrcAsync(), Is.EqualTo("unsubscribe.png"));

            input = await Page.QuerySelectorAsync("input[type=submit]");
            Assert.That(await input.ValueAsync(), Is.EqualTo("Subscribe!"));
        }

        [Test]
        public async Task Class()
        {
            await Page.SetContentAsync("<div class='foo bar' />");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.ClassNameAsync(), Is.EqualTo("foo bar"));
            Assert.That(await div.ClassListAsync(), Is.EqualTo(new[] { "foo", "bar" }));
            Assert.That(await div.HasClassAsync("bar"));
        }

        [Test]
        public async Task Content()
        {
            await Page.SetContentAsync(@"
<html>
  <div>
    Foo
    <span>Bar</span>
  </div>
</html>
");

            var html = await Page.QuerySelectorAsync("html");
            Assert.That(await html.HasContentAsync("Foo"));

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.InnerHtmlAsync(), Is.EqualTo("\n    Foo\n    <span>Bar</span>\n  "));
            Assert.That(await div.OuterHtmlAsync(), Is.EqualTo("<div>\n    Foo\n    <span>Bar</span>\n  </div>"));
            Assert.That(await div.InnerTextAsync(), Is.EqualTo("Foo Bar"));
            Assert.That(await div.TextContentAsync(), Is.EqualTo("\n    Foo\n    Bar\n  "));
        }

        [Test]
        public async Task Existentiality()
        {
            await Page.SetContentAsync("<div>Foo</div>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(div.Exists());
        }

        [Test]
        public async Task Input()
        {
            await Page.SetContentAsync(@"
<form>
  <input type='text' autofocus required>
  <input type='radio' readonly>
  <input type='checkbox' checked>
  <select>
    <option id='foo'>Foo</option>
    <option id='bar'>Bar</option>
  </select>
</form>
");

            var input = await Page.QuerySelectorAsync("input[type=text]");
            Assert.That(await input.HasFocusAsync());
            Assert.That(await input.IsRequiredAsync());

            input = await Page.QuerySelectorAsync("input[type=radio]");
            Assert.That(await input.IsDisabledAsync(), Is.False);
            Assert.That(await input.IsEnabledAsync());
            Assert.That(await input.IsReadOnlyAsync());

            input = await Page.QuerySelectorAsync("input[type=checkbox]");
            Assert.That(await input.IsCheckedAsync());

            input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.IsSelectedAsync());
        }
    }
}
