using System;

namespace PuppeteerSharp.Contrib.PageObjects
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XPathAttribute : Attribute
    {
        public string Expression { get; }

        public XPathAttribute(string expression)
        {
            Expression = expression;
        }
    }
}