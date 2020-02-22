using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class ProxyGenerationHookTests
    {
        [Fact]
        public void ShouldInterceptMethod_returns_true_for_properties_marked_with_Selector_attribute()
        {
            var subject = new ProxyGenerationHook();

            // PageObject

            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandleArray)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementObject)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));

            // ElementObject

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementHandle)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementHandleArray)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementObject)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));
        }

        [Fact]
        public void ShouldInterceptMethod_returns_true_for_properties_marked_with_XPath_attribute()
        {
            var subject = new ProxyGenerationHook();

            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.XPathForElementHandleArray)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.XPathForElementHandleArray)).GetMethod;
            Assert.True(subject.ShouldInterceptMethod(null, methodInfo));
        }
    }
}