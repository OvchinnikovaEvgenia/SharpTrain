using CarsPageObject.Elements;
using CarsPageObject.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Pages
{
    internal class AllSpecificationsOfTheCar : BasePage
    {
        private Car car;
        private Label doorLabel = new Label(By.XPath("//div[contains(@class, 'key-spec')]//label[contains(text(), 'door')]"),
            "Door label");

        private Label seatsLabel = new Label(By.XPath("//div[contains(@class, 'key-spec')]//label[contains(text(), 'seats')]"),
            "Seats label");

        public AllSpecificationsOfTheCar(Car car) : base(new BaseElement(
            By.XPath($"//div[@class = 'research-trim-details']//h1[contains(text(), '{car.Year} {car.Make} {car.Model}')]"),
            "All details of the car label"), "All details of the car page")
        {
            this.car = car;
        }

        public void GetDoors() {
            car.Doors = int.Parse(doorLabel.GetText().Split("-")[0]);
        }
        public void GetSeats() {
            car.Seats = int.Parse(doorLabel.GetText().Split(" ")[0]);
        }

    }
}
