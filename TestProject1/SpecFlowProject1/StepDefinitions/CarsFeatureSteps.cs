using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class CarsFeatureSteps : IDisposable
    {
        private ChromeDriver chromeDriver;
        public CarsFeatureSteps() => chromeDriver = new ChromeDriver();

        public void Dispose() {
            if (chromeDriver != null) { 
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }

        [Given(@"I have to navigate to the cars website")]
        public void GivenIHaveToNavigateToTheCarsWebsite() {
            chromeDriver.Navigate().GoToUrl("http://www.cars.com");
        }
    }
}
