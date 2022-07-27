using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Elements
{
    internal interface IBaseElement
    {
        private By locator { get => locator; set { locator = value; } }
        private string name { get => name; set { name = name; } }

        public bool IsDisplayed();

        public void WaitForPresense();

        public IWebElement FindChildElement(By childLocator);

    }
}
