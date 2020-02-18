using System;

namespace PuppeteerSharp.Contrib.PageObjects
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SelectorAttribute : Attribute
    {
        public string Selector { get; }

        public SelectorAttribute(string selector)
        {
            Selector = selector;
        }
    }
}