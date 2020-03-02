using Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pages.HomePage;
using Pages.ProductPage;

namespace ApplicationTests
{
    [TestClass]
    public class AddToCartTest
    {
        readonly HomePage _homePage = HomePage.GetHomePage();
        readonly SearchCategoryResultPage _searchCategoryResultPage = SearchCategoryResultPage.GetSearchCategoryResultPage();
        readonly ProductPage _productPage = ProductPage.GetProductPage();
        readonly AddedToCartModalPage _addedToCartModalPage = AddedToCartModalPage.GetAddedToCartModalPage();
        readonly ShoppingCartSummaryPage _shoppingCartSummaryPage = ShoppingCartSummaryPage.GetShoppingCartSummaryPage();
        
        [TestInitialize]
        public void StartUp()
        {
        }

        [TestMethod]
        public void AddTshirtToCartAndVerifyCheckoutPage()
        {
            var testAppSettings = new ConfigurationBuilder().AddJsonFile("ApplicationProperties.json").Build();

            _homePage
                    .NavigateHere(testAppSettings["test_url"])
                    .ClickMenuItem("Women");

            _searchCategoryResultPage
                    .VerifyPageIsDisplayed("WOMEN")
                    .OpenProduct("Faded Short Sleeve T-shirts");

            _productPage
                    .VerifyPageIsDisplayed("Faded Short Sleeve T-shirts")
                    .GiveProductQuantity("2")
                    .SelectProductSize("M")
                    .ClickAddToCart();

            _addedToCartModalPage
                    .VerifyPageIsDisplayed()
                    .ClickProceedToCheckout();

            _shoppingCartSummaryPage
                    .VerifyPageIsDisplayed()
                    .VerifyProductDetails("Faded Short Sleeve T-shirts", "M", "2");
        }

        [TestCleanup]
        public void ShutDown()
        {
            DriverManager.DisposeDriver();
        }
    }
}
