using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using PuppeteerSharp.Contrib.PageObjects;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public static class Fake
    {
        public static string Html => "<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>";
    }

    public class FakePageObject : PageObject
    {
        [Selector(".tweet")]
        public virtual Task<IElementHandle> SelectorForElementHandle { get; }

        [Selector("div")]
        public virtual Task<IElementHandle[]> SelectorForElementHandleArray { get; }

        [Selector(".retweets")]
        public virtual Task<FakeElementObject> SelectorForElementObject { get; }

        [Selector("div")]
        public virtual Task<FakeElementObject[]> SelectorForElementObjectArray { get; }

        [XPath("//div")]
        public virtual Task<IElementHandle[]> XPathForElementHandleArray { get; }

        [XPath("//div")]
        public virtual Task<FakeElementObject[]> XPathForElementObjectArray { get; }

        // Fail

        [Selector(".tweet")]
        public virtual Task<object> SelectorForWrongReturnType { get; }

        [Selector(".tweet")]
        public virtual IElementHandle SelectorForNonTaskReturnType { get; }

        [Selector(".retweets")]
        public virtual FakeElementObject SelectorForElementObjectWithNonTaskReturnType { get; }

        [Selector("div")]
        public virtual FakeElementObject[] SelectorForElementObjectArrayWithNonTaskReturnType { get; }

        [XPath("//div")]
        public virtual Task<object[]> XPathForWrongReturnType { get; }

        [XPath("//div")]
        public virtual IElementHandle[] XPathForNonTaskReturnType { get; }
    }

    public class FakeElementObject : ElementObject
    {
        [Selector(".tweet")]
        public virtual Task<IElementHandle> SelectorForElementHandle { get; }

        [Selector("div")]
        public virtual Task<IElementHandle[]> SelectorForElementHandleArray { get; }

        [Selector(".retweets")]
        public virtual Task<FakeElementObject> SelectorForElementObject { get; }

        [Selector("div")]
        public virtual Task<FakeElementObject[]> SelectorForElementObjectArray { get; }

        [XPath("//div")]
        public virtual Task<IElementHandle[]> XPathForElementHandleArray { get; }

        [XPath("//div")]
        public virtual Task<FakeElementObject[]> XPathForElementObjectArray { get; }

        // Fail

        [Selector(".tweet")]
        public virtual Task<object> SelectorForWrongReturnType { get; }

        [Selector(".tweet")]
        public virtual IElementHandle SelectorForNonTaskReturnType { get; }

        [XPath("//div")]
        public virtual Task<object[]> XPathForWrongReturnType { get; }

        [XPath("//div")]
        public virtual IElementHandle[] XPathForNonTaskReturnType { get; }
    }

    public class FakeObjectWithNoBaseClass
    {
        [Selector(".tweet")]
        public virtual Task<IElementHandle> SelectorForElementHandle { get; }

        [XPath("//div")]
        public virtual Task<IElementHandle[]> XPathForElementHandleArray { get; }
    }

    public class FakeInvocation(MethodInfo proxiedMethod, object proxy = null) : AbstractInvocation(proxy, null, proxiedMethod, null)
    {
        protected override void InvokeMethodOnTarget() => throw new NotImplementedException();

        public override object InvocationTarget { get; } = proxy;
        public override Type TargetType { get; } = proxiedMethod.DeclaringType;
        public override MethodInfo MethodInvocationTarget { get; }
    }
}
