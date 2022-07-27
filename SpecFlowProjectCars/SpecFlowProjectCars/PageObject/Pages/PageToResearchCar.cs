using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;
using SpecFlowProjectCars.PageObject.Models;

namespace SpecFlowProjectCars.PageObject.Pages
{
    internal class PageToResearchCar : BasePage
    {
        private static BaseElement baseElement = new BaseElement(By.XPath("//div[contains(@class, 'research-search')]"),
            "Base element to research");
        private ElementSelect makeSelect = new ElementSelect(
            By.Id("make-select"), "Make select");
        private ElementSelect modelSelect = new ElementSelect(
            By.Id("model-select"), "Model select");
        private ElementSelect yearSelect = new ElementSelect(
            By.Id("year-select"), "Year select");
        private Button researchButton = new Button(
            By.XPath("//button[contains(@class, 'search-button')]"), "Search button");
        private Link compareCarsLink = new Link(
            By.XPath("//section[contains(@class, 'tools')]//a[contains(text(), 'Compare models')]"),
            "Link to compare models");

        public PageToResearchCar() : base(baseElement, "Form to research") { }

        public void SearchCar(Car car)
        {
            makeSelect.SelectByText(car.Make);
            modelSelect.SelectByText(car.Model);
            yearSelect.SelectByText(car.Year);
        }

        public void ClickResearchButton()
        {
            researchButton.Click();
        }

        public void MoveToTheCompareCarsPage()
        {
            compareCarsLink.Click();
        }
    }
}
