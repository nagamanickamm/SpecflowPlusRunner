using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using SpecUnit.Drivers;
using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecUnit.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static string assemblyPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static string path = assemblyPath.Split("SpecflowPlusRunner")[0] + "SpecflowPlusRunner/TestResults/SpecRun/";


        public Hooks(FeatureContext _featureContext)
        {
            this.featureContext = _featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext _featureContext)
        {
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            Console.Write("Starting " + _featureContext.FeatureInfo.Title);
            //DriverFactory driverFactory = new DriverFactory();
            //_featureContext.Add(Global.Variables.driverIntance, driverFactory.getDriver());
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext _featureContext)
        {
            Console.Write("Starting " + _featureContext.FeatureInfo.Title);
            //_featureContext.Get<IWebDriver>(Global.Variables.driverIntance).Quit();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

            Console.Write("Im am Before Scenario");
            DriverFactory driverFactory = new DriverFactory();
            scenarioContext.Add(Global.Variables.driverIntance, driverFactory.getDriver());
            IWebDriver driver = driverFactory.getDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(Global.Variables.baseURL);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.Write("Im am after Scenario");
            IWebDriver driver = scenarioContext.Get<IWebDriver>(Global.Variables.driverIntance);
            if (scenarioContext.TestError != null)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(path + "\\screenshot.png", ScreenshotImageFormat.Png);
                scenario.AddScreenCaptureFromPath("screenshot.png");
            }
            driver.Quit();
        }

        //[AfterStep]
        //public void InsertReportingSteps(ScenarioStepContext scenarioStepContext)
        //{

        //    var stepType = scenarioStepContext.StepInfo.StepDefinitionType.ToString(); ;

        //    if (scenarioContext.TestError == null)
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "And")
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
        //    }
        //    else if (scenarioContext.TestError != null)
        //    {
        //        if (stepType == "Given")
        //        {
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
        //        }
        //        else if (stepType == "When")
        //        {
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
        //        }
        //        else if (stepType == "Then")
        //        {
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
        //        }
        //        else if (stepType == "And")
        //        {
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
        //        }
        //    }
        //}

    }
}
