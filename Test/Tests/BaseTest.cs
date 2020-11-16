using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;


namespace Test.Tests
{
    public class BaseTest 
    {
        protected IWebDriver driver;
        protected string browserType;

        [SetUp]
        public void BaseSetup()
        {
            string context= TestContext.Parameters["Browser"];
            switch (context)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = GetDriverFromConfig(driver);
                    break;
            }
            driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void BaseTearDown()
        {
            driver.Quit();
        }

        private IWebDriver GetDriverFromConfig(IWebDriver driver)
        {
            string browserName = ConfigurationManager.AppSettings["Browser"];
            switch (browserName)
            {
                case "Chrome":
                    return driver = new ChromeDriver();
                case "Firefox":
                    return driver = new FirefoxDriver();
                default:
                    return driver = new ChromeDriver();
            }
        }

    }
 
}