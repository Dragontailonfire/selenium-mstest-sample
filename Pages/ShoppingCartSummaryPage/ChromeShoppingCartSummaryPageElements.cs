namespace Pages.ShoppingCartSummaryPage
{
    class ChromeShoppingCartSummaryPageElements : IShoppingCartSummaryPageElements
    {
        public string CartTitleId => "cart_title";

        public string ProductNameXpath => "(//p[@class='product-name'])[2]";

        public string ProductSizeXpath => "(//*[text()[contains(.,'Size')]])[2]";
    }
}
