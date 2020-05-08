using System;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Unsafe.Should
{
    [Collection(PuppeteerFixture.Name)]
    public class ElementHandleShouldExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        // Exist

        [Fact]
        public void ShouldExist_throws_if_element_is_missing()
        {
            Page.QuerySelectorAsync(".tweet").ShouldExist();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync(".missing").ShouldExist());
        }

        [Fact]
        public void ShouldNotExist_throws_if_element_is_present()
        {
            Page.QuerySelectorAsync(".missing").ShouldNotExist();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync(".tweet").ShouldNotExist());
        }

        // Value

        [Fact]
        public async Task ShouldHaveValue_throws_if_element_does_not_have_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            input.ShouldHaveValue("input");

            Page.QuerySelectorAsync("input").ShouldHaveValue("input");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("input").ShouldHaveValue("button"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldHaveValue(""));
        }

        [Fact]
        public async Task ShouldNotHaveValue_throws_if_element_has_the_value()
        {
            await Page.SetContentAsync("<html><body><input value='input' /><button value='button' /></body></html>");

            var input = await Page.QuerySelectorAsync("input");
            input.ShouldNotHaveValue("button");

            Page.QuerySelectorAsync("input").ShouldNotHaveValue("button");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("input").ShouldNotHaveValue("input"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotHaveValue(""));
        }

        // Attribute

        [Fact]
        public async Task ShouldHaveAttribute_throws_if_element_does_not_have_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldHaveAttribute("class");

            Page.QuerySelectorAsync("div").ShouldHaveAttribute("data-foo");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("div").ShouldHaveAttribute("id"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldHaveAttribute(""));
        }

        [Fact]
        public async Task ShouldNotHaveAttribute_throws_if_element_has_the_attribute()
        {
            await Page.SetContentAsync("<html><body><div class='class' data-foo='bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldNotHaveAttribute("id");

            Page.QuerySelectorAsync("div").ShouldNotHaveAttribute("data-bar");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("div").ShouldNotHaveAttribute("class"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotHaveAttribute(""));
        }

        // Content

        [Fact]
        public async Task ShouldHaveContent_throws_if_element_does_not_have_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            like.ShouldHaveContent("100");

            Page.QuerySelectorAsync(".like").ShouldHaveContent("100");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync(".like").ShouldHaveContent("200"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldHaveContent(""));
        }

        [Fact]
        public async Task ShouldNotHaveContent_throws_if_element_has_the_content()
        {
            var like = await Page.QuerySelectorAsync(".like");
            like.ShouldNotHaveContent("200");

            Page.QuerySelectorAsync(".like").ShouldNotHaveContent("200");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync(".like").ShouldNotHaveContent("100"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotHaveContent(""));
        }

        // Class

        [Fact]
        public async Task ShouldHaveClass_throws_if_element_does_not_have_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldHaveClass("foo");

            Page.QuerySelectorAsync("div").ShouldHaveClass("bar");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("div").ShouldHaveClass("baz"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldHaveClass(""));
        }

        [Fact]
        public async Task ShouldNotHaveClass_throws_if_element_has_the_class()
        {
            await Page.SetContentAsync("<html><body><div class='foo bar' /></body></html>");

            var div = await Page.QuerySelectorAsync("div");
            div.ShouldNotHaveClass("baz");

            Page.QuerySelectorAsync("div").ShouldNotHaveClass("qux");

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("div").ShouldNotHaveClass("foo"));

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotHaveClass(""));
        }

        // Visible

        [Fact]
        public async Task ShouldBeVisible_throws_if_element_is_hidden()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeVisible();

            Page.QuerySelectorAsync("#foo").ShouldBeVisible();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#bar").ShouldBeVisible());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeVisible());
        }

        [Fact]
        public async Task ShouldBeHidden_throws_if_element_is_visible()
        {
            await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar' style='display:none'>Bar</div></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldBeHidden();

            Page.QuerySelectorAsync("#bar").ShouldBeHidden();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#foo").ShouldBeHidden());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeHidden());
        }

        // Selected

        [Fact]
        public async Task ShouldBeSelected_throws_if_element_is_not_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeSelected();

            Page.QuerySelectorAsync("#foo").ShouldBeSelected();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#bar").ShouldBeSelected());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeSelected());
        }

        [Fact]
        public async Task ShouldNotBeSelected_throws_if_element_is_selected()
        {
            await Page.SetContentAsync("<html><body><select><option id='foo'>Foo</option><option id='bar'>Bar</option></select></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotBeSelected();

            Page.QuerySelectorAsync("#bar").ShouldNotBeSelected();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#foo").ShouldNotBeSelected());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotBeSelected());
        }

        // Checked

        [Fact]
        public async Task ShouldBeChecked_throws_if_element_is_not_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeChecked();

            Page.QuerySelectorAsync("#foo").ShouldBeChecked();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#bar").ShouldBeChecked());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeChecked());
        }

        [Fact]
        public async Task ShouldNotBeChecked_throws_if_element_is_checked()
        {
            await Page.SetContentAsync("<html><body><input type='checkbox' id='foo' checked><input type='checkbox' id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotBeChecked();

            Page.QuerySelectorAsync("#bar").ShouldNotBeChecked();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#foo").ShouldNotBeChecked());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotBeChecked());
        }

        // Disabled

        [Fact]
        public async Task ShouldBeDisabled_throws_if_element_is_enabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeDisabled();

            Page.QuerySelectorAsync("#foo").ShouldBeDisabled();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#bar").ShouldBeDisabled());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeDisabled());
        }

        [Fact]
        public async Task ShouldBeEnabled_throws_if_element_is_disabled()
        {
            await Page.SetContentAsync("<html><body><input id='foo' disabled><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldBeEnabled();

            Page.QuerySelectorAsync("#bar").ShouldBeEnabled();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#foo").ShouldBeEnabled());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeEnabled());
        }

        // ReadOnly

        [Fact]
        public async Task ShouldBeReadOnly_throws_if_element_is_not_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeReadOnly();

            Page.QuerySelectorAsync("#foo").ShouldBeReadOnly();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#bar").ShouldBeReadOnly());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeReadOnly());
        }

        [Fact]
        public async Task ShouldNotBeReadOnly_throws_if_element_is_read_only()
        {
            await Page.SetContentAsync("<html><body><input id='foo' readonly><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotBeReadOnly();

            Page.QuerySelectorAsync("#bar").ShouldNotBeReadOnly();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#foo").ShouldNotBeReadOnly());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotBeReadOnly());
        }

        // Required

        [Fact]
        public async Task ShouldBeRequired_throws_if_element_is_not_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldBeRequired();

            Page.QuerySelectorAsync("#foo").ShouldBeRequired();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#bar").ShouldBeRequired());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldBeRequired());
        }

        [Fact]
        public async Task ShouldNotBeRequired_throws_if_element_is_required()
        {
            await Page.SetContentAsync("<html><body><input id='foo' required><input id='bar'></body></html>");

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotBeRequired();

            Page.QuerySelectorAsync("#bar").ShouldNotBeRequired();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#foo").ShouldNotBeRequired());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotBeRequired());
        }

        // Focus

        [Fact]
        public async Task ShouldHaveFocus_throws_if_element_does_not_have_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>", new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var div = await Page.QuerySelectorAsync("#foo");
            div.ShouldHaveFocus();

            Page.QuerySelectorAsync("#foo").ShouldHaveFocus();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#bar").ShouldHaveFocus());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldHaveFocus());
        }

        [Fact]
        public async Task ShouldNotHaveFocus_throws_if_element_has_focus()
        {
            await Page.SetContentAsync("<html><body><input id='foo' autofocus><input id='bar'></body></html>", new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

            var div = await Page.QuerySelectorAsync("#bar");
            div.ShouldNotHaveFocus();

            Page.QuerySelectorAsync("#bar").ShouldNotHaveFocus();

            Assert.Throws<ShouldException>(() => Page.QuerySelectorAsync("#foo").ShouldNotHaveFocus());

            Assert.Throws<ArgumentNullException>(() => Page.QuerySelectorAsync(".missing").ShouldNotHaveFocus());
        }
    }
}
