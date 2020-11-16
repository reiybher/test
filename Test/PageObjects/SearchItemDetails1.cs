using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
using System.Globalization;
using Test.Extensions;

namespace Test.PageObjects
{
    public class SearchItemDetails
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SearchItemDetails(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".price-details .special-price span")]
        private IWebElement specialPrice;

        [FindsBy(How = How.CssSelector, Using = ".btn-cart")]
        private IWebElement addToCart;

        [FindsBy(How = How.Name, Using = "qty")]
        private IWebElement qty;


        public string SpecialPriceAsString => specialPrice.Text;
     
        public decimal SpecialPrice => decimal.Parse(SpecialPriceAsString, NumberStyles.Any, new CultureInfo("en-US"));


        public Cart AddToCart()
        {
            addToCart.Click();
            wait.Until(c => c.FindElement(By.CssSelector(".right > div:nth-child(1) > span:nth-child(1)")));
            return new Cart(driver);
        }

        public void IncreaseQty(int config_qty)
        {
            qty.SetValue(Convert.ToString(config_qty));
        }
    }
}
