using CarsPageObject.Elements;
using CarsPageObject.Pages.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Pages
{
    internal class ShoppingPage : BasePage
    {
        private static BaseElement baseElement = new BaseElement(By.XPath("//div[@class = 'shopping-page']"),
            "Shopping page base element");
        public ShoppingPage() : base(baseElement, "Shopping page") { }

        public GlobalHeaderForm SwitchToGlobalHeaderForm() {
            return new GlobalHeaderForm();
        }

    }
}
