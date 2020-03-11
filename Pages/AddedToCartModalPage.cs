using OpenQA.Selenium;
using System.Threading;

namespace Pages
{
    public class AddedToCartModalPage : Page
    {
        private AddedToCartModalPage(IWebDriver driver) : base(driver)
        {

        }
        public static AddedToCartModalPage GetAddedToCartModalPage(IWebDriver driver)
        {
            return new AddedToCartModalPage(driver);
        }
        #region Test steps
        public void ClickProceedToCheckout()
        {
            //TODO: The dynamic waits are not working in this case. Adding sleep as temporary workaround.
            Thread.Sleep(2000);
            By locator = By.XPath("//*[text()[contains(.,'Proceed to checkout')]]");
            ClickThisButton(locator);
        }
        #endregion
        #region Verifications
        public AddedToCartModalPage VerifyPageIsDisplayed()
        {

            By locator = By.XPath("//*[text()[contains(.,'Product successfully added to your shopping cart')]]");
            IWebElement element = Driver.FindElement(locator);
            return this;
        }
        #endregion
    }
}
