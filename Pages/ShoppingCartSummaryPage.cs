using FluentAssertions;
using OpenQA.Selenium;

namespace Pages
{
    public class ShoppingCartSummaryPage : Page
    {
        private ShoppingCartSummaryPage()
        {

        }
        public static ShoppingCartSummaryPage GetShoppingCartSummaryPage()
        {
            return new ShoppingCartSummaryPage();
        }
        #region Verifications
        public ShoppingCartSummaryPage VerifyPageIsDisplayed()
        {
            By locator = By.Id("cart_title");
            IWebElement element = Driver.FindElement(locator);
            return this;
        }
        public void VerifyProductDetails(string name, string size, string quantity)
        {
            By NameLocator = By.XPath("(//p[@class='product-name'])[2]");
            IWebElement elementName = Driver.FindElement(NameLocator);
            By SizeLocator = By.XPath("(//*[text()[contains(.,'Size')]])[2]");
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
