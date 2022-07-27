using CarsPageObject.Browsers;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject
{
    internal class ConfigManager
    {
        private  static WebDriverWait wait = null;

        private ConfigManager() { }

        public static WebDriverWait GetWait() {
            return wait ?? (wait = new WebDriverWait(BrowserFactory.getDriver() ,TimeSpan.FromSeconds(10)));
        }
    }
}
