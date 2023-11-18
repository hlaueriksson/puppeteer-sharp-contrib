using System;
using System.Diagnostics;

namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <para>Represents an XPath expression for a property on a <see cref="PageObject"/> or <see cref="ElementObject"/>.</para>
    /// <para>Properties decorated with a <see cref="XPathAttribute"/> must be a:</para>
    /// <list type="bullet">
    /// <item><description>public</description></item>
    /// <item><description>virtual</description></item>
    /// <item><description>getter</description></item>
    /// </list>
    /// that returns a <see cref="System.Threading.Tasks.Task{TResult}"/> of:
    /// <list type="bullet">
    /// <item><description><see cref="IElementHandle"/>[] or</description></item>
    /// <item><description><see cref="ElementObject"/>[]</description></item>
    /// </list>
    /// </summary>
    /// <example>
    /// Usage:
    /// <code>
    /// <![CDATA[
    /// [XPath("//div")]
    /// public virtual Task<IElementHandle[]> XPathForElementHandleArray { get; }
    ///
    /// [XPath("//div")]
    /// public virtual Task<FooElementObject[]> XPathForElementObjectArray { get; }
    /// ]]>
    /// </code>
    /// </example>
    [Obsolete("Use " + nameof(SelectorAttribute) + " instead")]
    [AttributeUsage(AttributeTargets.Property)]
    [DebuggerDisplay("{Expression}")]
    public sealed class XPathAttribute(string expression) : Attribute
    {
        /// <summary>
        /// An XPath expression to evaluate on a <see cref="IPage"/> or <see cref="IElementHandle"/>.
        /// </summary>
        public string Expression { get; } = expression;
    }
}
