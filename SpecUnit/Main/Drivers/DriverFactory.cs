using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecUnit.Drivers
{
    public class DriverFactory
    {

        public IWebDriver driverInstance;

        public DriverFactory(string name = "Firefox")
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
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--headless");
                chromeOptions.AddArguments("--no-sandbox");
                chromeOptions.AddArguments("--disable-dev-shm-usage");
                driverInstance = new ChromeDriver(chromeOptions);
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
