using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProjectCars.PageObject.Elements
{
    internal class ElementSelect
    {
        private By locator;
        private String name;
        public ElementSelect(By locator, String name) 
        {
            this.locator = locator;
            this.name = name;
        }

        public void SelectByText(String text)
        {
            IWebElement elementSelect = Browsers.BrowserFactory.getDriver().FindElement(locator);
            SelectElement selectElement = new SelectElement(elementSelect);
            waitForOptions(selectElement);
            selectElement.SelectByText(text);
        }

        public void SelectByValue(string value)
        {
            IWebElement elementSelect = Browsers.BrowserFactory.getDriver().FindElement(locator);
            ConfigManager.GetWait().Until(ExpectedConditions.ElementToBeClickable(locator));
            SelectElement selectElement = new SelectElement(elementSelect);
            waitForOptions(selectElement);
            selectElement.SelectByValue(value);
        }

        public void SelectByIndex(int index) 
        {
            try
            {
                IWebElement elementSelect = Browsers.BrowserFactory.getDriver().FindElement(locator);
                SelectElement selectElement = new SelectElement(elementSelect);
                waitForOptions(selectElement);
                selectElement.SelectByIndex(index);
            }
            catch (IndexOutOfRangeException ex) {
                throw new Exception(ex.Message);
            }
        }

        public void waitForOptions(SelectElement selectElement)
        {
            ConfigManager.GetFluentWait().Until(
                web => selectElement.Options.Count >= 2);
        }

        public void SelectByParticalText(string text)
        {
            IWebElement elementSelect = Browsers.BrowserFactory.getDriver().FindElement(locator);
            SelectElement selectElement = new SelectElement(elementSelect);
            this.waitForOptions(selectElement);
            List<IWebElement> options = selectElement.Options.ToList();
            string expectedTrim = "";
            foreach (IWebElement option in options) {
                if (option.Text.Contains(text)) {
                    expectedTrim = option.Text;
                    break;
                }
            }
            selectElement.SelectByText(expectedTrim);
        }

        public void WaitUntilOptionIsSelected(string text)
        {
            IWebElement elementSelect = Browsers.BrowserFactory.getDriver().FindElement(locator);
            SelectElement selectElement = new SelectElement(elementSelect);
            this.waitForOptions(selectElement);
            List<IWebElement> options = selectElement.Options.ToList();
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals(text))
                {
                    ConfigManager.GetFluentWait().Until(
                        web => option.Selected);
                    break;
                }
            }
        }

        public bool IsSelectExist() 
        {
            List<IWebElement> elements = Browsers.BrowserFactory.getDriver().FindElements(this.locator).ToList();
            return elements.Count > 0;
        }

        public bool IsElementExistInSelect(string text)
        {
            IWebElement elementSelect = Browsers.BrowserFactory.getDriver().FindElement(locator);
            SelectElement selectElement = new SelectElement(elementSelect);
            this.waitForOptions(selectElement);
            List<IWebElement> options = selectElement.Options.ToList();
            foreach (IWebElement option in options) {
                if (option.Text.Equals(text)) {
                    return true;
                }
            }
            return false;
        }
    }
}
