using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    public class ElementHandleExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

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
            Assert.That(await foo.IdAsync(), Is.EqualTo("foo"));

            var bar = await html.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.That(await bar.IdAsync(), Is.EqualTo("bar"));

            var flags = await html.QuerySelectorWithContentAsync("div", "foo", "i");
            Assert.That(await flags.IdAsync(), Is.EqualTo("foo"));

            var missing = await html.QuerySelectorWithContentAsync("div", "Missing");
            Assert.That(missing, Is.Null);
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
            Assert.That(await Task.WhenAll(divs.Select(x => x.IdAsync())), Is.EqualTo(new[] { "foo" }));

            divs = await html.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.That(await Task.WhenAll(divs.Select(x => x.IdAsync())), Is.EqualTo(new[] { "bar", "baz" }));

            var flags = await html.QuerySelectorAllWithContentAsync("div", "foo", "i");
            Assert.That(await Task.WhenAll(flags.Select(x => x.IdAsync())), Is.EqualTo(new[] { "foo" }));

            var missing = await html.QuerySelectorAllWithContentAsync("div", "Missing");
            Assert.That(missing, Is.Empty);
        }

        [Test]
        public async Task Exists_should_return_true_for_existing_element()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            Assert.That(tweet.Exists());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.That(missing.Exists(), Is.False);
        }

        [Test]
        public async Task InnerHtmlAsync_should_return_the_inner_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.That(await like.InnerHtmlAsync(), Is.EqualTo("100"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.InnerHtmlAsync());
        }

        [Test]
        public async Task OuterHtmlAsync_should_return_the_outer_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.That(await like.OuterHtmlAsync(), Is.EqualTo("<div class=\"like\">100</div>"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.OuterHtmlAsync());
        }

        [Test]
        public async Task TextContentAsync_should_return_the_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.That(await like.TextContentAsync(), Is.EqualTo("100"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.TextContentAsync());
        }

        [Test]
        public async Task InnerTextAsync_should_return_the_rendered_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.That(await like.InnerTextAsync(), Is.EqualTo("100"));

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
            Assert.That(await foo.HasContentAsync("Foo"));

            var bar = await Page.QuerySelectorAsync("#bar");
            Assert.That(await bar.HasContentAsync("ba."), Is.False);

            var flags = await Page.QuerySelectorAsync("html");
            Assert.That(await flags.HasContentAsync("ba.", "i"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasContentAsync(""));
        }

        [Test]
        public async Task ClassNameAsync_should_return_the_class_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.ClassNameAsync(), Is.EqualTo("foo bar"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.ClassNameAsync(), Is.Empty);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ClassNameAsync());
        }

        [Test]
        public async Task ClassListAsync_should_return_an_array_of_classes_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.ClassListAsync(), Is.EqualTo(new[] { "foo", "bar" }));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.ClassListAsync(), Is.Empty);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ClassListAsync());
        }

        [Test]
        public async Task HasClassAsync_should_return_true_if_the_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.HasClassAsync("foo"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.HasClassAsync(""), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasClassAsync(""));
        }

        [Test]
        public async Task IsSelectedAsync_should_return_true_if_the_element_is_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option><option id='baz'>Baz</option></select></body></html>");

            var option = await Page.QuerySelectorAsync("#foo");
            Assert.That(await option.IsSelectedAsync());

            await Page.SelectAsync("select", "Bar");
            option = await Page.QuerySelectorAsync("#bar");
            Assert.That(await option.IsSelectedAsync());

            option = await Page.QuerySelectorAsync("#baz");
            Assert.That(await option.IsSelectedAsync(), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsSelectedAsync());
        }

        [Test]
        public async Task IsCheckedAsync_should_return_true_if_the_element_is_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'><input type='checkbox' id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.IsCheckedAsync());

            await Page.ClickAsync("#bar");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.That(await input.IsCheckedAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.That(await input.IsCheckedAsync(), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsCheckedAsync());
        }

        [Test]
        public async Task IsDisabledAsync_should_return_true_if_the_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.IsDisabledAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').disabled = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.That(await input.IsDisabledAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.That(await input.IsDisabledAsync(), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsDisabledAsync());
        }

        [Test]
        public async Task IsEnabledAsync_should_return_false_if_the_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.IsEnabledAsync(), Is.False);

            await Page.EvaluateExpressionAsync("document.getElementById('bar').disabled = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.That(await input.IsEnabledAsync(), Is.False);

            input = await Page.QuerySelectorAsync("#baz");
            Assert.That(await input.IsEnabledAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsEnabledAsync());
        }

        [Test]
        public async Task IsReadOnlyAsync_should_return_true_if_the_element_is_readonly()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.IsReadOnlyAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').readOnly = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.That(await input.IsReadOnlyAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.That(await input.IsReadOnlyAsync(), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsReadOnlyAsync());
        }

        [Test]
        public async Task IsRequiredAsync_should_return_true_if_the_element_is_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.IsRequiredAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').required = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.That(await input.IsRequiredAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.That(await input.IsRequiredAsync(), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsRequiredAsync());
        }

        [Test]
        public async Task HasFocusAsync_should_return_true_if_the_element_has_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'><input id='baz'></body></html>", new() { WaitUntil = [WaitUntilNavigation.Networkidle0] });

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.HasFocusAsync());

            await Page.FocusAsync("#bar");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.That(await input.HasFocusAsync());

            input = await Page.QuerySelectorAsync("#baz");
            Assert.That(await input.HasFocusAsync(), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasFocusAsync());
        }

        [Test]
        public async Task IsEmptyAsync_should_return_true_if_the_element_is_empty()
        {
            await Page.SetContentAsync("<html><body><input id='foo'><input id='bar' value='input'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.That(await input.IsEmptyAsync());

            input = await Page.QuerySelectorAsync("#bar");
            Assert.That(await input.IsEmptyAsync(), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IsEmptyAsync());

            await Page.SetContentAsync("<html><body><div id='foo'> </div><div id='bar'>Text</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            Assert.That(await div.IsEmptyAsync());

            div = await Page.QuerySelectorAsync("#bar");
            Assert.That(await div.IsEmptyAsync(), Is.False);
        }
    }
}
