using DatacomTest.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DatacomTest.Pages
{
    public class RegistrationPage : DriverHelper
    {
        IWebElement formRegistrationPage => Driver.FindElement(By.Id("account-creation_form"));
        IWebElement btnRegister => Driver.FindElement(By.Id("submitAccount"));
        IWebElement txtFirstName => Driver.FindElement(By.Id("customer_firstname"));
        IWebElement txtLastName => Driver.FindElement(By.Id("customer_lastname"));
        IWebElement txtPassword => Driver.FindElement(By.Id("passwd"));
        IWebElement txtAddress => Driver.FindElement(By.Id("address1"));
        IWebElement txtCity => Driver.FindElement(By.Id("city"));
        IWebElement txtPostCode => Driver.FindElement(By.Id("postcode"));
        IWebElement txtMobileNo => Driver.FindElement(By.Id("phone_mobile"));
        IWebElement dropState => Driver.FindElement(By.Id("id_state"));

        public Boolean IsRegitrationFormDisplayed()
        {
            return formRegistrationPage.Displayed;
        }
        public void ClickRegisterButton()
        {
            btnRegister.Click();
        }
        public void EnterUserDetails(string firstName, string lastName, string password,string address, string city, string postcode, string mobNo)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtPassword.SendKeys(password);
            txtAddress.SendKeys(address);
            txtCity.SendKeys(city);
            txtPostCode.SendKeys(postcode.Replace("\"", ""));
            txtMobileNo.SendKeys(mobNo.Replace("\"", ""));
        }
        public void SelectState(string stateName)
        {
            new SelectElement(dropState).SelectByText(stateName);
        }

    }
}
