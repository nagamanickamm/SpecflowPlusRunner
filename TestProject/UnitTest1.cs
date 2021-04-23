using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestMethod1()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("--headless");
            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Quit();
        }
        [Test]
        public void TestMethod2()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("--headless");
            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Quit();
        }

    }
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void TestMethod2()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("--headless");
            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Quit();
        }
        [Test]
        public void TestMethod1()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("--headless");
            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Quit();
        }
    }
}
