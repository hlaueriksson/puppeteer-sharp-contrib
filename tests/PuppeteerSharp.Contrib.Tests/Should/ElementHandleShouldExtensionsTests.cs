using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ElementHandleShouldExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        // Exist

        [Test]
        public async Task ShouldExist_throws_if_element_is_missing()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            tweet.ShouldExist();

            var missing = await Page.QuerySelectorAsync(".missing");
            var ex = Assert.Throws<ShouldException>(() => missing.ShouldExist());
            Assert.That(ex.Message, Is.EqualTo("Expected element to exist, but it did not."));
        }

        [Test]
        public async Task ShouldNotExist_throws_if_element_is_present()
        {
            var missing = await Page.QuerySelectorAsync(".missing");
            missing.ShouldNotExist();

            var tweet = await Page.QuerySelectorAsync(".tweet");
            var ex = Assert.Throws<ShouldException>(() => tweet.ShouldNotExist());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to exist, but it did."));
        }

        // Value

        [Test]
        public async Task ShouldHaveValueAsync_throws_if_element_does_not_have_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            await input.ShouldHaveValueAsync("input");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await input.ShouldHaveValueAsync("button"));
            Assert.That(ex.Message, Is.EqualTo("Expected element to have value \"button\", but found \"input\"."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldHaveValueAsync(""));
        }

        [Test]
        public async Task ShouldNotHaveValueAsync_throws_if_element_has_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            await input.ShouldNotHaveValueAsync("button");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await input.ShouldNotHaveValueAsync("input"));
            Assert.That(ex.Message, Is.EqualTo("Expected element not to have value \"input\"."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotHaveValueAsync(""));
        }

        // Attribute

        [Test]
        public async Task ShouldHaveAttributeAsync_throws_if_element_does_not_have_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveAttributeAsync("class");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldHaveAttributeAsync("id"));
            Assert.That(ex.Message, Is.EqualTo("Expected element to have attribute \"id\", but it did not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldHaveAttributeAsync(""));
        }

        [Test]
        public async Task ShouldNotHaveAttributeAsync_throws_if_element_has_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldNotHaveAttributeAsync("id");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotHaveAttributeAsync("class"));
            Assert.That(ex.Message, Is.EqualTo("Expected element not to have attribute \"class\", but it did."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotHaveAttributeAsync(""));
        }

        // AttributeValue

        [Test]
        public async Task ShouldHaveAttributeValueAsync_throws_if_element_does_not_have_the_attribute_value()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveAttributeValueAsync("class", "class");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldHaveAttributeValueAsync("class", "id"));
            Assert.That(ex.Message, Is.EqualTo("Expected element to have attribute \"class\" with value \"/id/\", but it did not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldHaveAttributeValueAsync("", ""));
        }

        [Test]
        public async Task ShouldNotHaveAttributeValueAsync_throws_if_element_has_the_attribute_value()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldNotHaveAttributeValueAsync("class", "id");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotHaveAttributeValueAsync("class", "class"));
            Assert.That(ex.Message, Is.EqualTo("Expected element not to have attribute \"class\" with value \"/class/\", but it did."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotHaveAttributeValueAsync("", ""));
        }

        // Content

        [Test]
        public async Task ShouldHaveContentAsync_throws_if_element_does_not_have_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            await like.ShouldHaveContentAsync("100");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await like.ShouldHaveContentAsync("200", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected element to have content \"/200/i\", but it did not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldHaveContentAsync(""));
        }

        [Test]
        public async Task ShouldNotHaveContentAsync_throws_if_element_has_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            await like.ShouldNotHaveContentAsync("200");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await like.ShouldNotHaveContentAsync("100", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected element not to have content \"/100/i\", but it did."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotHaveContentAsync(""));
        }

        // Class

        [Test]
        public async Task ShouldHaveClassAsync_throws_if_element_does_not_have_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveClassAsync("foo");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldHaveClassAsync("baz"));
            Assert.That(ex.Message, Is.EqualTo("Expected element to have class \"baz\", but it did not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldHaveClassAsync(""));
        }

        [Test]
        public async Task ShouldNotHaveClassAsync_throws_if_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldNotHaveClassAsync("baz");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotHaveClassAsync("foo"));
            Assert.That(ex.Message, Is.EqualTo("Expected element not to have class \"foo\", but it did."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotHaveClassAsync(""));
        }

        // Visible

        [Test]
        public async Task ShouldBeVisibleAsync_throws_if_element_is_hidden()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeVisibleAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeVisibleAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be visible, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeVisibleAsync());
        }

        [Test]
        public async Task ShouldBeHiddenAsync_throws_if_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldBeHiddenAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeHiddenAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be hidden, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeHiddenAsync());
        }

        // Selected

        [Test]
        public async Task ShouldBeSelectedAsync_throws_if_element_is_not_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeSelectedAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeSelectedAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be selected, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeSelectedAsync());
        }

        [Test]
        public async Task ShouldNotBeSelectedAsync_throws_if_element_is_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeSelectedAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotBeSelectedAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to be selected, but it is."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotBeSelectedAsync());
        }

        // Checked

        [Test]
        public async Task ShouldBeCheckedAsync_throws_if_element_is_not_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeCheckedAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeCheckedAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be checked, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeCheckedAsync());
        }

        [Test]
        public async Task ShouldNotBeCheckedAsync_throws_if_element_is_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeCheckedAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotBeCheckedAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to be checked, but it is."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotBeCheckedAsync());
        }

        // Disabled

        [Test]
        public async Task ShouldBeDisabledAsync_throws_if_element_is_enabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeDisabledAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeDisabledAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be disabled, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeDisabledAsync());
        }

        [Test]
        public async Task ShouldBeEnabledAsync_throws_if_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldBeEnabledAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeEnabledAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be enabled, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeEnabledAsync());
        }

        // ReadOnly

        [Test]
        public async Task ShouldBeReadOnlyAsync_throws_if_element_is_not_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeReadOnlyAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeReadOnlyAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be read-only, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeReadOnlyAsync());
        }

        [Test]
        public async Task ShouldNotBeReadOnlyAsync_throws_if_element_is_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeReadOnlyAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotBeReadOnlyAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to be read-only, but it is."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotBeReadOnlyAsync());
        }

        // Required

        [Test]
        public async Task ShouldBeRequiredAsync_throws_if_element_is_not_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeRequiredAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeRequiredAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be required, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeRequiredAsync());
        }

        [Test]
        public async Task ShouldNotBeRequiredAsync_throws_if_element_is_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeRequiredAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotBeRequiredAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to be required, but it is."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotBeRequiredAsync());
        }

        // Focus

        [Test]
        public async Task ShouldHaveFocusAsync_throws_if_element_does_not_have_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>", new() { WaitUntil = [WaitUntilNavigation.Networkidle0] });

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldHaveFocusAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldHaveFocusAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to have focus, but it did not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldHaveFocusAsync());
        }

        [Test]
        public async Task ShouldNotHaveFocusAsync_throws_if_element_has_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>", new() { WaitUntil = [WaitUntilNavigation.Networkidle0] });

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotHaveFocusAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotHaveFocusAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to have focus, but it did."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotHaveFocusAsync());
        }

        // Empty

        [Test]
        public async Task ShouldBeEmptyAsync_throws_if_element_is_not_empty()
        {
            await Page.SetContentAsync("<html><body><input id='foo'><input id='bar' value='input'></body></html>");

            var input = await Page.QuerySelectorAsync("#foo");
            await input.ShouldBeEmptyAsync();

            input = await Page.QuerySelectorAsync("#bar");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await input.ShouldBeEmptyAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be empty, but it is not."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldBeEmptyAsync());

            await Page.SetContentAsync("<html><body><div id='foo'> </div><div id='bar'>Text</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeEmptyAsync();

            div = await Page.QuerySelectorAsync("#bar");
            ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldBeEmptyAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element to be empty, but it is not."));
        }

        [Test]
        public async Task ShouldNotBeEmptyAsync_throws_if_element_is_empty()
        {
            await Page.SetContentAsync("<html><body><input id='foo'><input id='bar' value='input'></body></html>");

            var input = await Page.QuerySelectorAsync("#bar");
            await input.ShouldNotBeEmptyAsync();

            input = await Page.QuerySelectorAsync("#foo");
            var ex = Assert.ThrowsAsync<ShouldException>(async () => await input.ShouldNotBeEmptyAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to be empty, but it is."));

            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await missing.ShouldNotBeEmptyAsync());

            await Page.SetContentAsync("<html><body><div id='foo'> </div><div id='bar'>Text</div></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeEmptyAsync();

            div = await Page.QuerySelectorAsync("#foo");
            ex = Assert.ThrowsAsync<ShouldException>(async () => await div.ShouldNotBeEmptyAsync());
            Assert.That(ex.Message, Is.EqualTo("Expected element not to be empty, but it is."));
        }
    }
}
