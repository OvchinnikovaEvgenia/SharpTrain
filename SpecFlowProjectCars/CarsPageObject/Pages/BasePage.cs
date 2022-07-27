using CarsPageObject.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Pages
{
    internal class BasePage
    {
        private BaseElement baseElement { get; set; }
        private string pageName { get; set; }
        public BasePage(BaseElement baseElement, string pageName) { 
            this.baseElement = baseElement;
            this.pageName = pageName;
        }

        public void WaitForDisplayed() {
            baseElement.WaitForPresense();
        }
    }
}
