using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    public class IFrameExtensionsTests : PuppeteerIFrameBaseTest
    {
        [Test]
        public async Task WaitForElementsRemovedFromDOMAsync_should_return_if_page_has_no_elements_matching_the_selector()
        {
            await BlankFrame(IFrameId);
            await IFrame.WaitForElementsRemovedFromDOMAsync(".svg-Wikipedia_wordmark");
        }

        [Test]
        public async Task WaitForElementsRemovedFromDOMAsync_should_return_if_elements_matching_the_selector_are_removed_from_page()
        {
            Task.WaitAll(IFrame.WaitForElementsRemovedFromDOMAsync(".svg-Wikipedia_wordmark"), BlankFrame(IFrameId));
        }

        [Test]
        public async Task WaitForElementsRemovedFromDOMAsync_should_throw_WaitTaskTimeoutException_if_element_is_present_in_DOM()
        {
            Assert.ThrowsAsync<WaitTaskTimeoutException>(async () => await IFrame.WaitForElementsRemovedFromDOMAsync(".svg-Wikipedia_wordmark", 1));
        }
    }
}
