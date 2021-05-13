using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject.Main.DataClass;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Main.Pages.Home
{
    public sealed class HomePage : PageBase
    {
        private ScenarioContext _scenarioContext;
        public String pageTitle = "Playtech - the source of success";

        #region _______________________Constructor____________________________
        public HomePage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        #endregion

        #region _______________________Contents/WebElements____________________________

        //[FindsBy(How = How.CssSelector, Using = "#age-verification .modal.fade")]
        //private IWebElement AgeVerificationPopup;

        private By ageVerificationLocator = By.CssSelector("#age-verification .modal.fade");
        private IWebElement AgeVerificationPopup => WaitForElementDisplayed(ageVerificationLocator);
        private IWebElement AgeVerificationPopupHeading => Find(By.CssSelector("#age-verification div h3"));
        private IWebElement AgeVerificationContent1 => Find(By.CssSelector("#age-verification div p:nth-child(2)"));
        private IWebElement AgeVerificationContent2 => Find(By.CssSelector("#age-verification div p:nth-child(3)"));
        private IWebElement AgeVerificationPopupHeading2 => Find(By.CssSelector("#age-verification div h3:nth-child(4)"));
        private SelectElement DayDropDown => new(Find(By.Name("day")));
        private SelectElement MonthDropDown => new(Find(By.Name("month")));
        private SelectElement YearDropDown => new(Find(By.Name("year")));
        private IWebElement SubmitButton => Find(By.CssSelector(".btn.btn-default.submit"));
        private IWebElement AgeError => Find(By.ClassName("age-error"));
        private IWebElement HomePageBanner => WaitForElementDisplayed(By.Id("banner-slider-wrapper"));
        private IWebElement Menu => Find(By.Id("trigger"));
        private IWebElement AboutUs => Find(By.CssSelector("a[href=\"/about-us\"]"));
        #endregion

        #region _______________________Text Messsages/Errors____________________________

        private readonly string AgeRestriction_Content1 =
                "Playtech is a market leader in the gambling and financial trading industries. We are the world's largest online gambling software supplier offering cutting-edge, value added solutions to the industry's leading operators.";
        private readonly string AgeRestriction_Content2 =
                "Playtech is committed to responsibly communicating with our stakeholders. To enter this site, you must be old enough to access gambling products in your country.";
        #endregion

        #region _______________________Actions/Methods____________________________

        public void VerifyPageTitle()
        {
            WaitForTitleMatch(pageTitle);
        }

        public void VerifyAgeVerificationPopup(String alertHeading)
        {
            AgeVerificationPopup.Displayed.Should().Be(true);
            VerifyText(alertHeading, AgeVerificationPopupHeading).Should().Be(true);
        }

        public void VerifyAgeVerificationMessage(String alertMessage)
        {
            VerifyText(alertMessage, AgeVerificationPopupHeading2).Should().Be(true);
        }

        public void VerifyAlertContent(String messageProp)
        {
            VerifyText(AgeRestriction_Content1, AgeVerificationContent1).Should().Be(true);
        }

        public void VerifyAlertContent2(String messageProp)
        {
            VerifyText(AgeRestriction_Content2, AgeVerificationContent2).Should().Be(true);
        }

        public void SubmitYourDateOfBirth(DateOfBirth dob)
        {
            DayDropDown.SelectByText(dob.Day);
            MonthDropDown.SelectByText(dob.Month);
            YearDropDown.SelectByText(dob.Year);

            //Find(By.Name("day")).SendKeys(dob.Day);
            //Find(By.Name("month")).SendKeys(dob.Month);
            //Find(By.Name("year")).SendKeys(dob.Year);

            SubmitButton.Click();
        }

        public void CheckErrorMessage(String error)
        {
            VerifyText(error, AgeError).Should().Be(true);
        }

        public void VerifyUserEnteredHomepage()
        {
            WaitForElementDisappear(By.CssSelector("body.modal-open"));
            HomePageBanner.Displayed.Should().Be(true);
            WaitForElementDisappear(ageVerificationLocator).Should().Be(true);
            HomePageBanner.Displayed.Should().Be(true);
        }

        public void GotoAboutUsPage()
        {
            WaitForElementClickable(Menu);
            Menu.Click();
            AboutUs.Click();
        }

        #endregion
    }
}
