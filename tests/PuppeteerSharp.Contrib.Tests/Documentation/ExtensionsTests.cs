using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Documentation
{
    [Collection(PuppeteerFixture.Name)]
    public class ExtensionsTests : PuppeteerPageBaseTest
    {
        [Fact]
        public async Task Query()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar'>Bar</div>
  <div id='baz'>Baz</div>
</html>");

            var div = await Page.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.Equal("bar", div.Id());

            var divs = await Page.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.Equal(new[] { "bar", "baz" }, divs.Select(x => x.Id()));
        }

        [Fact]
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
            Assert.Equal("post", form.GetAttribute("method"));

            var input = await Page.QuerySelectorAsync("#name");
            Assert.True(input.HasAttribute("required"));

            var link = await Page.QuerySelectorAsync("a");
            Assert.Equal("/unsubscribe/", link.Href());

            input = await Page.QuerySelectorAsync("input[type=email]");
            Assert.Equal("email", input.Id());

            input = await Page.QuerySelectorAsync("#email");
            Assert.Equal("email", input.Name());

            var img = await Page.QuerySelectorAsync("img");
            Assert.Equal("unsubscribe.png", img.Src());

            input = await Page.QuerySelectorAsync("input[type=submit]");
            Assert.Equal("Subscribe!", input.Value());
        }

        [Fact]
        public async Task Class()
        {
            await Page.SetContentAsync("<div class='foo bar' />");

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal("foo bar", div.ClassName());
            Assert.Equal(new[] { "foo", "bar" }, div.ClassList());
            Assert.True(div.HasClass("bar"));
        }

        [Fact]
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
            Assert.True(html.HasContent("Foo"));

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal("\n    Foo\n    <span>Bar</span>\n  ", div.InnerHtml());
            Assert.Equal("<div>\n    Foo\n    <span>Bar</span>\n  </div>", div.OuterHtml());
            Assert.Equal("Foo Bar", div.InnerText());
            Assert.Equal("\n    Foo\n    Bar\n  ", div.TextContent());
        }

        [Fact]
        public async Task Visibility()
        {
            await Page.SetContentAsync("<div>Foo</div>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(div.Exists());
            Assert.False(div.IsHidden());
            Assert.True(div.IsVisible());
        }

        [Fact]
        public async Task Input()
        {
            await Page.SetContentAsync(@"
<form>
  <input type='text' autofocus>
  <input type='radio' readonly>
  <input type='checkbox' checked>
  <select>
    <option id='foo'>Foo</option>
    <option id='bar'>Bar</option>
  </select>
</form>
");

            var input = await Page.QuerySelectorAsync("input[type=text]");
            Assert.True(input.HasFocus());

            input = await Page.QuerySelectorAsync("input[type=checkbox]");
            Assert.True(input.IsChecked());

            input = await Page.QuerySelectorAsync("input[type=radio]");
            Assert.False(input.IsDisabled());
            Assert.True(input.IsEnabled());
            Assert.True(input.IsReadOnly());

            input = await Page.QuerySelectorAsync("#foo");
            Assert.True(input.IsSelected());
        }
    }
}