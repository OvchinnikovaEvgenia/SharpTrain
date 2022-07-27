using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Elements
{
    internal class Label : BaseElement
    {
        public Label(By locator, string name) : base(locator, name) { }
    }
}
