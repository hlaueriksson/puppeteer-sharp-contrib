using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ShouldExtensionsTests : PuppeteerPageBaseTest
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
            var ex = Assert.Throws<ShouldException>(() => missing.ShouldExist());
            Assert.Equal("Should exist, but did not.", ex.Message);

            var missingTask = Page.QuerySelectorAsync(".missing");
            Assert.Throws<ShouldException>(() => missingTask.ShouldExist());
        }

        [Fact]
        public async Task ShouldNotExist_throws_if_element_is_present()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            Assert.Throws<ShouldException>(() => tweet.ShouldNotExist());

            var tweetTask = Page.QuerySelectorAsync(".tweet");
            var ex = Assert.Throws<ShouldException>(() => tweetTask.ShouldNotExist());
            Assert.Equal("Should not exist, but did.", ex.Message);

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
            var ex = Assert.Throws<ShouldException>(() => input.ShouldHaveValue("output"));
            Assert.Equal("Should have value, but did not.", ex.Message);

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
            var ex = Assert.Throws<ShouldException>(() => input.ShouldNotHaveValue("input"));
            Assert.Equal("Should not have value, but did.", ex.Message);

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
            var ex = Assert.Throws<ShouldException>(() => div.ShouldHaveAttribute("id"));
            Assert.Equal("Should have attribute, but did not.", ex.Message);

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
            var ex = Assert.Throws<ShouldException>(() => div.ShouldNotHaveAttribute("class"));
            Assert.Equal("Should not have attribute, but did.", ex.Message);

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
            var ex = Assert.Throws<ShouldException>(() => like.ShouldHaveContent("200"));
            Assert.Equal("Should have content, but did not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldHaveContent(""));
        }

        [Fact]
        public async Task ShouldNotHaveContent_throws_if_element_has_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            like.ShouldNotHaveContent("200");

            like = await Page.QuerySelectorAsync(".like");
            var ex = Assert.Throws<ShouldException>(() => like.ShouldNotHaveContent("100"));
            Assert.Equal("Should not have content, but did.", ex.Message);

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
            var ex = Assert.Throws<ShouldException>(() => div.ShouldHaveClass("baz"));
            Assert.Equal("Should have class, but did not.", ex.Message);

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
            var ex = Assert.Throws<ShouldException>(() => div.ShouldNotHaveClass("foo"));
            Assert.Equal("Should not have class, but did.", ex.Message);

            var body = await Page.QuerySelectorAsync("body");
            body.ShouldNotHaveClass("");

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotHaveClass(""));
        }

        // Visible

        [Fact]
        public async Task ShouldBeVisible_throws_if_element_is_hidden()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeVisible();

            var divTask = Page.QuerySelectorAsync("#foo");
            divTask.ShouldBeVisible();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldBeVisible());
            Assert.Equal("Should be visible, but is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldBeVisible());
        }

        [Fact]
        public async Task ShouldBeHidden_throws_if_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldBeHidden();

            var divTask = Page.QuerySelectorAsync("#bar");
            divTask.ShouldBeHidden();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldBeHidden());
            Assert.Equal("Should be hidden, but is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldBeHidden());
        }

        // Selected

        [Fact]
        public async Task ShouldBeSelected_throws_if_element_is_not_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeSelected();

            var divTask = Page.QuerySelectorAsync("#foo");
            divTask.ShouldBeSelected();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldBeSelected());
            Assert.Equal("Should be selected, but is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldBeSelected());
        }

        [Fact]
        public async Task ShouldNotBeSelected_throws_if_element_is_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotBeSelected();

            var divTask = Page.QuerySelectorAsync("#bar");
            divTask.ShouldNotBeSelected();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldNotBeSelected());
            Assert.Equal("Should not be selected, but is.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotBeSelected());
        }

        // Checked

        [Fact]
        public async Task ShouldBeChecked_throws_if_element_is_not_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeChecked();

            var divTask = Page.QuerySelectorAsync("#foo");
            divTask.ShouldBeChecked();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldBeChecked());
            Assert.Equal("Should be checked, but is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldBeChecked());
        }

        [Fact]
        public async Task ShouldNotBeChecked_throws_if_element_is_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotBeChecked();

            var divTask = Page.QuerySelectorAsync("#bar");
            divTask.ShouldNotBeChecked();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldNotBeChecked());
            Assert.Equal("Should not be checked, but is.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotBeChecked());
        }

        // Disabled

        [Fact]
        public async Task ShouldBeDisabled_throws_if_element_is_enabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeDisabled();

            var divTask = Page.QuerySelectorAsync("#foo");
            divTask.ShouldBeDisabled();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldBeDisabled());
            Assert.Equal("Should be disabled, but is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldBeDisabled());
        }

        [Fact]
        public async Task ShouldBeEnabled_throws_if_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldBeEnabled();

            var divTask = Page.QuerySelectorAsync("#bar");
            divTask.ShouldBeEnabled();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldBeEnabled());
            Assert.Equal("Should be enabled, but is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldBeEnabled());
        }

        // ReadOnly

        [Fact]
        public async Task ShouldBeReadOnly_throws_if_element_is_not_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeReadOnly();

            var divTask = Page.QuerySelectorAsync("#foo");
            divTask.ShouldBeReadOnly();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldBeReadOnly());
            Assert.Equal("Should be read-only, but is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldBeReadOnly());
        }

        [Fact]
        public async Task ShouldNotBeReadOnly_throws_if_element_is_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotBeReadOnly();

            var divTask = Page.QuerySelectorAsync("#bar");
            divTask.ShouldNotBeReadOnly();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldNotBeReadOnly());
            Assert.Equal("Should not be read-only, but is.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotBeReadOnly());
        }

        // Focus

        [Fact]
        public async Task ShouldHaveFocus_throws_if_element_does_not_have_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldHaveFocus();

            var divTask = Page.QuerySelectorAsync("#foo");
            divTask.ShouldHaveFocus();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldHaveFocus());
            Assert.Equal("Should have focus, but did not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldHaveFocus());
        }

        [Fact]
        public async Task ShouldNotHaveFocus_throws_if_element_has_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotHaveFocus();

            var divTask = Page.QuerySelectorAsync("#bar");
            divTask.ShouldNotHaveFocus();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.Throws<ShouldException>(() => div.ShouldNotHaveFocus());
            Assert.Equal("Should not have focus, but did.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ArgumentNullException>(() => missing.ShouldNotHaveFocus());
        }
    }
}