using OpenQA.Selenium;
using SpecFlowProject.Main.DataClass;
using SpecFlowProject.Main.Pages.Home;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.Test.Steps
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _ScenarioContext;
        private readonly IWebDriver Driver;
        private HomePage homePage;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _ScenarioContext = scenarioContext;
            Driver = scenarioContext.Get<IWebDriver>(Global.Variables.driverIntance);
            homePage = new HomePage(scenarioContext);
        }

        [Given(@"Im on Playtech homepage")]
        public void GivenImOnPlaytechHomepage()
        {
            homePage.VerifyPageTitle();
        }

        [When(@"I see Age Verification Alert with heading as ""(.*)""")]
        public void WhenISeeAgeVerificationAlertWithHeadingAs(string heading)
        {
            homePage.VerifyAgeVerificationPopup(heading);
        }

        [When(@"I see message on the Alert ""(.*)""")]
        public void WhenISeeMessageOnTheAlert(string message)
        {
            homePage.VerifyAgeVerificationMessage(message);
        }

        [When(@"I see content on the Alert ""(.*)""")]
        public void WhenISeeContentOnTheAlert(string content)
        {
            homePage.VerifyAlertContent(content);
        }

        [When(@"I see responsible Gambling message on the Alert ""(.*)""")]
        public void WhenISeeResponsibleGamblingMessageOnTheAlert(string content)
        {
            homePage.VerifyAlertContent2(content);
        }

        [When(@"I enter my age and submit")]
        public void WhenIEnterMyAgeAndSubmit(Table table)
        {
            //For list use  === string[] results = table.Rows.Select(r => r[0]).ToArray();
            DateOfBirth dob = table.CreateInstance<DateOfBirth>();
            homePage.SubmitYourDateOfBirth(dob);
        }

        [Then(@"I see the error message ""(.*)""")]
        public void ThenISeeTheErrorMessage(string error)
        {
            homePage.CheckErrorMessage(error);
        }

        [Then(@"I can enter into the homepage now")]
        public void ThenICanEnterIntoTheHomepageNow()
        {
            homePage.VerifyUserEnteredHomepage();
        }
    }
}
