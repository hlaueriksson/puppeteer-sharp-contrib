using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class SelectorInterceptorTests : PuppeteerPageBaseTest
    {
        private SelectorInterceptor _subject;
        private FakePageObject _pageObject;
        private FakeElementObject _elementObject;

        protected override async Task SetUp()
        {
            await Page.SetContentAsync(Fake.Html);

            _subject = new SelectorInterceptor();
            _pageObject = new FakePageObject();
            _pageObject.Initialize(Page, null);
            _elementObject = new FakeElementObject();
            _elementObject.Initialize(Page, await Page.QuerySelectorAsync("html"));
        }

        // PageObject

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_IElementHandle_for_property_on_PageObject_marked_with_SelectorAttribute()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);
            var result = await (Task<IElementHandle>)invocation.ReturnValue;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IElementHandle>());
        }

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_IElementHandle_array_for_property_on_PageObject_marked_with_SelectorAttribute()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);
            var result = await (Task<IElementHandle[]>)invocation.ReturnValue;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IElementHandle[]>());
        }

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_ElementObject_for_property_on_PageObject_marked_with_SelectorAttribute()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementObject)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);
            var result = await (Task<FakeElementObject>)invocation.ReturnValue;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_PageObject_marked_with_SelectorAttribute_but_wrong_return_type()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);

            Assert.That(invocation.ReturnValue, Is.Null);
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_PageObject_marked_with_SelectorAttribute_but_non_Task_return_type()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);

            Assert.That(invocation.ReturnValue, Is.Null);
        }

        // ElementObject

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_IElementHandle_for_property_on_ElementObject_marked_with_SelectorAttribute()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);
            var result = await (Task<IElementHandle>)invocation.ReturnValue;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IElementHandle>());
        }

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_IElementHandle_array_for_property_on_ElementObject_marked_with_SelectorAttribute()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);
            var result = await (Task<IElementHandle[]>)invocation.ReturnValue;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IElementHandle[]>());
        }

        [Test]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_ElementObject_for_property_on_ElementObject_marked_with_SelectorAttribute()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementObject)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);
            var result = await (Task<FakeElementObject>)invocation.ReturnValue;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<FakeElementObject>());
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_ElementObject_marked_with_SelectorAttribute_but_wrong_return_type()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);

            Assert.That(invocation.ReturnValue, Is.Null);
        }

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_ElementObject_marked_with_SelectorAttribute_but_non_Task_return_type()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);

            Assert.That(invocation.ReturnValue, Is.Null);
        }

        // Unknown

        [Test]
        public void Intercept_sets_the_ReturnValue_to_null_for_property_on_unknown_object_marked_with_SelectorAttribute()
        {
            var objectWithNoBaseClass = new FakeObjectWithNoBaseClass();
            var methodInfo = objectWithNoBaseClass.GetType().GetProperty(nameof(FakeObjectWithNoBaseClass.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, objectWithNoBaseClass);

            _subject.Intercept(invocation);

            Assert.That(invocation.ReturnValue, Is.Null);
        }
    }
}
