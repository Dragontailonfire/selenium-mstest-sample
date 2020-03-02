using Microsoft.Extensions.Configuration;
using System;

namespace Pages
{
    public enum Browsers
    {
        Chrome, InternetExplorer, Firefox, Android, IOs
    }
    public class Browser
    {
        private static string _browserName;
        public static string BrowserName => GetBrowser();

        private static string GetBrowser()
        {
            if (_browserName != null) return _browserName;           
            var settings = new ConfigurationBuilder().AddJsonFile("ApplicationProperties.json").Build();
            _browserName = settings["test_browser"];
            return _browserName;
        }
        public static string GetBrowserPath()
        {
            var settings = new ConfigurationBuilder().AddJsonFile("ApplicationProperties.json").Build();
            return settings["test_browser_path"];
        }
    }
}
