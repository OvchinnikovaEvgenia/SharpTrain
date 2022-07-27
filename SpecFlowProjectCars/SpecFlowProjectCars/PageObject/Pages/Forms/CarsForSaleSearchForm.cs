using CarsPageObject.Pages.Forms;
using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;
using SpecFlowProjectCars.PageObject.Models;

namespace SpecFlowProjectCars.PageObject.Pages.Forms
{
    internal class CarsForSaleSearchForm: BaseForm
    {
        private ElementSelect usedSelect = new ElementSelect(
            By.XPath("//select[@id = 'make-model-search-stocktype']"), "Used select");

        private ElementSelect makesSelect = new ElementSelect(
           By.XPath("//select[@id = 'makes']"), "Makes select");

        private ElementSelect modelsSelect = new ElementSelect(
          By.XPath("//select[@id = 'models']"), "Models select");

        private ElementSelect priceSelect = new ElementSelect(
          By.XPath("//select[@id = 'make-model-max-price']"), "Price select");

        private ElementSelect distanceSelect = new ElementSelect(
          By.XPath("//select[@id = 'make-model-maximum-distance']"), "Distance select");

        private Label zipLabel = new Label(
            By.XPath("//input[@id = 'make-model-zip']"), "Zip label");

        private Button searchButton = new Button(
            By.XPath("//button[@type = 'submit' and contains(@data-linkname , 'search-used-make')]"), "Submit button");

        public CarsForSaleSearchForm() : base(new BaseElement(By.XPath(
            "//div[@class = 'sds-home-search']"), "Base element for search form"), "Search form")
        { }

        public void SearchCar(SearchCarForSaleModel searchCarForSaleModel)
        {
            usedSelect.SelectByText(searchCarForSaleModel.UseType);
            makesSelect.SelectByText(searchCarForSaleModel.Make);
            modelsSelect.SelectByText(searchCarForSaleModel.Model);
            priceSelect.SelectByText(searchCarForSaleModel.Price);
            distanceSelect.SelectByText(searchCarForSaleModel.Distance);
            zipLabel.SendKeys(searchCarForSaleModel.Zip);
            searchButton.Click();
        }
    }
}
