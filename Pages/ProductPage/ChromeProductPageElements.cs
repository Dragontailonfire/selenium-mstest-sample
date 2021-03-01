using OpenQA.Selenium;

namespace Pages.ProductPage
{
    public class ChromeProductPageElements : IProductPageElements
    {
        public By QuantityTextBox => By.Id("quantity_wanted");

        public By ProductHeading => By.XPath("//h1[@itemprop='name']");

        public By SizeDropDown => By.Id("group_1");

        public By AddToCartButton => By.XPath("//*[text()[contains(.,'Add to cart')]]");
    }
}
