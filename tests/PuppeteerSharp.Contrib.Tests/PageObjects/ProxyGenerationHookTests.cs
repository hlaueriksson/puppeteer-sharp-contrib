using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class ProxyGenerationHookTests
    {
        [Test]
        public void ShouldInterceptMethod_returns_true_for_properties_marked_with_Selector_attribute()
        {
            var subject = new ProxyGenerationHook();

            // PageObject

            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandleArray)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementObject)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));

            // ElementObject

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementHandle)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementHandleArray)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementObject)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));
        }

        [Test]
        public void ShouldInterceptMethod_returns_true_for_properties_marked_with_XPath_attribute()
        {
            var subject = new ProxyGenerationHook();

            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.XPathForElementHandleArray)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.XPathForElementHandleArray)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo));
        }

        [Test]
        public void ShouldInterceptMethod_returns_false_for_properties_not_marked_with_Selector_or_XPath_attribute()
        {
            var subject = new ProxyGenerationHook();

            var methodInfo = typeof(string).GetProperty(nameof(string.Length)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo), Is.False);
        }

        [Test]
        public void ShouldInterceptMethod_returns_false_for_properties_marked_with_Selector_or_XPath_attribute_but_has_non_Task_return_type()
        {
            var subject = new ProxyGenerationHook();

            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForNonTaskReturnType)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo), Is.False);

            methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.XPathForNonTaskReturnType)).GetMethod;
            Assert.That(subject.ShouldInterceptMethod(null, methodInfo), Is.False);
        }

        [Test]
        public void caching_should_work()
        {
            var subject = new ProxyGenerationHook();

            Assert.That(subject.Equals(new ProxyGenerationHook()));

            var hashCode = subject.GetHashCode();

            Assert.That(hashCode, Is.EqualTo(new ProxyGenerationHook().GetHashCode()));
        }
    }
}
