using System;
using System.Diagnostics;

namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <para>Represents a selector for a property on a <see cref="PageObject"/> or <see cref="ElementObject"/>.</para>
    /// <para>Properties decorated with a <see cref="SelectorAttribute"/> must be a:</para>
    /// <list type="bullet">
    /// <item><description>public</description></item>
    /// <item><description>virtual</description></item>
    /// <item><description>getter</description></item>
    /// </list>
    /// that returns a <see cref="System.Threading.Tasks.Task{TResult}"/> of:
    /// <list type="bullet">
    /// <item><description><see cref="IElementHandle"/>,</description></item>
    /// <item><description><see cref="IElementHandle"/>[],</description></item>
    /// <item><description><see cref="ElementObject"/> or</description></item>
    /// <item><description><see cref="ElementObject"/>[]</description></item>
    /// </list>
    /// </summary>
    /// <example>
    /// Usage:
    /// <code>
    /// <![CDATA[
    /// [Selector("#foo")]
    /// public virtual Task<IElementHandle> SelectorForElementHandle { get; }
    ///
    /// [Selector(".bar")]
    /// public virtual Task<IElementHandle[]> SelectorForElementHandleArray { get; }
    ///
    /// [Selector("#foo")]
    /// public virtual Task<FooElementObject> SelectorForElementObject { get; }
    ///
    /// [Selector(".bar")]
    /// public virtual Task<BarElementObject[]> SelectorForElementObjectArray { get; }
    /// ]]>
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    [DebuggerDisplay("{Selector}")]
    public sealed class SelectorAttribute(string selector) : Attribute
    {
        /// <summary>
        /// A selector to query a <see cref="IPage"/> or <see cref="IElementHandle"/> for.
        /// </summary>
        public string Selector { get; } = selector;
    }
}
