using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace Pages.ProductPage
{
    public class ProductPage : Page
    {
        #region Fields
        private IElementLocators _elementLocators;
        private static Dictionary<string, IElementLocators> browserLocators = new Dictionary<string, IElementLocators>
        {
            {"Chrome", new ChromeElementLocators() },
            {"IE", new ChromeElementLocators() }
        };
        #endregion
        #region Constructors
        private ProductPage()
        {

        }
        private ProductPage(IElementLocators ElementLocators)
        {
            _elementLocators = ElementLocators;
        }
        #endregion
        public static ProductPage GetProductPage()
        {
            return new ProductPage(GetBrowserSpecificLocator());
        }
        public static IElementLocators GetBrowserSpecificLocator()
        {
            return browserLocators[Browser.BrowserName];
        }
        #region Test steps
        public ProductPage GiveProductQuantity(string quantity)
        {
            By locator = By.Id(_elementLocators.QuantityTextBoxId);
            EnterTextInThisField(locator, quantity);
            return this;
        }
        public ProductPage SelectProductSize(string size)
        {
            By locator = By.Id(_elementLocators.SizeDropDownId);
            MakeDropDownSelectionUsingText(locator, size);
            return this;
        }
        public void ClickAddToCart()
        {
            By locator = By.XPath(_elementLocators.AddToCartButtonXpath);
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
            By locator = By.XPath(_elementLocators.ProductHeadingXpath);
            GetElementAttribute(locator, "innerText").Should().Be(product);
            return this;
        }
        #endregion
    }
}
