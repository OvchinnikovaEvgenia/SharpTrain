using OpenQA.Selenium;

namespace SpecFlowProjectCars.PageObject.Elements
{
    internal class Button : BaseElement
    {
        public Button(By locator, string name) : base(locator, name) { }

        public bool isEnable()
        {
           return this.FindElement().Enabled;
        }
    }
}
