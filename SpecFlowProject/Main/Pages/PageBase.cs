using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Main.Pages
{
    public class PageBase
    {
        private WebDriverWait Wait;
        private DefaultWait<IWebDriver> FluentWait;
        private IJavaScriptExecutor JsExecutor;
        public IWebDriver Driver;
        private ScenarioContext _scenarioContext;

        public PageBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Driver = scenarioContext.Get<IWebDriver>(Global.Variables.driverIntance);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            FluentWait = new DefaultWait<IWebDriver>(Driver);
            FluentWait.Timeout = TimeSpan.FromSeconds(5);
            FluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            FluentWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            FluentWait.Message = "Element to be searched not found";

            JsExecutor = (IJavaScriptExecutor)Driver;
        }
        public void WaitForTitleMatch(String title)
        {
            //FluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(title.ToLower()));
            //browser => browser.Title.ToLower().Equals(title.ToLower()));
        }

        public IWebElement Find(By locator) => Driver.FindElement(locator);

        public IWebElement WaitForElementDisplayed(By locator) => FluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
 

        public bool WaitForElementDisappear(By locator) => FluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));

        public IWebElement WaitForElementClickable(IWebElement element)
        {
            return FluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void JsClick(By locator)
        {
            JsExecutor.ExecuteScript("arguments[0].click();", locator);
        }

        public void JsScroll(IWebElement element)
        {
            JsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            WaitForElementClickable(element);
        }

        public bool VerifyText(String expectedText, IWebElement locator)
        {
            return FluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(locator, expectedText));
        }

        public void AnimationsReady()
        {
            JsExecutor.ExecuteScript("return $(\"animated\").length.toString()").ToString().Should().Be("0");
        }
    }
}




