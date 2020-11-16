using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Configuration;
using System;
using SeleniumExtras.PageObjects;

namespace Test.PageObjects
{

    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        protected string testUrl = ConfigurationManager.AppSettings["URL"];

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement elem_search_input;

        public void Load()
        {
            driver.Navigate().GoToUrl(testUrl);
        }
        public SearchItemDetails FindProductByCode(string code)
        {
            elem_search_input.SendKeys(code);
            elem_search_input.Submit();
            wait.Until(c => c.FindElement(By.Name("qty")));
            return new SearchItemDetails(driver);
        }
    }
}