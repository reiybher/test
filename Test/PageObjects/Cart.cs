using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Globalization;

namespace Test.PageObjects
{
    public class Cart
    {
        protected IWebDriver driver;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".right > div:nth-child(1) > span:nth-child(1)")]
        private IWebElement subtotal;

        public decimal Subtotal => decimal.Parse(subtotal.Text, NumberStyles.Any, new CultureInfo("en-US"));
    }
}
