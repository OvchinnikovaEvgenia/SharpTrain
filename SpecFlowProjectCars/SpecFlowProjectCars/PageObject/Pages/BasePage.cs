using SpecFlowProjectCars.PageObject.Elements;

namespace SpecFlowProjectCars.PageObject.Pages
{
    internal class BasePage
    {
        public BaseElement baseElement { get; set; }
        public string pageName { get; set; }
        public BasePage(BaseElement baseElement, string pageName) { 
            this.baseElement = baseElement;
            this.pageName = pageName;
        }

        public void WaitForDisplayed()
        {
            baseElement.WaitForPresense();
        }

        public bool IsDisplayed()
        { 
            return baseElement.IsDisplayed();
        }
    }
}
