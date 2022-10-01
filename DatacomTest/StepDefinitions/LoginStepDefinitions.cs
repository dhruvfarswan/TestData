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
        ArrayList pricelist = new ArrayList();
        HomePage homePage = new HomePage();
        LoginPage loginPage = new LoginPage();
        RegistrationPage registrationPage = new RegistrationPage(); 
        CartPage cartPage = new CartPage();
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

        [When(@"I click on login button")]
        public void GivenIClickOnLoginButton()
        {
            homePage.ClickSignIn();
        }

        [Then(@"Login page should be displayed")]
        public void ThenLoginPageShouldBeDisplayed()
        {
            Assert.IsTrue(loginPage.IsLoginFormDisplayed());                   
        }

        [When(@"I enter username and password as (.*) and (.*)")]
        public void WhenIEnterUsernameAndPasswordAsTestuserautoGmail_ComAndQssCD(string username, string pwd)
        {
            loginPage.EnterUserNameAndPasswrd(username, pwd);
            loginPage.ClickSignIn();
            Thread.Sleep(2000);
        }

        [When(@"I enter Email address and click on create account")]
        public void WhenIEnterEmailAddressAndClickOnCreateAccount()
        {
            string emailIdRand= Guid.NewGuid().ToString("n").Substring(0, 4);
            string emailId = "test" + emailIdRand + "@gmail.com";
            loginPage.EnterEmailId(emailId);
            loginPage.ClickCreateAccount();
            Thread.Sleep(5000);
        }

        [Then(@"Create an account page is displayed")]
        public void ThenCreateAnAccountPageIsDisplayed()
        {
            Assert.IsTrue(registrationPage.IsRegitrationFormDisplayed());
        }

        [Then(@"I Enter all the below required details")]
        public void ThenIEnterAllTheBelowRequiredDetails(Table table)
        {
            IEnumerable<dynamic> reqdetails = table.CreateDynamicSet();            
            foreach (var users in reqdetails)
            {
                registrationPage.EnterUserDetails(users.FirstName, users.LastName, users.Password, users.Address, users.City, users.ZipCode, users.MobileNo);      
                registrationPage.SelectState(users.State);
            }
        }

        [Then(@"I click on Register button")]
        public void ThenIClickOnRegisterButton()
        {
            registrationPage.ClickRegisterButton();
            Thread.Sleep(3000);
        }

        [When(@"I click on Add to Cart for (.*) product")]
        public void WhenIClickOnAddToCartForStProduct(int n)
        {
            pricelist.Add(homePage.GetProductPrice(n));
            homePage.SelectAddToCartForProducts(n);
            Thread.Sleep(3000);
        }

        [When(@"I click on Continue Shopping button")]
        public void WhenIClickOnContinueShoppingButton()
        {
            homePage.ClickContinueButton();
            Thread.Sleep(2000);
        }

        [Then(@"I verify the total price of the products in the cart is correct or not")]
        public void ThenIVerifyThePriceOfTheProductsInTheCartIsCorrectOrNot()
        {
            homePage.ClickShoppingCartButton();
            Thread.Sleep(2000);
            string cartValue = cartPage.TotalCartValue();
            var firstElement = float.Parse((string)pricelist[0]);
            var secondElement = float.Parse((string)pricelist[1]);
            var var1 = (firstElement + secondElement).ToString("F2");
            Assert.AreEqual(cartValue, var1);
        }
    }
}
