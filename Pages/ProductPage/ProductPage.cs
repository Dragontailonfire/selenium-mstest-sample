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
        private ProductPage(IProductPageElements PageElements, IWebDriver driver) : base (driver)
        {
            _pageElements = PageElements;
        }
        #endregion
        public static ProductPage GetProductPage(IWebDriver driver)
        {
            return new ProductPage(GetBrowserPageElement(), driver);
        }
        public static IProductPageElements GetBrowserPageElement()
        {
            return browserElementLocators[Browser.BrowserName];
        }
        #region Test steps
        public ProductPage GiveProductQuantity(string quantity)
        {
            EnterTextInThisField(_pageElements.QuantityTextBox, quantity);
            return this;
        }
        public ProductPage SelectProductSize(string size)
        {
            MakeDropDownSelectionUsingText(_pageElements.SizeDropDown, size);
            return this;
        }
        public void ClickAddToCart()
        {
            IWebElement element = DriverWait.Until(e => e.FindElement(_pageElements.AddToCartButton));
            Actions builder = new Actions(Driver);
            builder.MoveToElement(element).Click();
            IAction ClickAddToCart = builder.Build();
            ClickAddToCart.Perform();
        }
        #endregion
        #region Verifications
        public ProductPage VerifyPageIsDisplayed(string product)
        {
            GetElementAttribute(_pageElements.ProductHeading, "innerText").Should().Be(product);
            return this;
        }
        #endregion
    }
}
