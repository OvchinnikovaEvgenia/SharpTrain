using CarsPageObject.Elements;
using CarsPageObject.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Pages.Forms
{
    internal class FormToResearchCar: BaseForm
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

        public FormToResearchCar() : base(baseElement, "Form to research") { }

        public void SearchCar(Car car) {
            makeSelect.SelectByText(car.Make);
            modelSelect.SelectByText(car.Model);
            yearSelect.SelectByText(car.Year);  
        }

        public void ClickResearchButton() {
            researchButton.Click(baseElement);
        }
    }
}
