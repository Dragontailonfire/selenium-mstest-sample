using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace Pages.ProductPage
{
    public class ProductPage : Page
    {
        #region Fields
        private readonly IProductPageElements _pageElements;
        private static readonly Dictionary<string, IProductPageElements> browserElementLocators = new Dictionary<string, IProductPageElements>
        {
            {"Chrome", new ChromeProductPageElements() },
            {"IE", new ChromeProductPageElements() }
        };
        #endregion
        #region Constructors
        private ProductPage()
        {

        }
        private ProductPage(IProductPageElements PageElements)
        {
            _pageElements = PageElements;
        }
        #endregion
        public static ProductPage GetProductPage()
        {
            return new ProductPage(GetBrowserPageElement());
        }
        public static IProductPageElements GetBrowserPageElement()
        {
            return browserElementLocators[Browser.BrowserName];
        }
        #region Test steps
        public ProductPage GiveProductQuantity(string quantity)
        {
            By locator = By.Id(_pageElements.QuantityTextBoxId);
            EnterTextInThisField(locator, quantity);
            return this;
        }
        public ProductPage SelectProductSize(string size)
        {
            By locator = By.Id(_pageElements.SizeDropDownId);
            MakeDropDownSelectionUsingText(locator, size);
            return this;
        }
        public void ClickAddToCart()
        {
            By locator = By.XPath(_pageElements.AddToCartButtonXpath);
            IWebElement element = DriverWait.Until(e => e.FindElement(locator));
            Actions builder = new Actions(Driver);
            builder.MoveToElement(element).Click();
            IAction ClickAddToCart = builder.Build();
            ClickAddToCart.Perform();
        }
        #endregion
        #region Verifications
        public ProductPage VerifyPageIsDisplayed(string product)
        {
            By locator = By.XPath(_pageElements.ProductHeadingXpath);
            GetElementAttribute(locator, "innerText").Should().Be(product);
            return this;
        }
        #endregion
    }
}
