using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Elements
{
    internal class ElementSelect
    {
        private By locator;
        private String name;
        public ElementSelect(By locator, String name) {
            this.locator = locator;
            this.name = name;   
        }

        public void SelectByText(String text) {
            IWebElement elementSelect = Browsers.BrowserFactory.getDriver().FindElement(locator);
            SelectElement selectElement = new SelectElement(elementSelect);
            selectElement.SelectByText(text);
        }
    }
}
