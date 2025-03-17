using DatacomTest.Drivers;
using DatacomTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;
using TechTalk.SpecFlow.Assist;

namespace DatacomTest.StepDefinitions
{
    [Binding]
    public class GetScenarioContext : DriverHelper
    {
        IWebDriver Driver;
        ErrorHomePage errorPage = new ErrorHomePage();
        private readonly ScenarioContext _scenarioContext;

        public GetScenarioContext(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to the homepage with the below envrionment")]
        public void GivenINavigateToTheAutomationpracticeHomepageWithTheBelowEnvrionment(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            Driver = _scenarioContext.Get<DriverHelper>("DriverHelper").Setup(data.BrowserName);
            Driver.Url = data.Url;
        }

        [Then(@"Error Home page should be displayed")]
        public void ThenErrorHomePageShouldBeDisplayed()
        {
            Thread.Sleep(1000);
            Assert.That(errorPage.IsErrorPageDisplayed());
            errorPage.ClickSideBarCollapse();
            Thread.Sleep(1000);
        }

    
        [Then(@"I Enter all the form details")]
        public void ThenIEnterAllTheFormDetails(Table table)
        {
            IEnumerable<dynamic> reqdetails = table.CreateDynamicSet();
            foreach (var users in reqdetails)
            {
                errorPage.EnterUserDetails(users.FirstName, users.LastName, users.PhoneNumber, users.Country, users.EmailAddress, users.Password);
            }
        }

        [Then(@"I click on Register button on Error Page")]
        public void ThenIClickOnRegisterButtonOnErrorPage()
        {
            errorPage.ClickRegisterButton();
            Thread.Sleep(1000);
        }

        [Then(@"Verify Last Name is trimmed")]
        public void ThenVerifyLastNameIsTrimmed()
        {
            if (errorPage.VerifyLastNameTrim() == true)
            {
                Assert.Fail("The last character is trimmed from LastName after registration");
            }
            Thread.Sleep(1000);
        }
        [Then(@"I verify the (.*) message")]
        public void ThenIVerifyTheSuccessOrFailureMessage(string message)
        {
            Assert.That(errorPage.VerifySuccessmessage(message),"There was an error while doing the registration");
            Thread.Sleep(1000);
        }

        [Then(@"Verify Phone Number is incremented by one")]
        public void ThenVerifyPhoneNumberIsAdded()
        {
            if (errorPage.VerifyPhoneNumberIsAdded() == true)
            {
                Assert.Fail("The phone number in the result is one greater than the actual phone number after registration");
            }
            Thread.Sleep(1000);
        }

        [Then(@"Verify Last Name field is not blank")]
        public void ThenVerifyLastNameIsNotBlank()
        {
            if (errorPage.VerifyLastNameIsNotBlank() == true)
            {
                Assert.Fail("The Last Name is blank after registration and it is a required field");
            }
            Thread.Sleep(1000);
        }

        [Then(@"Verify Password length field is between six and twenty characters")]
        public void ThenVerifyPasswordField()
        {
            if (errorPage.VerifyPasswordfield() == true)
            {
                Assert.Pass("The Password length field is not between six and twenty characters message is displayed");
            }
            else
            {
                Assert.Fail("The Password length field between six and twenty characters but there is an error");
            }
            Thread.Sleep(1000);
        }

        [Then(@"Verify Phone Number field length is atleast ten characters")]
        public void ThenVerifyPhoneNumberField()
        {
            if (errorPage.VerifyPhoneNumberfield() == true)
            {
                Assert.Pass("The Phone Number field length is atleast ten characters message is dispalyed");
            }
            else
            {
                Assert.Fail("The Phone Number field length is atleast ten characters message is not being dispalyed");
            }
            Thread.Sleep(1000);
        }

    }
}
