using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;
using NUnit.Framework;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    
    public class XPathInterceptorTests : PuppeteerPageBaseTest
    {
        private XPathInterceptor _subject;
        private FakePageObject _pageObject;
        private FakeElementObject _elementObject;

        protected override async Task SetUp()
        {
            await Page.SetContentAsync(Fake.Html);

            _subject = new XPathInterceptor();
            _pageObject = new FakePageObject();
            _pageObject.Initialize(Page, null);
            _elementObject = new FakeElementObject();
            _elementObject.Initialize(Page, await Page.QuerySelectorAsync("html"));
        }

        // PageObject

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_ElementHandle_array_for_property_on_PageObject_marked_with_XPathAttribute()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);
            var result = await (Task<ElementHandle[]>)invocation.ReturnValue;

            Assert.NotNull(result);
            Assert.IsInstanceOf<ElementHandle[]>(result);
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_PageObject_marked_with_XPathAttribute_but_wrong_return_type()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);

            Assert.Null(invocation.ReturnValue);
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_PageObject_marked_with_XPathAttribute_but_non_Task_return_type()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);

            Assert.Null(invocation.ReturnValue);
        }

        // ElementObject

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_ElementHandle_array_for_property_on_ElementObject_marked_with_XPathAttribute()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);
            var result = await (Task<ElementHandle[]>)invocation.ReturnValue;

            Assert.NotNull(result);
            Assert.IsInstanceOf<ElementHandle[]>(result);
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_ElementObject_marked_with_XPathAttribute_but_wrong_return_type()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);

            Assert.Null(invocation.ReturnValue);
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_ElementObject_marked_with_XPathAttribute_but_non_Task_return_type()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);

            Assert.Null(invocation.ReturnValue);
        }

        // Unknown

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_unknown_object_marked_with_XPathAttribute()
        {
            var objectWithNoBaseClass = new FakeObjectWithNoBaseClass();
            var methodInfo = objectWithNoBaseClass.GetType().GetProperty(nameof(FakeObjectWithNoBaseClass.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, objectWithNoBaseClass);

            _subject.Intercept(invocation);

            Assert.Null(invocation.ReturnValue);
        }
    }
}
