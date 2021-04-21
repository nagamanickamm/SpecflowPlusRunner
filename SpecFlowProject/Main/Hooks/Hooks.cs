using System;
using OpenQA.Selenium;
using SpecFlowProject.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;

        public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.Write("Starting " + featureContext.FeatureInfo.Title);
            DriverFactory driverFactory = new DriverFactory();
            featureContext.Add(Global.Variables.driverIntance, driverFactory.getDriver());
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            Console.Write("Starting " + featureContext.FeatureInfo.Title);
            featureContext.Get<IWebDriver>(Global.Variables.driverIntance).Quit();
        }

        [BeforeScenario, Scope(Tag = "calc")]
        public void BeforeScenario()
        {
            Console.Write("Im am Before Scenario");
            IWebDriver driver = featureContext.Get<IWebDriver>(Global.Variables.driverIntance);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(Global.Variables.baseURL);
        }

        [AfterScenario, Scope(Tag = "specflow")]
        public void AfterScenario()
        {
            Console.Write("Im am after Scenario");
        }

    }
}
