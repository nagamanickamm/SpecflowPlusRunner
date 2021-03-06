using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecUnit.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = scenarioContext.Get<IWebDriver>(Global.Variables.driverIntance);
        }

        [Given("the first number is (.*)"), Scope(Tag = "calc")]
        public void GivenTheFirstNumberIs(int number)
        {
            driver.Navigate().GoToUrl("https://www.bbc.com");
            Console.Write("Given");
        }

        [Given("the first number is (.*)"), Scope(Tag = "specflow")]
        public void GivenTheFirstNumberIsG(int number)
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Console.Write("Given");
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {

            Console.Write("Given");
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {

            Console.Write("When");
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Console.Write("Then");
        }
    }
}
