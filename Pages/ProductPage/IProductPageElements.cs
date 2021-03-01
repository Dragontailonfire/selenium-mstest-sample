using OpenQA.Selenium;

namespace Pages.ProductPage
{
    public interface IProductPageElements
    {
        By ProductHeading { get; }
        By QuantityTextBox { get; }
        By SizeDropDown { get; }
        By AddToCartButton { get; }
    }
}