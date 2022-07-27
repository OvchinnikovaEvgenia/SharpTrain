using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Browsers
{
    internal class BrowserFactory
    {
        private static IWebDriver _webDriver = null;

        private BrowserFactory() { }

        public static IWebDriver getDriver() {
            return _webDriver ?? (_webDriver = new ChromeDriver());
        }

    }
}
