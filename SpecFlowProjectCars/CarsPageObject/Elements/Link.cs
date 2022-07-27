using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Elements
{
    internal class Link : BaseElement
    {
        public Link(By locator, string name) : base(locator, name) { }
    }

}
