using CarsPageObject.Pages.Forms;
using OpenQA.Selenium;
using SpecFlowProjectCars.PageObject.Elements;

namespace SpecFlowProjectCars.PageObject.Pages
{
    internal class ShoppingPage : BasePage
    {
        private static BaseElement baseElement = new BaseElement(By.XPath("//div[@class = 'home_page']"),
            "Shopping page base element");
        private Link findCarForSaleLink = new Link(
            By.XPath("//a[@data-linkname = 'shopping']"), "Link to cars for sale");

        public ShoppingPage() : base(baseElement, "Shopping page") 
        { }

        public GlobalHeaderForm SwitchToGlobalHeaderForm()
        {
            return new GlobalHeaderForm();
        }

        public void clickCarForSale()
        {
            findCarForSaleLink.Click(); 
        }
    }
}
