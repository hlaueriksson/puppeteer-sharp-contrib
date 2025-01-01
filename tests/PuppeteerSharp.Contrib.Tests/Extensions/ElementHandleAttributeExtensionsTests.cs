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
            Assert.That(await input.IdAsync(), Is.EqualTo("foo"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.IdAsync(), Is.Null);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.IdAsync());
        }

        [Test]
        public async Task NameAsync_should_return_the_name_of_the_element()
        {
            await Page.SetContentAsync("<html><body><input name='foo' value='input' /><button name='bar' value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            Assert.That(await input.NameAsync(), Is.EqualTo("foo"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.NameAsync(), Is.Null);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.NameAsync());
        }

        [Test]
        public async Task ValueAsync_should_return_the_value_of_the_element()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            Assert.That(await input.ValueAsync(), Is.EqualTo("input"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.ValueAsync(), Is.Null);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ValueAsync());
        }

        [Test]
        public async Task HrefAsync_should_return_the_href_of_the_element()
        {
            await Page.SetContentAsync("<html><body><a href='file.html'></a><link href='file.css' /></body></html>");

            var a = await Page.QuerySelectorAsync("a");
            Assert.That(await a.HrefAsync(), Is.EqualTo("file.html"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.HrefAsync(), Is.Null);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HrefAsync());
        }

        [Test]
        public async Task SrcAsync_should_return_the_src_of_the_element()
        {
            await Page.SetContentAsync("<html><body><img src='image.png' /><iframe src='file.html'></iframe></body></html>");

            var img = await Page.QuerySelectorAsync("img");
            Assert.That(await img.SrcAsync(), Is.EqualTo("image.png"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.SrcAsync(), Is.Null);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.SrcAsync());
        }

        [Test]
        public async Task HasAttributeAsync_should_return_true_if_element_has_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.HasAttributeAsync("class"));

            div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.HasAttributeAsync("id"), Is.False);

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.HasAttributeAsync(null), Is.False);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasAttributeAsync(""));
        }

        [Test]
        public async Task HasAttributeValueAsync_should_return_true_if_element_has_the_attribute_value()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.HasAttributeValueAsync("class", "cla."));
            Assert.That(await div.HasAttributeValueAsync("class", "Cla.", "i"));

            div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.HasAttributeValueAsync("class", "id"), Is.False);
            Assert.That(await div.HasAttributeValueAsync("id", "class"), Is.False);

            div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.HasAttributeValueAsync("class", null), Is.False);
            Assert.That(await div.HasAttributeValueAsync(null, "class"), Is.False);
            Assert.That(await div.HasAttributeValueAsync(null, null));

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.HasAttributeValueAsync("class", null));
            Assert.That(await body.HasAttributeValueAsync(null, "class"), Is.False);
            Assert.That(await body.HasAttributeValueAsync(null, null));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.HasAttributeValueAsync("", ""));
        }

        [Test]
        public async Task GetAttributeAsync_should_return_the_attribute_value_of_the_element()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.GetAttributeAsync("class"), Is.EqualTo("class"));

            div = await Page.QuerySelectorAsync("div");
            Assert.That(await div.GetAttributeAsync("id"), Is.Null);

            var body = await Page.QuerySelectorAsync("body");
            Assert.That(await body.GetAttributeAsync(null), Is.Null);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.GetAttributeAsync(""));
        }
    }
}
