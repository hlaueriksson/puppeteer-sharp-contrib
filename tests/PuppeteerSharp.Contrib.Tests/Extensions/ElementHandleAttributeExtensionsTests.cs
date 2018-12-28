using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    public class ElementHandleAttributeExtensionsTests : PuppeteerPageBaseTest
    {
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
    }
}