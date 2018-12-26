using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ShouldExtensionMethodsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        // Exist

        [Fact]
        public async Task ShouldExist_throws_if_element_is_missing()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            tweet.ShouldExist();

            var tweetTask = Page.QuerySelectorAsync(".tweet");
            tweetTask.ShouldExist();

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ShouldException>(() => missing.ShouldExist());

            var missingTask = Page.QuerySelectorAsync(".missing");
            Assert.Throws<ShouldException>(() => missingTask.ShouldExist());
        }

        [Fact]
        public async Task ShouldNotExist_throws_if_element_is_present()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            Assert.Throws<ShouldException>(() => tweet.ShouldNotExist());

            var tweetTask = Page.QuerySelectorAsync(".tweet");
            Assert.Throws<ShouldException>(() => tweetTask.ShouldNotExist());

            var missing = await Page.QuerySelectorAsync(".missing");
            missing.ShouldNotExist();

            var missingTask = Page.QuerySelectorAsync(".missing");
            missingTask.ShouldNotExist();
        }

        // Value

        [Fact]
        public async Task ShouldHaveValue_throws_if_element_does_not_have_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            input.ShouldHaveValue("input");

            input = await Page.QuerySelectorAsync("input");
            Assert.Throws<ShouldException>(() => input.ShouldHaveValue("output"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.Throws<ShouldException>(() => body.ShouldHaveValue(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldHaveValue(""));
        }

        [Fact]
        public async Task ShouldNotHaveValue_throws_if_element_has_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            input.ShouldNotHaveValue("output");

            input = await Page.QuerySelectorAsync("input");
            Assert.Throws<ShouldException>(() => input.ShouldNotHaveValue("input"));

            var body = await Page.QuerySelectorAsync("body");
            body.ShouldNotHaveValue("");

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotHaveValue(""));
        }

        // Attribute

        [Fact]
        public async Task ShouldHaveAttribute_throws_if_element_does_not_have_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldHaveAttribute("class");

            var divTask = Page.QuerySelectorAsync("div");
            divTask.ShouldHaveAttribute("data-foo");

            div = await Page.QuerySelectorAsync("div");
            Assert.Throws<ShouldException>(() => div.ShouldHaveAttribute("id"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.Throws<ShouldException>(() => body.ShouldHaveAttribute(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldHaveAttribute(""));
        }

        [Fact]
        public async Task ShouldNotHaveAttribute_throws_if_element_has_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldNotHaveAttribute("id");

            var divTask = Page.QuerySelectorAsync("div");
            divTask.ShouldNotHaveAttribute("data-bar");

            div = await Page.QuerySelectorAsync("div");
            Assert.Throws<ShouldException>(() => div.ShouldNotHaveAttribute("class"));

            var body = await Page.QuerySelectorAsync("body");
            body.ShouldNotHaveAttribute("");

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotHaveAttribute(""));
        }

        // Content

        [Fact]
        public async Task ShouldHaveContent_throws_if_element_does_not_have_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            like.ShouldHaveContent("100");

            like = await Page.QuerySelectorAsync(".like");
            Assert.Throws<ShouldException>(() => like.ShouldHaveContent("200"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldHaveContent(""));
        }

        [Fact]
        public async Task ShouldNotHaveContent_throws_if_element_has_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            like.ShouldNotHaveContent("200");

            like = await Page.QuerySelectorAsync(".like");
            Assert.Throws<ShouldException>(() => like.ShouldNotHaveContent("100"));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotHaveContent(""));
        }

        // Class

        [Fact]
        public async Task ShouldHaveClass_throws_if_element_does_not_have_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldHaveClass("foo");

            var divTask = Page.QuerySelectorAsync("div");
            divTask.ShouldHaveClass("bar");

            div = await Page.QuerySelectorAsync("div");
            Assert.Throws<ShouldException>(() => div.ShouldHaveClass("baz"));

            var body = await Page.QuerySelectorAsync("body");
            Assert.Throws<ShouldException>(() => body.ShouldHaveClass(""));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldHaveClass(""));
        }

        [Fact]
        public async Task ShouldNotHaveClass_throws_if_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldNotHaveClass("baz");

            var divTask = Page.QuerySelectorAsync("div");
            divTask.ShouldNotHaveClass("qux");

            div = await Page.QuerySelectorAsync("div");
            Assert.Throws<ShouldException>(() => div.ShouldNotHaveClass("foo"));

            var body = await Page.QuerySelectorAsync("body");
            body.ShouldNotHaveClass("");

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotHaveClass(""));
        }
    }
}