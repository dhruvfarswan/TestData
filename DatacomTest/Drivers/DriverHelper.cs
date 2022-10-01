using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;

namespace DatacomTest.Drivers
{
    public class DriverHelper
    {
        public static IWebDriver Driver { get; set; }

        public IWebDriver Setup(String browserName)
        {
            Driver = GetBrowserOption(browserName);
            Driver.Manage().Window.Maximize();
            return Driver;
        }
        private dynamic GetBrowserOption(string browserName)
        {
            if (browserName.ToLower() == "chrome")
            {
                return new ChromeDriver();
            }
            if (browserName.ToLower() == "edge")
            {
                return new EdgeDriver();
            }
            if (browserName.ToLower() == "safari")
            {
                return new SafariDriver();
            }
            return new ChromeDriver();
        }
    }

}

