using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;

namespace CarsPageObject.Pages.Forms
{
    internal class GlobalHeaderForm : BaseForm
    {
        private static BaseElement baseElement = new BaseElement(By.XPath("//div[@class = 'global-header-menu-links']"), "BaseElement");
        private Link researchButton = new Link(By.XPath("//li//a[@data-linkname = 'header-research']"), "Research link");

        public GlobalHeaderForm() : base(baseElement, "Global Header") { }

        public void ClickOnResearchButton()
        {
            researchButton.Click();       
        }
    }
}
