using CarsPageObject.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Pages.Forms
{
    internal class GlobalHeaderForm : BaseForm
    {
        private static BaseElement baseElement = new BaseElement(By.XPath("//div[@class = 'global-header-menu-links']"), "BaseElement");
        private Link researchButton = new Link(By.XPath("//li//a[@data-linkname = 'header-research']"), "Research link");

        public GlobalHeaderForm() : base(baseElement, "Global Header") { }

        public void ClickOnResearchButton() {
            researchButton.Click(baseElement);
        }
    }
}
