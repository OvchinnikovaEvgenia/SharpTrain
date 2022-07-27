using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProjectCars.PageObject.Browsers
{
    internal class BrowserFactory
    {
        private static IWebDriver _webDriver = null;

        private BrowserFactory() { }

        public static IWebDriver getDriver()
        {
            return _webDriver ?? (_webDriver = new ChromeDriver());
        }
    }
}
