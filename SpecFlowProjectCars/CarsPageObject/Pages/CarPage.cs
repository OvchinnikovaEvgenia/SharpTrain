using CarsPageObject.Elements;
using CarsPageObject.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Pages
{
    internal class CarPage: BasePage
    {
        private static BaseElement expectedCarLabel;
        private Button allSpecButton = new Button(By.XPath("//a[@data-linkname = 'research-mmy-specs']"), "All specifications");
        private Car car;

        public CarPage(Car car) : base(expectedCarLabel = new BaseElement(By.XPath(
            $"//div[@class = 'header-container']//h1[text() = '{car.Year} {car.Make} {car.Model}']"), "Car label"),
            $"{car.Make} {car.Model} {car.Year}")
        {
            this.car = car;
        }

        public bool IsCarPageDisplayed() {
            return expectedCarLabel.IsDisplayed();
        }

        public AllSpecificationsOfTheCar MoveToAllSpecificationsTab() {
            allSpecButton.Click();
            AllSpecificationsOfTheCar allSpecificationsOfTheCar = new AllSpecificationsOfTheCar(this.car);
            allSpecificationsOfTheCar.WaitForDisplayed();
            return allSpecificationsOfTheCar;
        }

       
    }
}
