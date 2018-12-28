using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    public class ElementHandleExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        [Fact]
        public async Task Exists_should_return_true_for_existing_element()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            Assert.True(tweet.Exists());

            var tweetTask = Page.QuerySelectorAsync(".tweet");
            Assert.True(tweetTask.Exists());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.False(missing.Exists());

            var missingTask = Page.QuerySelectorAsync(".missing");
            Assert.False(missingTask.Exists());
        }

        [Fact]
        public async Task InnerHtml_should_return_the_inner_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("100", await like.InnerHtmlAsync());

            var retweets = await Page.QuerySelectorAsync(".retweets");
            Assert.Equal("10", retweets.InnerHtml());

            Assert.Equal("10", Page.QuerySelectorAsync(".retweets").InnerHtml());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.InnerHtml());
        }

        [Fact]
        public async Task OuterHtml_should_return_the_outer_html_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("<div class=\"like\">100</div>", await like.OuterHtmlAsync());

            var retweets = await Page.QuerySelectorAsync(".retweets");
            Assert.Equal("<div class=\"retweets\">10</div>", retweets.OuterHtml());

            Assert.Equal("<div class=\"retweets\">10</div>", Page.QuerySelectorAsync(".retweets").OuterHtml());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.OuterHtml());
        }

        [Fact]
        public async Task TextContent_should_return_the_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("100", await like.TextContentAsync());

            var retweets = await Page.QuerySelectorAsync(".retweets");
            Assert.Equal("10", retweets.TextContent());

            Assert.Equal("10", Page.QuerySelectorAsync(".retweets").TextContent());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.TextContent());
        }

        [Fact]
        public async Task InnerText_should_return_the_rendered_text_content_of_the_element()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.Equal("100", await like.InnerTextAsync());

            var retweets = await Page.QuerySelectorAsync(".retweets");
            Assert.Equal("10", retweets.InnerText());

            Assert.Equal("10", Page.QuerySelectorAsync(".retweets").InnerText());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.InnerText());
        }

        [Fact]
        public async Task HasContent_should_return_true_if_element_has_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            Assert.True(await like.HasContentAsync("100"));

            var retweets = await Page.QuerySelectorAsync(".retweets");
            Assert.True(retweets.HasContent("10"));

            Assert.True(Page.QuerySelectorAsync(".retweets").HasContent("10"));

            retweets = await Page.QuerySelectorAsync("div");
            Assert.False(retweets.HasContent("20"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.HasContent(""));
        }

        [Fact]
        public async Task ClassName_should_return_the_class_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal("foo bar", await div.ClassNameAsync());

            div = await Page.QuerySelectorAsync("div");
            Assert.Equal("foo bar", div.ClassName());

            Assert.Equal("foo bar", Page.QuerySelectorAsync("div").ClassName());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Empty(body.ClassName());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ClassName());
        }

        [Fact]
        public async Task ClassList_should_return_an_array_of_classes_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal(new[] { "foo", "bar" }, await div.ClassListAsync());

            div = await Page.QuerySelectorAsync("div");
            Assert.Equal(new[] { "foo", "bar" }, div.ClassList());

            Assert.Equal(new[] { "foo", "bar" }, Page.QuerySelectorAsync("div").ClassList());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Empty(body.ClassList());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ClassList());
        }

        [Fact]
        public async Task HasClass_should_return_true_if_the_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(await div.HasClassAsync("foo"));

            div = await Page.QuerySelectorAsync("div");
            Assert.True(div.HasClass("bar"));

            Assert.True(Page.QuerySelectorAsync("div").HasClass("foo"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.False(body.HasClass(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.HasClass(""));
        }

        [Fact]
        public async Task IsVisible_should_return_true_if_the_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div><div id='baz' style='visibility:hidden'>Baz</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            Assert.True(await div.IsVisibleAsync());

            div = await Page.QuerySelectorAsync("#bar");
            Assert.False(div.IsVisible());

            Assert.True(Page.QuerySelectorAsync("#baz").IsVisible()); // according to the jQuery implementation

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.IsVisible());
        }

        [Fact]
        public async Task IsHidden_should_return_false_if_the_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div><div id='baz' style='visibility:hidden'>Baz</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            Assert.False(await div.IsHiddenAsync());

            div = await Page.QuerySelectorAsync("#bar");
            Assert.True(div.IsHidden());

            Assert.False(Page.QuerySelectorAsync("#baz").IsHidden()); // according to the jQuery implementation

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.IsHidden());
        }

        [Fact]
        public async Task IsSelected_should_return_true_if_the_element_is_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option><option id='baz'>Baz</option></select></body></html>");

            var option = await Page.QuerySelectorAsync("#foo");
            Assert.True(await option.IsSelectedAsync());

            await Page.SelectAsync("select", "Bar");
            option = await Page.QuerySelectorAsync("#bar");
            Assert.True(option.IsSelected());

            Assert.False(Page.QuerySelectorAsync("#baz").IsSelected());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.IsSelected());
        }

        [Fact]
        public async Task IsChecked_should_return_true_if_the_element_is_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'><input type='checkbox' id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.IsCheckedAsync());

            await Page.ClickAsync("#bar");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(input.IsChecked());

            Assert.False(Page.QuerySelectorAsync("#baz").IsChecked());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.IsChecked());
        }

        [Fact]
        public async Task IsDisabled_should_return_true_if_the_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.IsDisabledAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').disabled = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(input.IsDisabled());

            Assert.False(Page.QuerySelectorAsync("#baz").IsDisabled());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.IsDisabled());
        }

        [Fact]
        public async Task IsEnabled_should_return_false_if_the_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.False(await input.IsEnabledAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').disabled = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.False(input.IsEnabled());

            Assert.True(Page.QuerySelectorAsync("#baz").IsEnabled());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.IsEnabled());
        }

        [Fact]
        public async Task IsReadOnly_should_return_true_if_the_element_is_readonly()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.IsReadOnlyAsync());

            await Page.EvaluateExpressionAsync("document.getElementById('bar').readOnly = true");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(input.IsReadOnly());

            Assert.False(Page.QuerySelectorAsync("#baz").IsReadOnly());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.IsReadOnly());
        }

        [Fact]
        public async Task HasFocus_should_return_true_if_the_element_has_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'><input id='baz'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            Assert.True(await input.HasFocusAsync());

            await Page.FocusAsync("#bar");
            input = await Page.QuerySelectorAsync("#bar");
            Assert.True(input.HasFocus());

            Assert.False(Page.QuerySelectorAsync("#baz").HasFocus());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.HasFocus());
        }
    }
}