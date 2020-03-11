using OpenQA.Selenium;

namespace Pages.HomePage
{
    public class HomePage : Page
    {
        private HomePage(IWebDriver driver) : base(driver)
        {

        }
        public static HomePage GetHomePage(IWebDriver driver)
        {
            return new HomePage(driver);
        }
        #region Test steps
        public HomePage NavigateHere(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
            return this;
        }
        public void ClickMenuItem(string menuName)
        {
            By locator = By.LinkText(menuName);
            ClickThisButton(locator);
        }
        #endregion
    }
}
