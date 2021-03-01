using OpenQA.Selenium;

namespace Pages.ShoppingCartSummaryPage
{
    public interface IShoppingCartSummaryPageElements
    {
        By CartTitle { get; }
        By ProductName { get; }
        By ProductSize { get; }
    }
}
