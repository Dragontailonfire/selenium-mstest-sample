using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace Pages
{
    public class DriverManager
    {
        private static IWebDriver _webDriver;
        private static WebDriverWait _wait;
        public static IWebDriver Driver => LaunchDriver();
        public static WebDriverWait Wait => CreateWebDriverWait();

        private static WebDriverWait CreateWebDriverWait()
        {
            if (_wait != null)  return _wait;

            _wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            return _wait;
        }

        private static IWebDriver LaunchDriver()
        {
            if (_webDriver != null) return _webDriver;

            string browser = Browser.BrowserName;
            string browserPath = Directory.GetCurrentDirectory() + Browser.GetBrowserPath();

            switch (browser)
            {
                case "Chrome":
                    _webDriver = new ChromeDriver(browserPath);
                    break;
                case "Firefox":
                    _webDriver = new FirefoxDriver(browserPath);
                    break;
                case "IE":
                    _webDriver = new InternetExplorerDriver(browserPath);
                    break;
                default: throw new Exception("No proper Browser name given in config");
            }
            return _webDriver;
        }

        public static void DisposeDriver()
        {
            if (_webDriver != null) _webDriver.Quit();

            _webDriver = null;
        }
    }
}
