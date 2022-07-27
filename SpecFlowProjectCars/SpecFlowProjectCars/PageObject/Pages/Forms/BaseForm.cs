using SpecFlowProjectCars.PageObject;
using SpecFlowProjectCars.PageObject.Elements;

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

        public bool IsDisplayed()
        {
            return baseElement.IsDisplayed();
        }

        public void WaitForUnpresense() 
        {
            ConfigManager.GetFluentWait().Until(webDriver => !baseElement.IsDisplayed());
        }       
    }
}
