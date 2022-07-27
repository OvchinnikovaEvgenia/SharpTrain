using NUnit.Framework;
using SpecFlowProjectCars.PageObject;
using SpecFlowProjectCars.PageObject.Browsers;
using SpecFlowProjectCars.PageObject.Models;
using SpecFlowProjectCars.PageObject.Pages;
using SpecFlowProjectCars.PageObject.Pages.Forms;
using SpecFlowProjectCars.PageObject.Utils;
using TechTalk.SpecFlow;

namespace SpecFlowProjectCars.StepDefinitions
{
    [Binding]
    public sealed class CarsSteps
    {
        private ShoppingPage shoppingPage;
        private PageToResearchCar formToResearchCar;
        private CompareCarsPage compareCarsPage;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            BrowserFactory.getDriver().Manage().Window.Maximize();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            BrowserFactory.getDriver().Close();
        }

        [Given(@"navigate to cars page")]
        public void GivenNavigateToCarsPage()
        {
            BrowserFactory.getDriver().Url = Consts.URL;
            shoppingPage = new ShoppingPage();
            shoppingPage.WaitForDisplayed();
            Assert.IsTrue(shoppingPage.IsDisplayed());
       
        }

        [When(@"go to the research page")]
        public void WhenGoToTheResearchPage()
        {
            shoppingPage.SwitchToGlobalHeaderForm().ClickOnResearchButton();
            formToResearchCar = new PageToResearchCar();
            formToResearchCar.WaitForDisplayed();
            Assert.IsTrue(formToResearchCar.IsDisplayed());
        }

        [When("search (.*) and (.*) and (.*) and (.*)")]
        public void WhenSearchAndAnd(string make, string model, string year, string trim)
        {
            Car car = new Car(model, make, year, trim);
            ScenarioContext.Current[make] = car;
            formToResearchCar.SearchCar(car);
        }

        [When("move to (.*) trim page")]
        public void WhenMoveToTrimPage(string make)
        {
            formToResearchCar.ClickResearchButton();
            CarPage carPage = new CarPage((Car)ScenarioContext.Current[make]);
            carPage.WaitForDisplayed();
            Assert.IsTrue(carPage.IsDisplayed());
            ScenarioContext.Current[$"{make}Spec"] = carPage.SelectTrim();
        }

        [When("remembering characteristics seats and doors for (.*)")]
        public void WhenRememberingCharacteristicsSeatsAndDoorsFor(string make)
        {
            AllSpecificationsOfTheCar specTab = (AllSpecificationsOfTheCar)ScenarioContext.Current[$"{make}Spec"];
            specTab.WaitForDisplayed();
            Assert.IsTrue(specTab.IsDisplayed());
            specTab.GetDoors();
            specTab.GetSeats();
        }

        [When(@"switch to the Compare cars page")]
        public void WhenSwitchToTheCompareCarsPage()
        {
            formToResearchCar.MoveToTheCompareCarsPage();
        }

        [When(@"click add car button")]
        public void WhenClickAddCarButton()
        {
            compareCarsPage = new CompareCarsPage();
            compareCarsPage.ClickAddCarToCompare();
        }

        [When("add (.*) car")]
        public void WhenAddCar(string carMake)
        {
            SearchCarForm searchCarForm = new SearchCarForm();
            searchCarForm.WaitForDisplayed();
            searchCarForm.addCarToComparison((Car)ScenarioContext.Current[carMake]);
        }

        [When(@"click see the comparison button")]
        public void WhenClickSeeTheComparisonButton()
        {
            compareCarsPage.ClickSeeTheComparisonButton();
        }

        [Then("the expected characteristics (.*) and (.*)")]
        public void ThenTheExpectedCharacteristicsBMWAndVolkswagen(string firstCarMake, string secondCarMake)
        {
            Car firstCar = (Car)ScenarioContext.Current[firstCarMake];
            Car secondCar = (Car)ScenarioContext.Current[secondCarMake];
            Assert.IsTrue(compareCarsPage.IsCarEquals(firstCar, compareCarsPage.GetFirstCarFromComparison()));
            Assert.IsTrue(compareCarsPage.IsCarEquals(secondCar, compareCarsPage.GetSecondCarFromComparison()));
        }

        [When("move to the (.*) page")]
        public void WhenToThePage(string make)
        {
            Car car = (Car)ScenarioContext.Current[make];
            compareCarsPage.ReturnToTheCarPage(car);
            CarPage carPage = new CarPage(car);
            carPage.WaitForDisplayed();
            Assert.IsTrue(carPage.IsDisplayed());
            AllSpecificationsOfTheCar specTab = carPage.SelectTrim();
            Assert.True(specTab.IsDataAsExpected());
            ScenarioContext.Current[$"{make}Spec"] = specTab;
        }

        [When("save (.*) price")]
        public void WhenSavePrice(string make)
        {
            AllSpecificationsOfTheCar specTab = (AllSpecificationsOfTheCar)ScenarioContext.Current[$"{make}Spec"];
            specTab.GetPrice(); 
        }

        [Given(@"go to car for sale tab")]
        public void GivenGoToCarForSaleTab()
        {
            shoppingPage.clickCarForSale();
        }

        [Given("search (.*) car")]
        public void GivenSearchHondaCar(string make)
        {
            CarsForSaleSearchForm carsForSaleSearchForm = new CarsForSaleSearchForm();
            SearchCarForSaleModel  searchCarForSaleModel = JsonUtils.DeserializeJson(
                $"{Directory.GetCurrentDirectory()}{"\\Support\\DataToSearch.json"}");
            Car car = (Car)ScenarioContext.Current[make];
            searchCarForSaleModel.Make = car.Make;
            searchCarForSaleModel.Model = car.Model;
            carsForSaleSearchForm.SearchCar(searchCarForSaleModel);
            SearchedCarsPage searchedCarsPage = new SearchedCarsPage();
            Assert.IsTrue(searchedCarsPage.IsOneCarExist());
        }

        [Given("add trim and year parameter for (.*) car")]
        public void GivenAddTrimAndYearParameterForHondaCar(string make)
        {
            SearchedCarsPage searchedCarsPage = new SearchedCarsPage();
            Car car = (Car)ScenarioContext.Current[make];
            Assert.IsTrue(searchedCarsPage.TrySelectTrim(car), "There are no cars with this trim");
            Assert.IsTrue(searchedCarsPage.TrySelectYear(car), "There are no cars with this year");
            Assert.IsTrue(searchedCarsPage.IsOneCarExist(), "No one car exist with this parameters");
        }

        [Then("new (.*) price higher then used car")]
        public void ThenNewHondaPriceHigherThenUsedCar(string make)
        {
            Car car = (Car)ScenarioContext.Current[make];
            SearchedCarsPage searchedCarsPage = new SearchedCarsPage();
            double usedCarPrice = searchedCarsPage.GetPriceOfTheFirstCar();
            Assert.IsTrue(car.IsCarPriceHigher(usedCarPrice));
        }
    }
}