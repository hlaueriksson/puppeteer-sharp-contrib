using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Documentation
{
    public class ExtensionsTests : PuppeteerPageBaseTest
    {
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

            div = await Page.QuerySelectorAsync("div");
            Assert.Equal(new[] { "foo", "bar" }, div.ClassList());

            div = await Page.QuerySelectorAsync("div");
            Assert.True(div.HasClass("bar"));
        }

        [Fact]
        public async Task Content()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>
    Foo
    <div id='bar'>Bar</div>
  </div>
</html>
");

            var html = await Page.QuerySelectorAsync("html");
            Assert.True(html.HasContent("Foo"));

            var div = await Page.QuerySelectorAsync("#foo");
            Assert.Equal("\n    Foo\n    <div id=\"bar\">Bar</div>\n  ", div.InnerHtml());

            div = await Page.QuerySelectorAsync("#foo");
            Assert.Equal("Foo\nBar", div.InnerText());

            div = await Page.QuerySelectorAsync("#bar");
            Assert.Equal("<div id=\"bar\">Bar</div>", div.OuterHtml());

            div = await Page.QuerySelectorAsync("#foo");
            Assert.Equal("\n    Foo\n    Bar\n  ", div.TextContent());
        }

        [Fact]
        public async Task Visibility()
        {
            await Page.SetContentAsync("<div>Foo</div>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(div.Exists());

            div = await Page.QuerySelectorAsync("div");
            Assert.False(div.IsHidden());

            div = await Page.QuerySelectorAsync("div");
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

            input = await Page.QuerySelectorAsync("input[type=radio]");
            Assert.True(input.IsEnabled());

            input = await Page.QuerySelectorAsync("input[type=radio]");
            Assert.True(input.IsReadOnly());

            input = await Page.QuerySelectorAsync("#foo");
            Assert.True(input.IsSelected());
        }
    }
}