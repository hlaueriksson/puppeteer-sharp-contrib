using System.Linq;
using Castle.DynamicProxy;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class InterceptorSelectorTests
    {
        [Fact]
        public void SelectInterceptors_returns_SelectorInterceptor_for_properties_marked_with_Selector_attribute()
        {
            var subject = new InterceptorSelector();
            var interceptors = new IInterceptor[] { new SelectorInterceptor(), new XPathInterceptor() };

            // PageObject

            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<SelectorInterceptor>(result.Single());

            methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandleArray)).GetMethod;
            result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<SelectorInterceptor>(result.Single());

            methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementObject)).GetMethod;
            result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<SelectorInterceptor>(result.Single());

            // ElementObject

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementHandle)).GetMethod;
            result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<SelectorInterceptor>(result.Single());

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementHandleArray)).GetMethod;
            result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<SelectorInterceptor>(result.Single());

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.SelectorForElementObject)).GetMethod;
            result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<SelectorInterceptor>(result.Single());
        }

        [Fact]
        public void SelectInterceptors_returns_XPathInterceptor_for_properties_marked_with_XPath_attribute()
        {
            var subject = new InterceptorSelector();
            var interceptors = new IInterceptor[] { new SelectorInterceptor(), new XPathInterceptor() };

            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.XPathForElementHandleArray)).GetMethod;
            var result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<XPathInterceptor>(result.Single());

            methodInfo = typeof(FakeElementObject).GetProperty(nameof(FakeElementObject.XPathForElementHandleArray)).GetMethod;
            result = subject.SelectInterceptors(null, methodInfo, interceptors);
            Assert.IsType<XPathInterceptor>(result.Single());
        }
    }
}