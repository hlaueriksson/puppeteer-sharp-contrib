using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class ReflectionExtensionsTests
    {
        [Test]
        public void IsGetter_returns_true_for_getter_property()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsGetter());
        }

        [Test]
        public void IsGetter_returns_false_for_non_getter_property()
        {
            var methodInfo = typeof(string).GetMethod(nameof(string.GetTypeCode));
            Assert.False(methodInfo.IsGetter());
        }

        [Test]
        public void IsGetterPropertyWithAttribute_returns_true_for_getter_property_marked_with_given_attribute()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsGetterPropertyWithAttribute<SelectorAttribute>());
        }

        [Test]
        public void IsGetterPropertyWithAttribute_returns_false_for_getter_property_not_marked_with_given_attribute()
        {
            var methodInfo = typeof(string).GetProperty(nameof(string.Length)).GetMethod;
            Assert.False(methodInfo.IsGetterPropertyWithAttribute<SelectorAttribute>());
        }

        [Test]
        public void HasAttribute_returns_true_for_property_marked_with_given_attribute()
        {
            var propertyInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle));
            Assert.True(propertyInfo.HasAttribute<SelectorAttribute>());
        }

        [Test]
        public void HasAttribute_returns_false_for_property_not_marked_with_given_attribute()
        {
            var propertyInfo = typeof(string).GetProperty(nameof(string.Length));
            Assert.False(propertyInfo.HasAttribute<SelectorAttribute>());
        }

        [Test]
        public void GetAttribute_returns_the_given_attribute()
        {
            var propertyInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle));
            Assert.NotNull(propertyInfo.GetAttribute<SelectorAttribute>());
        }

        [Test]
        public void IsCompilerGenerated_returns_true_for_auto_getter_property()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsCompilerGenerated());
        }

        [Test]
        public void IsCompilerGenerated_returns_false_for_method()
        {
            var methodInfo = typeof(string).GetMethod(nameof(string.GetTypeCode));
            Assert.False(methodInfo.IsCompilerGenerated());
        }

        [Test]
        public void GetProperty_returns_PropertyInfo_for_given_getter_property_method()
        {
            var type = typeof(FakePageObject);
            var methodInfo = type.GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.NotNull(type.GetProperty(methodInfo));
        }

        [Test]
        public void IsReturningAsyncResult_returns_true_for_methods_that_returns_Task_of_T()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsReturningAsyncResult());
        }

        [Test]
        public void IsReturningAsyncResult_returns_false_for_methods_that_does_not_return_Task_of_T()
        {
            var methodInfo = typeof(string).GetProperty(nameof(string.Length)).GetMethod;
            Assert.False(methodInfo.IsReturningAsyncResult());
        }
    }
}
