using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    [Collection(PuppeteerFixture.Name)]
    public class ElementHandleShouldExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        // Exist

        [Fact]
        public async Task ShouldExist_throws_if_element_is_missing()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            tweet.ShouldExist();

            var missing = await Page.QuerySelectorAsync(".missing");
            var ex = Assert.Throws<ShouldException>(() => missing.ShouldExist());
            Assert.Equal("Expected element to exist, but it did not.", ex.Message);
        }

        [Fact]
        public async Task ShouldNotExist_throws_if_element_is_present()
        {
            var missing = await Page.QuerySelectorAsync(".missing");
            missing.ShouldNotExist();

            var tweet = await Page.QuerySelectorAsync(".tweet");
            var ex = Assert.Throws<ShouldException>(() => tweet.ShouldNotExist());
            Assert.Equal("Expected element not to exist, but it did.", ex.Message);
        }

        // Value

        [Fact]
        public async Task ShouldHaveValueAsync_throws_if_element_does_not_have_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            await input.ShouldHaveValueAsync("input");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => input.ShouldHaveValueAsync("button"));
            Assert.Equal("Expected element to have value \"button\", but found \"input\".", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldHaveValueAsync(""));
        }

        [Fact]
        public async Task ShouldNotHaveValueAsync_throws_if_element_has_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            await input.ShouldNotHaveValueAsync("button");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => input.ShouldNotHaveValueAsync("input"));
            Assert.Equal("Expected element not to have value \"input\".", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotHaveValueAsync(""));
        }

        // Attribute

        [Fact]
        public async Task ShouldHaveAttributeAsync_throws_if_element_does_not_have_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveAttributeAsync("class");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldHaveAttributeAsync("id"));
            Assert.Equal("Expected element to have attribute \"id\", but it did not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldHaveAttributeAsync(""));
        }

        [Fact]
        public async Task ShouldNotHaveAttributeAsync_throws_if_element_has_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldNotHaveAttributeAsync("id");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldNotHaveAttributeAsync("class"));
            Assert.Equal("Expected element not to have attribute \"class\", but it did.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotHaveAttributeAsync(""));
        }

        // Content

        [Fact]
        public async Task ShouldHaveContentAsync_throws_if_element_does_not_have_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            await like.ShouldHaveContentAsync("100");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => like.ShouldHaveContentAsync("200"));
            Assert.Equal("Expected element to have content \"200\", but it did not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldHaveContentAsync(""));
        }

        [Fact]
        public async Task ShouldNotHaveContentAsync_throws_if_element_has_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            await like.ShouldNotHaveContentAsync("200");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => like.ShouldNotHaveContentAsync("100"));
            Assert.Equal("Expected element not to have content \"100\", but it did.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotHaveContentAsync(""));
        }

        // Class

        [Fact]
        public async Task ShouldHaveClassAsync_throws_if_element_does_not_have_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldHaveClassAsync("foo");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldHaveClassAsync("baz"));
            Assert.Equal("Expected element to have class \"baz\", but it did not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldHaveClassAsync(""));
        }

        [Fact]
        public async Task ShouldNotHaveClassAsync_throws_if_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            await div.ShouldNotHaveClassAsync("baz");

            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldNotHaveClassAsync("foo"));
            Assert.Equal("Expected element not to have class \"foo\", but it did.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotHaveClassAsync(""));
        }

        // Visible

        [Fact]
        public async Task ShouldBeVisibleAsync_throws_if_element_is_hidden()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeVisibleAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeVisibleAsync());
            Assert.Equal("Expected element to be visible, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeVisibleAsync());
        }

        [Fact]
        public async Task ShouldBeHiddenAsync_throws_if_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldBeHiddenAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeHiddenAsync());
            Assert.Equal("Expected element to be hidden, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeHiddenAsync());
        }

        // Selected

        [Fact]
        public async Task ShouldBeSelectedAsync_throws_if_element_is_not_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeSelectedAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeSelectedAsync());
            Assert.Equal("Expected element to be selected, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeSelectedAsync());
        }

        [Fact]
        public async Task ShouldNotBeSelectedAsync_throws_if_element_is_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeSelectedAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldNotBeSelectedAsync());
            Assert.Equal("Expected element not to be selected, but it is.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotBeSelectedAsync());
        }

        // Checked

        [Fact]
        public async Task ShouldBeCheckedAsync_throws_if_element_is_not_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeCheckedAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeCheckedAsync());
            Assert.Equal("Expected element to be checked, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeCheckedAsync());
        }

        [Fact]
        public async Task ShouldNotBeCheckedAsync_throws_if_element_is_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeCheckedAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldNotBeCheckedAsync());
            Assert.Equal("Expected element not to be checked, but it is.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotBeCheckedAsync());
        }

        // Disabled

        [Fact]
        public async Task ShouldBeDisabledAsync_throws_if_element_is_enabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeDisabledAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeDisabledAsync());
            Assert.Equal("Expected element to be disabled, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeDisabledAsync());
        }

        [Fact]
        public async Task ShouldBeEnabledAsync_throws_if_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldBeEnabledAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeEnabledAsync());
            Assert.Equal("Expected element to be enabled, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeEnabledAsync());
        }

        // ReadOnly

        [Fact]
        public async Task ShouldBeReadOnlyAsync_throws_if_element_is_not_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeReadOnlyAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeReadOnlyAsync());
            Assert.Equal("Expected element to be read-only, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeReadOnlyAsync());
        }

        [Fact]
        public async Task ShouldNotBeReadOnlyAsync_throws_if_element_is_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeReadOnlyAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldNotBeReadOnlyAsync());
            Assert.Equal("Expected element not to be read-only, but it is.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotBeReadOnlyAsync());
        }

        // Required

        [Fact]
        public async Task ShouldBeRequiredAsync_throws_if_element_is_not_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldBeRequiredAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldBeRequiredAsync());
            Assert.Equal("Expected element to be required, but it is not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldBeRequiredAsync());
        }

        [Fact]
        public async Task ShouldNotBeRequiredAsync_throws_if_element_is_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotBeRequiredAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldNotBeRequiredAsync());
            Assert.Equal("Expected element not to be required, but it is.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotBeRequiredAsync());
        }

        // Focus

        [Fact]
        public async Task ShouldHaveFocusAsync_throws_if_element_does_not_have_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>", new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var div = await Page.QuerySelectorAsync("#foo");
            await div.ShouldHaveFocusAsync();

            div = await Page.QuerySelectorAsync("#bar");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldHaveFocusAsync());
            Assert.Equal("Expected element to have focus, but it did not.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldHaveFocusAsync());
        }

        [Fact]
        public async Task ShouldNotHaveFocusAsync_throws_if_element_has_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>", new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var div = await Page.QuerySelectorAsync("#bar");
            await div.ShouldNotHaveFocusAsync();

            div = await Page.QuerySelectorAsync("#foo");
            var ex = await Assert.ThrowsAsync<ShouldException>(() => div.ShouldNotHaveFocusAsync());
            Assert.Equal("Expected element not to have focus, but it did.", ex.Message);

            var missing = await Page.QuerySelectorAsync(".missing");
            await Assert.ThrowsAsync<ArgumentNullException>(() => missing.ShouldNotHaveFocusAsync());
        }
    }
}
