using OpenQA.Selenium;

namespace SpecFlowProjectCars.PageObject.Elements
{
    internal interface IBaseElement
    {
        private By locator { get => locator; set { locator = value; } }
        private string name { get => name; set { name = name; } }

        public bool IsDisplayed();

        public void WaitForPresense();

        public IWebElement FindChildElement(By childLocator);
    }
}
