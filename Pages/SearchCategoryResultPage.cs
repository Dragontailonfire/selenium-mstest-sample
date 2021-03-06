﻿using OpenQA.Selenium;
using FluentAssertions;

namespace Pages
{
    public class SearchCategoryResultPage : Page
    {
        private SearchCategoryResultPage(IWebDriver driver) : base(driver)
        {

        }
        public static SearchCategoryResultPage GetSearchCategoryResultPage(IWebDriver driver)
        {
            return new SearchCategoryResultPage(driver);
        }
        #region Test steps
        public void OpenProduct(string product)
        {
            By locator = By.XPath("(//a[@title='" + product + "'])[2]");
            ClickThisButton(locator);
        }
        #endregion
        #region Verifications
        public SearchCategoryResultPage VerifyPageIsDisplayed(string category)
        {
            By locator = By.ClassName("cat-name");
            IWebElement element = Driver.FindElement(locator);
            string categoryTitle = element.GetAttribute("innerText").Trim();
            categoryTitle.Should().Be(category);
            return this;
        }
        #endregion

    }
}
