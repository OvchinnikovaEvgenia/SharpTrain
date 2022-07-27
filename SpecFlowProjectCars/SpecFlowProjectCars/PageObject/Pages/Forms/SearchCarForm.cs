using CarsPageObject.Pages.Forms;
using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;
using SpecFlowProjectCars.PageObject.Models;

namespace SpecFlowProjectCars.PageObject.Pages.Forms
{
    internal class SearchCarForm : BaseForm
    {
        private ElementSelect makeSelect = new ElementSelect(
            By.XPath("//select[contains(@id, 'selection_make')]"), "Make select");

        private ElementSelect modelSelect = new ElementSelect(
           By.XPath("//select[contains(@id, 'selection_model')]"), "Model select");

        private ElementSelect yearSelect = new ElementSelect(
          By.XPath("//select[contains(@id, 'selection_year')]"), "Year select");

        private ElementSelect trimSelect = new ElementSelect(
         By.XPath("//select[contains(@id, 'selection_trim')]"), "Trim select");

        private Button addToCompare = new Button(
            By.XPath("//button[@type = 'submit']"), "Add to compare button");
        public SearchCarForm() : base(
            new BaseElement(By.XPath("//div[contains(@id, 'comparison_builder')]//div[@class = 'sds-modal__content']"),
                "Base element for search car form"),
            "Search car form")
        { }

        public void addCarToComparison(Car car)
        {
            makeSelect.SelectByText(car.Make);
            modelSelect.SelectByText(car.Model);
            yearSelect.SelectByText(car.Year);
            trimSelect.SelectByParticalText(car.Trim);
            addToCompare.Click();
            this.WaitForUnpresense();
        }
    }
}
