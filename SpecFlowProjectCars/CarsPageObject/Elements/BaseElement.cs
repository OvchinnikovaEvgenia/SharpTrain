using CarsPageObject.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Elements
{
    internal class BaseElement : IBaseElement
    {
        private By locator { get; set; }
        private string name { get; set; }

        public BaseElement(By locator, string name)
        {
            this.locator = locator;
            this.name = name;
        }

        public bool IsDisplayed()
        {
            return BrowserFactory.getDriver().FindElement(locator).Displayed;

        }

        public void WaitForPresense() {

            ConfigManager.GetWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }

        public IWebElement FindElement() {
            return BrowserFactory.getDriver().FindElement(locator);
        }

        public IWebElement FindChildElement(By childLocator) {
           return this.FindElement().FindElement(childLocator);
        }

        public void Click(IBaseElement parentElement) {
            parentElement.WaitForPresense();
            this.WaitForPresense();
            parentElement.FindChildElement(locator).Click();
        }

        public void Click() {
            this.WaitForPresense();
            this.FindElement().Click();
        }

        public string GetText() {
            return this.FindElement().Text;
        }

    }
}
