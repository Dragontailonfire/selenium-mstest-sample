using OpenQA.Selenium;

namespace Pages.ShoppingCartSummaryPage
{
    class ChromeShoppingCartSummaryPageElements : IShoppingCartSummaryPageElements
    {
        public By CartTitle => By.Id("cart_title");

        public By ProductName => By.XPath("(//p[@class='product-name'])[2]");

        public By ProductSize => By.XPath("(//*[text()[contains(.,'Size')]])[2]");
    }
}
