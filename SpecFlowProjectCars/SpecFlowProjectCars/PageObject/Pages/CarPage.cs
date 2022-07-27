using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;
using SpecFlowProjectCars.PageObject.Models;

namespace SpecFlowProjectCars.PageObject.Pages
{
    internal class CarPage: BasePage
    {
        private static BaseElement expectedCarLabel;
        private Link linkToCertainTrim;
        private Car car;

        public CarPage(Car car) : base(expectedCarLabel = new BaseElement(By.XPath(
            $"//div[@class = 'header-container']//h1[text() = '{car.Year} {car.Make} {car.Model}']"), "Car label"),
            $"{car.Make} {car.Model} {car.Year}")
        {
            this.car = car;
        }

        public bool IsCarPageDisplayed()
        {
            return expectedCarLabel.IsDisplayed();
        }
        public AllSpecificationsOfTheCar SelectTrim()
        {
            linkToCertainTrim = new Link(By.XPath($"//section[contains(@class, 'section trims')]//a[text() = '{car.Trim}']"),
                "Link to certain trim");
            linkToCertainTrim.Click();
            AllSpecificationsOfTheCar allSpecificationsOfTheCar = new AllSpecificationsOfTheCar(car);
            allSpecificationsOfTheCar.WaitForDisplayed();
            return allSpecificationsOfTheCar;
        }      
    }
}
