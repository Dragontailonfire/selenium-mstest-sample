using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public abstract class Page
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait DriverWait { get; }
        protected Page()
        {
            Driver = DriverManager.Driver;
            DriverWait = DriverManager.Wait;
        }
        #region Test steps
        public void EnterTextInThisField(By elementIdentifier, string textToEnter)
        {
            IWebElement pageElement = Driver.FindElement(elementIdentifier);
            pageElement.Clear();
            pageElement.SendKeys(textToEnter);
        }
        public void ClickThisButton(By elementIdentifier)
        {
            DriverWait.Until(e => e.FindElement(elementIdentifier)).Click();
            //Driver.FindElement(elementIdentifier).Click();
        }
        public void MakeDropDownSelectionUsingText(By elementIdentifier, string dropDownText)
        {
            new SelectElement(Driver.FindElement(elementIdentifier)).SelectByText(dropDownText);
        }
        public string GetElementAttribute(By elementIdentifier, string attribute)
        {
            return Driver.FindElement(elementIdentifier).GetAttribute(attribute);
        }
        #endregion
    }
}
