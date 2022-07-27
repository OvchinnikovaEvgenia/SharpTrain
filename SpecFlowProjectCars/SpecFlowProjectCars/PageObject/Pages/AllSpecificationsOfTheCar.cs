using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;
using SpecFlowProjectCars.PageObject.Models;

namespace SpecFlowProjectCars.PageObject.Pages
{
    internal class AllSpecificationsOfTheCar : BasePage
    {
        private Car car;
        private Label doorLabel = new Label(By.XPath("//div[contains(@class, 'key-spec')]//label[contains(text(), 'door')]"),
            "Door label");

        private Label seatsLabel = new Label(By.XPath("//div[contains(@class, 'key-spec')]//label[contains(text(), 'seats')]"),
            "Seats label");

        private Label priceLabel = new Label(By.XPath("//div[@class = 'price-amount']"),
            "Label with price");

        public AllSpecificationsOfTheCar(Car car) : base(new BaseElement(
            By.XPath($"//div[@class = 'research-trim-details']//h1[contains(text(), '{car.Year} {car.Make} {car.Model}')]"),
            "All details of the car label"), "All details of the car page")
        {
            this.car = car;
        }

        public void GetDoors()
        {
            car.Doors = int.Parse(doorLabel.GetText().Split("-")[0]);
        }
        public void GetSeats()
        {
            car.Seats = int.Parse(seatsLabel.GetText().Split(" ")[0]);
        }

        public bool IsDataAsExpected()
        {
            return car.Doors.Equals(int.Parse(doorLabel.GetText().Split("-")[0]))
                && car.Seats.Equals(int.Parse(seatsLabel.GetText().Split(" ")[0]));
        }   
        
        public void GetPrice()
        {
            car.Price = priceLabel.GetText();
        }
    }
}
