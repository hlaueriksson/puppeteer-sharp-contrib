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
        public async Task Value_should_return_the_value_of_the_element()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            Assert.Equal("input", await input.ValueAsync());

            var button = await Page.QuerySelectorAsync("button");
            Assert.Equal("button", button.Value());

            Assert.Equal("button", Page.QuerySelectorAsync("button").Value());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(body.Value());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.Value());
        }

        [Fact]
        public async Task Href_should_return_the_href_of_the_element()
        {
            await Page.SetContentAsync("<html><body><a href='file.html'></a><link href='file.css' /></body></html>");

            var a = await Page.QuerySelectorAsync("a");
            Assert.Equal("file.html", await a.HrefAsync());

            var link = await Page.QuerySelectorAsync("link");
            Assert.Equal("file.css", link.Href());

            Assert.Equal("file.css", Page.QuerySelectorAsync("link").Href());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(body.Href());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.Href());
        }

        [Fact]
        public async Task Src_should_return_the_src_of_the_element()
        {
            await Page.SetContentAsync("<html><body><img src='image.png' /><iframe src='file.html'></iframe></body></html>");

            var img = await Page.QuerySelectorAsync("img");
            Assert.Equal("image.png", await img.SrcAsync());

            var iframe = await Page.QuerySelectorAsync("iframe");
            Assert.Equal("file.html", iframe.Src());

            Assert.Equal("file.html", Page.QuerySelectorAsync("iframe").Src());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(body.Src());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.Src());
        }

        [Fact]
        public async Task HasAttribute_should_return_true_if_element_has_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(await div.HasAttributeAsync("class"));

            div = await Page.QuerySelectorAsync("div");
            Assert.True(div.HasAttribute("data-foo"));

            Assert.True(Page.QuerySelectorAsync("div").HasAttribute("data-foo"));

            div = await Page.QuerySelectorAsync("div");
            Assert.False(div.HasAttribute("id"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.False(body.HasAttribute(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.HasAttribute(""));
        }

        [Fact]
        public async Task GetAttribute_should_return_the_attribute_value_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.Equal("class", await div.GetAttributeAsync("class"));

            div = await Page.QuerySelectorAsync("div");
            Assert.Equal("bar", div.GetAttribute("data-foo"));

            Assert.Equal("bar", Page.QuerySelectorAsync("div").GetAttribute("data-foo"));

            div = await Page.QuerySelectorAsync("div");
            Assert.Null(div.GetAttribute("id"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(body.GetAttribute(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.GetAttribute(""));
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
    }
}