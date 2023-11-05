namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <para>Base class for page objects.</para>
    /// <para>Create page objects by inheriting <see cref="PageObject"/> and declare properties decorated with <see cref="SelectorAttribute"/>.</para>
    /// </summary>
    /// <example>
    /// Usage:
    /// <code>
    /// <![CDATA[
    /// public class FooPageObject : PageObject
    /// {
    ///     [Selector("#foo")]
    ///     public virtual Task<IElementHandle> SelectorForElementHandle { get; }
    ///
    ///     [Selector(".bar")]
    ///     public virtual Task<IElementHandle[]> SelectorForElementHandleArray { get; }
    ///
    ///     [Selector("#foo")]
    ///     public virtual Task<FooElementObject> SelectorForElementObject { get; }
    ///
    ///     [Selector(".bar")]
    ///     public virtual Task<BarElementObject[]> SelectorForElementObjectArray { get; }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public abstract class PageObject
    {
        /// <summary>
        /// The <c>PuppeteerSharp</c> page.
        /// </summary>
        public IPage Page { get; private set; } = null!;

        /// <summary>
        /// The response from page navigation.
        /// </summary>
        public IResponse Response { get; private set; } = null!;

        internal void Initialize(IPage page, IResponse response)
        {
            Page = page;
            Response = response;
        }
    }
}
