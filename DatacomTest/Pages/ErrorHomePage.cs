using DatacomTest.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;

namespace DatacomTest.Pages
{
    public class ErrorHomePage : DriverHelper
    {
        IWebElement formloginPage => Driver.FindElement(By.Id("registerForm"));
        IWebElement btnsideBarCollapse => Driver.FindElement(By.Id("sidebarCollapse"));
        IWebElement txtFirstName => Driver.FindElement(By.Id("firstName"));
        IWebElement txtLastName => Driver.FindElement(By.Id("lastName"));
        IWebElement txtPhoneNo => Driver.FindElement(By.Id("phone"));
        IWebElement dropDownCountry => Driver.FindElement(By.Id("countries_dropdown_menu"));
        IWebElement txtEmailAddress => Driver.FindElement(By.Id("emailAddress"));
        IWebElement txtPassword => Driver.FindElement(By.Id("password"));
        IWebElement checkboxTermsAndConditions => Driver.FindElement(By.ClassName("form-check-input"));
        IWebElement btnRegister => Driver.FindElement(By.Id("registerBtn"));
        IWebElement successmessage => Driver.FindElement(By.XPath("//*[contains(text(), 'Successfully registered the following information')]"));
        IWebElement resultLName => Driver.FindElement(By.Id("resultLn"));
        IWebElement resultPhoneNo => Driver.FindElement(By.Id("resultPhone"));
        IWebElement errorMessage => Driver.FindElement(By.Id("message"));


        public Boolean IsErrorPageDisplayed()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            if (executor.ExecuteScript("return document.readyState").ToString().Equals("complete"))
            { 
                return formloginPage.Displayed; 
            }
            return false;
        }

        public void ClickSideBarCollapse()
        {
            btnsideBarCollapse.Click();
        }

        public void EnterUserDetails(string firstName, string lastName, string phoneNumber, string country, string emailAddress, string password)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtPhoneNo.SendKeys(phoneNumber.Replace("\"", ""));
            SelectElement SelectCountry = new SelectElement(dropDownCountry);
            SelectCountry.SelectByText(country);
            txtEmailAddress.SendKeys(emailAddress);
            txtPassword.SendKeys(password);
            checkboxTermsAndConditions.Click();
        }

        public void ClickRegisterButton()
        {
            btnRegister.Click();
        }
        
        public bool VerifyLastNameTrim()
        {
            bool isTrim = false;
            string passedLName = txtLastName.GetAttribute("value");
           string lNameresult = resultLName.Text.Substring(11);
            if((passedLName.Length - 1).Equals(lNameresult.Length) && passedLName.Contains(lNameresult))
            {
                isTrim = true;
            }
            else
            {
                //Do Nothing
            }
            return isTrim;
        }
        public bool VerifySuccessmessage(string msg)
        {
            bool isTrue = false;
            if (msg.Equals("Success"))
            {
                try
                {
                    isTrue = successmessage.Displayed;
                }
                catch
                {
                    isTrue = false;
                }
            }
            else
            {
                isTrue = false;
            }
            return isTrue;
        }
        public bool VerifyPhoneNumberIsAdded()
        {
            bool isTrim = false;
            string passedPhoneNumber = txtPhoneNo.GetAttribute("value");
            string phoneNumberResult = resultPhoneNo.Text.Substring(14);
            if ((Convert.ToInt64(passedPhoneNumber)+1).Equals(Convert.ToInt64(phoneNumberResult)))
            {
                isTrim = true;
            }
            else
            {
                //Do Nothing
            }
            return isTrim;
        }

        public bool VerifyLastNameIsNotBlank()
        {
            bool isTrim = false;
            string lastName = resultLName.Text.Substring(10);
            
            if (lastName.Length==0)
            {
                isTrim = true;
            }
            else
            {
                //Do Nothing
            }
            return isTrim;
        }

        public bool VerifyPasswordfield()
        {
            bool b;
            string passwordError = errorMessage.Text;
            if(txtPassword.GetAttribute("value").Length<6 || txtPassword.GetAttribute("value").Length >20)
            {
                passwordError.Equals("The password should contain between[6, 20] characters!");
                b = true;
            }
            else if (txtPassword.GetAttribute("value").Length >= 6 || txtPassword.GetAttribute("value").Length <= 20)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }

        public bool VerifyPhoneNumberfield()
        {
            string phoneNumberError = errorMessage.Text;
            bool b;
            if (txtPhoneNo.GetAttribute("value").Length < 10)
            {
                phoneNumberError.Equals("The phone number should contain at least 10 characters!");
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }
    }


}
