using FluentAssertions;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Pages.ShoppingCartSummaryPage
{
    public class ShoppingCartSummaryPage : Page
    {
        #region Fields
        private readonly IShoppingCartSummaryPageElements _pageElements;
        private static readonly Dictionary<string, IShoppingCartSummaryPageElements> browserElementLocators = new Dictionary<string, IShoppingCartSummaryPageElements>
        {
            {"Chrome", new ChromeShoppingCartSummaryPageElements() },
            {"IE", new ChromeShoppingCartSummaryPageElements() }
        };
        #endregion
        #region Constructors
        private ShoppingCartSummaryPage()
        {

        }
        private ShoppingCartSummaryPage(IShoppingCartSummaryPageElements PageElements)
        {
            _pageElements = PageElements;
        }
        #endregion
        public static ShoppingCartSummaryPage GetShoppingCartSummaryPage()
        {
            return new ShoppingCartSummaryPage(GetBrowserPageElement());
        }
        public static IShoppingCartSummaryPageElements GetBrowserPageElement()
        {
            return browserElementLocators[Browser.BrowserName];
        }
        #region Verifications
        public ShoppingCartSummaryPage VerifyPageIsDisplayed()
        {
            By locator = By.Id(_pageElements.CartTitleId);
            Driver.FindElement(locator);
            return this;
        }
        public void VerifyProductDetails(string name, string size, string quantity)
        {
            By NameLocator = By.XPath(_pageElements.ProductNameXpath);
            IWebElement elementName = Driver.FindElement(NameLocator);
            By SizeLocator = By.XPath(_pageElements.ProductSizeXpath);
            IWebElement elementSize = Driver.FindElement(SizeLocator);

            //Quantity compared from element identification itself
            By QuantityLocator = By.XPath("//*[@class='cart_quantity_input form-control grey' and @value='" + quantity + "']");
            IWebElement elementQuantity = Driver.FindElement(QuantityLocator);

            //Take the entire text and take substring to get size and comapre
            string sizeText = elementSize.GetAttribute("innerText");
            int position = sizeText.LastIndexOf("Size : ");
            sizeText.Substring(position + "Size : ".Length).Trim().Should().Be(size);

            //Comapre name
            string nameText = elementName.GetAttribute("innerText").Trim();
            nameText.Should().Be(name);
        }
        #endregion
    }
}
