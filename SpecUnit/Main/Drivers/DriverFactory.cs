using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SpecFlowProject.Drivers
{
    class DriverFactory
    {

        private IWebDriver driverInstance;

        public DriverFactory()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new WebDriverManager.DriverConfigs.Impl.FirefoxConfig());
            driverInstance = new FirefoxDriver();
            driverInstance.Manage().Window.Maximize();
            driverInstance.Navigate().GoToUrl(Global.Variables.baseURL);
        }

        public IWebDriver getDriver()
        {
            return driverInstance;
        }
    }
}
