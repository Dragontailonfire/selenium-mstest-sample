using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;

namespace Pages
{
    public class DriverManager
    {
        public static IWebDriver Driver => LaunchDriver();

        private static IWebDriver LaunchDriver()
        {
            string browser = Browser.BrowserName;
            string browserPath = Directory.GetCurrentDirectory() + Browser.GetBrowserPath();

            return browser switch
            {
                "Chrome" => new ChromeDriver(browserPath),
                "Firefox" => new FirefoxDriver(browserPath),
                "IE" => new InternetExplorerDriver(browserPath),
                _ => throw new Exception("No proper Browser name given in properties file"),
            };
        }
    }
}
