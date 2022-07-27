using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SpecFlowProjectCars.PageObject.Browsers;

namespace SpecFlowProjectCars.PageObject.Elements
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

        public void WaitForPresense()
        {

            ConfigManager.GetWait().Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void ElementToBeClickable() 
        {
            ConfigManager.GetWait().Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public IWebElement FindElement() 
        {
            return BrowserFactory.getDriver().FindElement(locator);
        }

        public IWebElement FindChildElement(By childLocator) 
        {
            return this.FindElement().FindElement(childLocator);
        }

        public void Click()
        {
            this.WaitForPresense();
            this.ElementToBeClickable();
            this.FindElement().Click();
        }

        public string GetText() 
        {
            this.WaitForPresense();
            return this.FindElement().Text;
        }

        public List<IWebElement> FindElements() 
        {
            return BrowserFactory.getDriver().FindElements(locator).ToList();
        }

        public void SendKeys(string text) 
        {
            this.FindElement().SendKeys(text);
        }

        public bool IsSelected() 
        {
            return this.FindElement().Selected;
        }

        public bool IsElementExist()
        {
            return this.FindElements().Count > 0;
        }
    }
}
