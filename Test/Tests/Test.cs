using NUnit.Framework;
using Test.PageObjects;
using System.Configuration;

namespace Test.Tests
{
    public class Test : BaseTest
    {
       [Test]
        public void Test3()
        {
            int itemsQuantity = int.Parse(ConfigurationManager.AppSettings["ItemQuantity"]);

            HomePage homePage = new HomePage(driver);
            homePage.Load();
            var itemDetails = homePage.FindProductByCode("99TBM96CSSVK");
            itemDetails.IncreaseQty(itemsQuantity);
            var specialPriсe = itemDetails.SpecialPrice;
            var cart = itemDetails.AddToCart();

            Assert.That(specialPriсe, Is.EqualTo(cart.Subtotal / itemsQuantity));
        }
    }
}