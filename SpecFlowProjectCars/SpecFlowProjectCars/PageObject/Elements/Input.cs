using OpenQA.Selenium;

namespace SpecFlowProjectCars.PageObject.Elements
{
    internal class Input: BaseElement
    {
        public Input(By locator, string name) : base(locator, name) { }

        public void WaitForSelected()
        {
            ConfigManager.GetFluentWait().Until(
                web =>  this.IsSelected());
        }
    }
}
