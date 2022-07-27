using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;
using SpecFlowProjectCars.PageObject.Models;
using SpecFlowProjectCars.PageObject.Utils;

namespace SpecFlowProjectCars.PageObject.Pages
{
    internal class CompareCarsPage : BasePage
    {
        private static BaseElement baseElement = new BaseElement(By.XPath("//div[@class =  'comparison-container']"),
            "Base element for comparison page");
        private Link addCarLink = new Link(By.XPath("//div[contains(@class, 'comparison')]//a[@class = 'add-car']"),
            "Add car Link");
        private Button seeTheComparisonButton = new Button(
            By.XPath("//div[@class =  'comparison-container']//button[@phx-click = 'details']"), "See the comparison button");
        private TableRowElement doorsRow = new TableRowElement(
            By.XPath("//tr[contains(@class, 'door')]//following-sibling::tr[1]//td[contains(text(), ' ') ]"), "Doors row");
        private TableRowElement seatsRow = new TableRowElement(
           By.XPath("//tr[contains(@class, 'seats')]//following-sibling::tr[1]//td[contains(text() , ' ') ]"), "Seats row");
        public Link returnToCarPageLink;
        private Link firstCarDetails = new Link(
            By.XPath("(//div[contains(@class, 'mmy-info')]//a[@data-linkname= 'research-mmy'])[1]"), "Details of the first car");
        private Label firstCarTrim = new Label(
            By.XPath("(//div[contains(@class, 'mmy-info')]//div[@class = 'trim-text'])[1]"), "First car trim");
        private Link secondCarDetails = new Link(
           By.XPath("(//div[contains(@class, 'mmy-info')]//a[@data-linkname= 'research-mmy'])[2]"), "Details of the second car");
        private Label secondCarTrim = new Label(
            By.XPath("(//div[contains(@class, 'mmy-info')]//div[@class = 'trim-text'])[2]"), "Second car trim");
        public CompareCarsPage() : base(baseElement, "Comparison page") { }

        public void ClickAddCarToCompare() 
        {
            addCarLink.Click();
        }

        public void ClickSeeTheComparisonButton() 
        {
            seeTheComparisonButton.Click();
        }

        public void ReturnToTheCarPage(Car car)
        {
            returnToCarPageLink = new Link(
                By.XPath($"//div[@class = 'vehicle-cards']//a[text() = '{car.Year} {car.Make} {car.Model}']"),
                "Return to car page link");
            returnToCarPageLink.Click();
        }

        public Car GetFirstCarFromComparison()
        {
            string[] firstCarInfo = firstCarDetails.GetText().Split(" ");
            string trim = firstCarTrim.GetText();
            int seatsCount = seatsRow.NumbersFromRow()[0];
            int doorsCount = doorsRow.NumbersFromRow("-door")[0];
            return new Car(firstCarInfo[2], firstCarInfo[1], firstCarInfo[0], trim, seatsCount, doorsCount);
        }

        public Car GetSecondCarFromComparison()
        {
            string[] secondCarInfo = secondCarDetails.GetText().Split(" ");
            string trim = secondCarTrim.GetText();
            int seatsCount = seatsRow.NumbersFromRow()[1];
            int doorsCount = doorsRow.NumbersFromRow("-door")[1];
            return new Car(secondCarInfo[2], secondCarInfo[1], secondCarInfo[0], trim, seatsCount, doorsCount);
        }

        public bool IsCarEquals(Car expectedCar, Car currentCar) 
        {
            var comparer = new MyComparer();
            return comparer.Compare(expectedCar, currentCar, null);
        }
    }
}
