using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Extensions;
using System;

namespace Test.Extensions
{
    public static class ElementExtensions
    {
        public static IWebElement SetValue(this IWebElement element, object text)
        {
            var script = "arguments[0].value=arguments[1]";
            element.GetDriver().ExecuteJavaScript(script, element.Unwrap(), text);
            return element;
        }

        public static IWebDriver GetDriver(this IWebElement element)
        {
            var wrapped = element.Unwrap() as IWrapsDriver;
            if (wrapped == null)
            {
                throw new ArgumentException("Element must wrap WebDriver");
            }
            return wrapped.WrappedDriver;
        }

        public static IWebElement Unwrap(this IWebElement element)
        {
            var wrapped = element as IWrapsElement;
            if (wrapped != null)
            {
                return wrapped.WrappedElement.Unwrap();
            }
            return element;
        }
    }
}
