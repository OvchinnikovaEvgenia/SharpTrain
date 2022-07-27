using CarsPageObject.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsPageObject.Pages.Forms
{
    internal class BaseForm
    {
        private BaseElement baseElement { get; set; }
        private string formName { get; set; }
        public BaseForm(BaseElement baseElement, string formName)
        {
            this.baseElement = baseElement;
            this.formName = formName;
        }

        public void WaitForDisplayed()
        {
            baseElement.WaitForPresense();
        }
    }
}
