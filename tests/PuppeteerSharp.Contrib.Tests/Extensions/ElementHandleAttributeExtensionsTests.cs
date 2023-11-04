using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{

    public class ElementHandleAttributeExtensionsTests : PuppeteerPageBaseTest
    {
        [Test]
        public async Task IdAsync_should_return_the_id_of_the_element()
        {
            await Page.SetContentAsync("<html><body><input id='foo' value='input' /><button id='bar' value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            Assert.AreEqual("foo", await input.IdAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(await body.IdAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IdAsync());
        }

        [Test]
        public async Task NameAsync_should_return_the_name_of_the_element()
        {
            await Page.SetContentAsync("<html><body><input name='foo' value='input' /><button name='bar' value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            Assert.AreEqual("foo", await input.NameAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(await body.NameAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.NameAsync());
        }

        [Test]
        public async Task ValueAsync_should_return_the_value_of_the_element()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            Assert.AreEqual("input", await input.ValueAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(await body.ValueAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ValueAsync());
        }

        [Test]
        public async Task HrefAsync_should_return_the_href_of_the_element()
        {
            await Page.SetContentAsync("<html><body><a href='file.html'></a><link href='file.css' /></body></html>");

            var a = await Page.QuerySelectorAsync("a");
            Assert.AreEqual("file.html", await a.HrefAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(await body.HrefAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HrefAsync());
        }

        [Test]
        public async Task SrcAsync_should_return_the_src_of_the_element()
        {
            await Page.SetContentAsync("<html><body><img src='image.png' /><iframe src='file.html'></iframe></body></html>");

            var img = await Page.QuerySelectorAsync("img");
            Assert.AreEqual("image.png", await img.SrcAsync());

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(await body.SrcAsync());

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.SrcAsync());
        }

        [Test]
        public async Task HasAttributeAsync_should_return_true_if_element_has_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.True(await div.HasAttributeAsync("class"));

            div = await Page.QuerySelectorAsync("div");
            Assert.False(await div.HasAttributeAsync("id"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.False(await body.HasAttributeAsync(null));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasAttributeAsync(""));
        }

        [Test]
        public async Task GetAttributeAsync_should_return_the_attribute_value_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.AreEqual("class", await div.GetAttributeAsync("class"));

            div = await Page.QuerySelectorAsync("div");
            Assert.Null(await div.GetAttributeAsync("id"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.Null(await body.GetAttributeAsync(null));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.GetAttributeAsync(""));
        }
    }
}
