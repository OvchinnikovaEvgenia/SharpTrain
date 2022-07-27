using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProjectCars.PageObject.Browsers;

namespace SpecFlowProjectCars.PageObject
{
    internal class ConfigManager
    {
        private  static WebDriverWait wait = null;
        private static DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(BrowserFactory.getDriver());

        private ConfigManager()
        {
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(40);
        }

        public static WebDriverWait GetWait() 
        {
            return wait ?? (wait = new WebDriverWait(BrowserFactory.getDriver() ,TimeSpan.FromSeconds(10)));
        }

        public static DefaultWait<IWebDriver> GetFluentWait()
        {
            return fluentWait;
        }
    }
}
