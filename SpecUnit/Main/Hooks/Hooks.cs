﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using SpecFlowProject.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{


    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private static string path = "C:\\Users\\user\\source\\repos2\\SpecSolution\\TestResults\\";
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public Hooks(FeatureContext _featureContext)
        {
            this.featureContext = _featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var htmlReporter = new ExtentHtmlReporter(path);

            //string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\extent";
            //ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
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
            DriverFactory driverFactory = new DriverFactory();
            _featureContext.Add(Global.Variables.driverIntance, driverFactory.getDriver());
        }

        [AfterFeature]
        public static void  AfterFeature(FeatureContext _featureContext)
        {
            Console.Write("Starting " + _featureContext.FeatureInfo.Title);
            _featureContext.Get<IWebDriver>(Global.Variables.driverIntance).Quit();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

            Console.Write("Im am Before Scenario");
            IWebDriver driver = featureContext.Get<IWebDriver>(Global.Variables.driverIntance);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(Global.Variables.baseURL);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.Write("Im am after Scenario");
            if (scenarioContext.TestError != null) {
                IWebDriver driver = featureContext.Get<IWebDriver>(Global.Variables.driverIntance);
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(path+"\\screenshot.png", ScreenshotImageFormat.Png);
                scenario.AddScreenCaptureFromPath("screenshot.png");
            }
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
           
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
            }
        }

    }
}
