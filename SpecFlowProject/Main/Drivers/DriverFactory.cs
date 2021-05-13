using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject.Drivers
{
    public class DriverFactory
    {

        private readonly ScenarioContext _scenarioContext;

        public DriverFactory(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void CreateDriver(string name = "Firefox")
        {
            IWebDriver driverInstance;
            if (name == "Firefox")
            {
                _scenarioContext.Add(Global.Variables.driverManager, new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig()));
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArguments("-headless");
                driverInstance = new FirefoxDriver(firefoxOptions);
            }
            else
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), "89.0.4389.23");
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--headless");
                chromeOptions.AddArguments("--no-sandbox");
                chromeOptions.AddArguments("--disable-dev-shm-usage");
                driverInstance = new ChromeDriver(chromeOptions);
            }

            driverInstance.Manage().Window.Maximize();
            _scenarioContext.Add(Global.Variables.driverIntance, driverInstance);
        }

        public IWebDriver getDriver()
        {
            return _scenarioContext.Get<IWebDriver>(Global.Variables.driverIntance);
        }
    }
}
