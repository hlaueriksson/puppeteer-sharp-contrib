using System;
using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using NUnit.Framework;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    
    public class ElementHandleExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp () => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        [Test]
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
            Assert.AreEqual("foo", await foo.IdAsync());

            var bar = await html.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.AreEqual("bar", await bar.IdAsync());

            var flags = await html.QuerySelectorWithContentAsync("div", "foo", "i");
            Assert.AreEqual("foo", await flags.IdAsync());

            var missing = await html.QuerySelectorWithContentAsync("div", "Missing");
            Assert.Null(missing);
        }

        [Test]
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
            Assert.AreEqual(new[] { "foo" }, await Task.WhenAll(divs.Select(x => x.IdAsync())));

            divs = await html.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.AreEqual(new[] { "bar", "baz" }, await Task.WhenAll(divs.Select(x => x.IdAsync())));

            var flags = await html.QuerySelectorAllWithContentAsync("div", "foo", "i");
            Assert.AreEqual(new[] { "foo" }, await Task.WhenAll(flags.Select(x => x.IdAsync())));

            var missing = await html.QuerySelectorAllWithContentAsync("div", "Missing");
            Assert.IsEmpty(missing);
        }

        [Test]
        public async Task Exists_should_return_true_for_existing_element()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            Assert.True(tweet.Exists());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.False(missing.Exists());
        }

        [Test]
        public async Task InnerHtmlAsync_should_return_the_inner_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.AreEqual("100", await like.InnerHtmlAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.InnerHtmlAsync());
        }

        [Test]
        public async Task OuterHtmlAsync_should_return_the_outer_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.AreEqual("<div class=\"like\">100</div>", await like.OuterHtmlAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.OuterHtmlAsync());
        }

        [Test]
        public async Task TextContentAsync_should_return_the_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.AreEqual("100", await like.TextContentAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.TextContentAsync());
        }

        [Test]
        public async Task InnerTextAsync_should_return_the_rendered_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.AreEqual("100", await like.InnerTextAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.InnerTextAsync());
        }

        [Test]
        public async Task HasContentAsync_should_return_true_if_element_has_the_content()
        {
            await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar'>Bar</div>
  <div id='baz'>Baz</div>
</html>");

            var foo = await Page.QuerySelectorAsync("#foo");
            Assert.True(await foo.HasContentAsync("Foo"));

            var bar = await Page.QuerySelectorAsync("#bar");
            Assert.False(await bar.HasContentAsync("ba."));

            var flags = await Page.QuerySelectorAsync("html");
            Assert.True(await flags.HasContentAsync("ba.", "i"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasContentAsync(""));
        }

        [Test]
        public async Task ClassNameAsync_should_return_the_class_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.AreEqual("foo bar", await div.ClassNameAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.IsEmpty(await body.ClassNameAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ClassNameAsync());
        }

        [Test]
        public async Task ClassListAsync_should_return_an_array_of_classes_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.AreEqual(new[] { "foo", "bar" }, await div.ClassListAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.IsEmpty(await body.ClassListAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ClassListAsync());
        }

        [Test]
        public async Task HasClassAsync_should_return_true_if_the_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(await div.HasClassAsync("foo"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.False(await body.HasClassAsync(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasClassAsync(""));
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsVisibleAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsHiddenAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsSelectedAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsCheckedAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsDisabledAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsEnabledAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsReadOnlyAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsRequiredAsync());
        }

        [Test]
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
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasFocusAsync());
        }
    }
}
