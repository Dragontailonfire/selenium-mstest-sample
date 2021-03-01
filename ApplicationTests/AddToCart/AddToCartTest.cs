using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pages;
using Pages.HomePage;
using Pages.ProductPage;
using Pages.ShoppingCartSummaryPage;

[assembly: Parallelize(Workers = 2, Scope = ExecutionScope.MethodLevel)]

namespace ApplicationTests.AddToCart
{
    [TestClass]
    public class AddToCartTest
    {
        #region Add to cart tests
        [TestMethod]
        public void AddTshirtToCartAndVerifyCheckoutPage()
        {
            var testAppSettings = new ConfigurationBuilder().AddJsonFile("ApplicationProperties.json").Build();
            var testData = new ConfigurationBuilder().AddJsonFile("AddToCart\\AddToCartData.json").Build();

            string url = testAppSettings["test_url"];
            string menuItem = testData["AddTshirtToCartAndVerifyCheckoutPage:MenuItem"];
            string productName = testData["AddTshirtToCartAndVerifyCheckoutPage:ProductName"];
            string productSize = testData["AddTshirtToCartAndVerifyCheckoutPage:ProductSize"];
            string productQuantity = testData["AddTshirtToCartAndVerifyCheckoutPage:ProductQuantity"];

            using (IWebDriver driver = new DriverManager().Driver)
            {
                HomePage homePage = HomePage.GetHomePage(driver);
                SearchCategoryResultPage searchCategoryResultPage = SearchCategoryResultPage.GetSearchCategoryResultPage(driver);
                ProductPage productPage = ProductPage.GetProductPage(driver);
                AddedToCartModalPage addedToCartModalPage = AddedToCartModalPage.GetAddedToCartModalPage(driver);
                ShoppingCartSummaryPage shoppingCartSummaryPage = ShoppingCartSummaryPage.GetShoppingCartSummaryPage(driver);

                homePage
                    .NavigateHere(url)
                    .ClickMenuItem(menuItem);

                searchCategoryResultPage
                        .VerifyPageIsDisplayed(menuItem.ToUpper())
                        .OpenProduct(productName);

                productPage
                        .VerifyPageIsDisplayed(productName)
                        .GiveProductQuantity(productQuantity)
                        .SelectProductSize(productSize)
                        .ClickAddToCart();

                addedToCartModalPage
                        .VerifyPageIsDisplayed()
                        .ClickProceedToCheckout();

                shoppingCartSummaryPage
                        .VerifyPageIsDisplayed()
                        .VerifyProductDetails(productName, productSize, productQuantity);

                Assert.Fail("I am going to fail you!");
            }
        }

        [TestMethod]
        public void AddAnotherTshirtToCartAndVerifyCheckoutPage()
        {
            var testAppSettings = new ConfigurationBuilder().AddJsonFile("ApplicationProperties.json").Build();
            var testData = new ConfigurationBuilder().AddJsonFile("AddToCart\\AddToCartData.json").Build();

            string url = testAppSettings["test_url"];
            string menuItem = testData["AddTshirtToCartAndVerifyCheckoutPage:MenuItem"];
            string productName = testData["AddTshirtToCartAndVerifyCheckoutPage:ProductName"];
            string productSize = testData["AddTshirtToCartAndVerifyCheckoutPage:ProductSize"];
            string productQuantity = testData["AddTshirtToCartAndVerifyCheckoutPage:ProductQuantity"];

            using (IWebDriver driver = new DriverManager().Driver)
            {
                HomePage homePage = HomePage.GetHomePage(driver);
                SearchCategoryResultPage searchCategoryResultPage = SearchCategoryResultPage.GetSearchCategoryResultPage(driver);
                ProductPage productPage = ProductPage.GetProductPage(driver);
                AddedToCartModalPage addedToCartModalPage = AddedToCartModalPage.GetAddedToCartModalPage(driver);
                ShoppingCartSummaryPage shoppingCartSummaryPage = ShoppingCartSummaryPage.GetShoppingCartSummaryPage(driver);

                homePage
                    .NavigateHere(url)
                    .ClickMenuItem(menuItem);

                searchCategoryResultPage
                        .VerifyPageIsDisplayed(menuItem.ToUpper())
                        .OpenProduct(productName);

                productPage
                        .VerifyPageIsDisplayed(productName)
                        .GiveProductQuantity(productQuantity)
                        .SelectProductSize(productSize)
                        .ClickAddToCart();

                addedToCartModalPage
                        .VerifyPageIsDisplayed()
                        .ClickProceedToCheckout();

                shoppingCartSummaryPage
                        .VerifyPageIsDisplayed()
                        .VerifyProductDetails(productName, productSize, productQuantity);
            }
        }
        #endregion
    }
}
