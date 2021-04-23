using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject
{
    public class baseClass
    {
        IWebDriver driver;

        public IWebDriver getDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("--headless");
            driver = new FirefoxDriver(firefoxOptions);
            return driver;
        }
    }

    [TestFixture]
    public class UnitTest:baseClass
    {
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = getDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Quit();
        }
        [Test]
        public void TestMethod2()
        {
            IWebDriver driver = getDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Quit();
        }

    }
    [TestFixture]
    public class UnitTest2:baseClass
    {
        [Test]
        public void TestMethod2()
        {
            IWebDriver driver = getDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Quit();
        }
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = getDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Quit();
        }
    }
}
