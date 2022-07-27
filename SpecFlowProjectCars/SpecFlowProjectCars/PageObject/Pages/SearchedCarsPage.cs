using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;
using SpecFlowProjectCars.PageObject.Models;

namespace SpecFlowProjectCars.PageObject.Pages
{
    internal class SearchedCarsPage: BasePage 
    {
        private Label carCardPrice = new Label(By.XPath("//div[contains(@class, 'vehicle-card ')]//span[@class = 'primary-price']"), "Car card price");
        private Input trimInput;
        private Label trimLabel;
        private ElementSelect minYear = new ElementSelect(
            By.XPath("//select[@id = 'year_year_min_select']"), "Min year select");
        private ElementSelect maxYear = new ElementSelect(
            By.XPath("//select[@id = 'year_year_max_select']"), "Max year select");

        public SearchedCarsPage() : base(new BaseElement(
            By.XPath("//div[@class = 'vehicle-cards']"), "Cars cards container"), "Serched cars page")
        { }

        public bool IsOneCarExist()
        {
            carCardPrice.WaitForPresense();
            return carCardPrice.FindElements().Count() >= 1;
        }

        public bool TrySelectTrim(Car car)
        {
           trimInput = new Input(
                By.XPath($"//div[@id = 'trim']//input[@value = '{car.Make.ToLower()}-{car.Model.ToLower()}-{car.Trim.ToLower()}']"),
                "Input to select trim");
            trimLabel = new Label(
                By.XPath($"//div[@id = 'trim']//input[@value = '{car.Make.ToLower()}-{car.Model.ToLower()}-{car.Trim.ToLower()}']//following-sibling::label"),
                "Trim label");
            if (trimInput.IsElementExist() 
                && trimLabel.IsElementExist()) {
                trimLabel.Click();
                trimInput.WaitForSelected();
                return true;
            }
            return false;
        }

        public bool TrySelectYear(Car car)
        {
            if (minYear.IsSelectExist()
                && maxYear.IsSelectExist()
                && minYear.IsElementExistInSelect(car.Year)
                && maxYear.IsElementExistInSelect(car.Year)) {
                    minYear.SelectByValue(car.Year);
                    minYear.WaitUntilOptionIsSelected(car.Year);
                    maxYear.SelectByText(car.Year);
                    maxYear.WaitUntilOptionIsSelected(car.Year);
                    return true;
            }
            return false;
        }
        public double GetPriceOfTheFirstCar()
        {
            return double.Parse(carCardPrice.FindElements()[0].Text.Trim('$'));
        }
    }
}
