using System;
using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    [Collection(PuppeteerFixture.Name)]
    public class ElementHandleExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        [Fact]
        public async Task QuerySelectorWithContentAsync_should_return_the_first_element_that_match_the_selector_and_has_the_content()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar'>Bar</div>
  <div id='baz'>Baz</div>
</html>");

            var html = await Page.QuerySelectorAsync("html");

            var foo = await html.QuerySelectorWithContentAsync("div", "Foo");
            Assert.Equal("foo", await foo.IdAsync());

            var bar = await html.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.Equal("bar", await bar.IdAsync());

            var missing = await html.QuerySelectorWithContentAsync("div", "Missing");
            Assert.Null(missing);
        }

        [Fact]
        public async Task QuerySelectorAllWithContentAsync_should_return_all_elements_that_match_the_selector_and_has_the_content()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar'>Bar</div>
  <div id='baz'>Baz</div>
</html>");

            var html = await Page.QuerySelectorAsync("html");

            var divs = await html.QuerySelectorAllWithContentAsync("div", "Foo");
            Assert.Equal(new[] { "foo" }, await Task.WhenAll(divs.Select(x => x.IdAsync())));

            divs = await html.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.Equal(new[] { "bar", "baz" }, await Task.WhenAll(divs.Select(x => x.IdAsync())));

            var missing = await html.QuerySelectorAllWithContentAsync("div", "Missing");
            Assert.Empty(missing);
        }

        [Fact]
        public async Task Exists_should_return_true_for_existing_element()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            Assert.True(tweet.Exists());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.False(missing.Exists());
        }

        [Fact]
        public async Task InnerHtmlAsync_should_return_the_inner_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("100", await like.InnerHtmlAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.InnerHtmlAsync());
        }

        [Fact]
        public async Task OuterHtmlAsync_should_return_the_outer_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("<div class=\"like\">100</div>", await like.OuterHtmlAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.OuterHtmlAsync());
        }

        [Fact]
        public async Task TextContentAsync_should_return_the_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("100", await like.TextContentAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.TextContentAsync());
        }

        [Fact]
        public async Task InnerTextAsync_should_return_the_rendered_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("100", await like.InnerTextAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.InnerTextAsync());
        }

        [Fact]
        public async Task HasContentAsync_should_return_true_if_element_has_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.True(await like.HasContentAsync("100"));

            var retweets = await Page.QuerySelectorAsync("div");
            Assert.False(await retweets.HasContentAsync("20"));

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.HasContentAsync(""));
        }

        [Fact]
        public async Task ClassNameAsync_should_return_the_class_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal("foo bar", await div.ClassNameAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Empty(await body.ClassNameAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ClassNameAsync());
        }

        [Fact]
        public async Task ClassListAsync_should_return_an_array_of_classes_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal(new[] { "foo", "bar" }, await div.ClassListAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Empty(await body.ClassListAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ClassListAsync());
        }

        [Fact]
        public async Task HasClassAsync_should_return_true_if_the_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(await div.HasClassAsync("foo"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.False(await body.HasClassAsync(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.HasClassAsync(""));
        }

        [Fact]
        public async Task IsVisibleAsync_should_return_true_if_the_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div><div id='baz' style='visibility:hidden'>Baz</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            Assert.True(await div.IsVisibleAsync());

            div = await Page.QuerySelectorAsync("#bar");
            Assert.False(await div.IsVisibleAsync());

            div = await Page.QuerySelectorAsync("#baz");
            Assert.True(await div.IsVisibleAsync()); // according to the jQuery implementation

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsVisibleAsync());
        }

        [Fact]
        public async Task IsHiddenAsync_should_return_false_if_the_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div><div id='baz' style='visibility:hidden'>Baz</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            Assert.False(await div.IsHiddenAsync());

            div = await Page.QuerySelectorAsync("#bar");
            Assert.True(await div.IsHiddenAsync());

            div = await Page.QuerySelectorAsync("#baz");
            Assert.False(await div.IsHiddenAsync()); // according to the jQuery implementation

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsHiddenAsync());
        }

        [Fact]
        public async Task IsSelectedAsync_should_return_true_if_the_element_is_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option><option id='baz'>Baz</option></select></body></html>");

            var option = await Page.QuerySelectorAsync("#foo");
            Assert.True(await option.IsSelectedAsync());

            await Page.SelectAsync("select", "Bar");
            option = await Page.QuerySelectorAsync("#bar");
            Assert.True(await option.IsSelectedAsync());

            option = await Page.QuerySelectorAsync("#baz");
            Assert.False(await option.IsSelectedAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsSelectedAsync());
        }

        [Fact]
        public async Task IsCheckedAsync_should_return_true_if_the_element_is_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'><input type='checkbox' id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.IsCheckedAsync());

            await Page.ClickAsync("#bar");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(await input.IsCheckedAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.False(await input.IsCheckedAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsCheckedAsync());
        }

        [Fact]
        public async Task IsDisabledAsync_should_return_true_if_the_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.IsDisabledAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').disabled = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(await input.IsDisabledAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.False(await input.IsDisabledAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsDisabledAsync());
        }

        [Fact]
        public async Task IsEnabledAsync_should_return_false_if_the_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.False(await input.IsEnabledAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').disabled = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.False(await input.IsEnabledAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.True(await input.IsEnabledAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsEnabledAsync());
        }

        [Fact]
        public async Task IsReadOnlyAsync_should_return_true_if_the_element_is_readonly()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.IsReadOnlyAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').readOnly = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(await input.IsReadOnlyAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.False(await input.IsReadOnlyAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsReadOnlyAsync());
        }

        [Fact]
        public async Task IsRequiredAsync_should_return_true_if_the_element_is_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.IsRequiredAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').required = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(await input.IsRequiredAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.False(await input.IsRequiredAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.IsRequiredAsync());
        }

        [Fact]
        public async Task HasFocusAsync_should_return_true_if_the_element_has_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'><input id='baz'></body></html>", new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.HasFocusAsync());

            await Page.FocusAsync("#bar");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(await input.HasFocusAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.False(await input.HasFocusAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.HasFocusAsync());
        }
    }
}
