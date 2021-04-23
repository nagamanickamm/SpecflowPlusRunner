using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject.Drivers
{
    public class DriverFactory
    {

        public IWebDriver driverInstance;

        public DriverFactory(string name="Firefox")
        {
            if (name == "Firefox")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArguments("-headless");
                driverInstance = new FirefoxDriver(firefoxOptions);
            }
            else
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), "89.0.4389.23");
                driverInstance = new ChromeDriver();
            }

            driverInstance.Manage().Window.Maximize();
            driverInstance.Navigate().GoToUrl(Global.Variables.baseURL);
        }

        public IWebDriver getDriver()
        {
            return driverInstance;
        }
    }
}
