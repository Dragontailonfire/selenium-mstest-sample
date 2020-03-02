using OpenQA.Selenium;

namespace Pages.HomePage
{
    public class HomePage : Page
    {
        private HomePage()
        {

        }
        public static HomePage GetHomePage()
        {
            return new HomePage();
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
