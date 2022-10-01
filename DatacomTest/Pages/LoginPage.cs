using DatacomTest.Drivers;
using OpenQA.Selenium;

namespace DatacomTest.Pages
{
    public class LoginPage : DriverHelper
    {
        IWebElement txtEmailID => Driver.FindElement(By.Id("email"));
        IWebElement txtPassword => Driver.FindElement(By.Id("passwd"));
        IWebElement btnSignIn => Driver.FindElement(By.Id("SubmitLogin"));
        IWebElement formloginPage => Driver.FindElement(By.Id("login_form"));
        IWebElement btnCreateAccount => Driver.FindElement(By.Id("SubmitCreate")); 
        IWebElement txtEmailCreateId => Driver.FindElement(By.Id("email_create"));

        public void EnterUserNameAndPasswrd(string userName, string password)
        {
            txtEmailID.SendKeys(userName);
            txtPassword.SendKeys(password);
        }
        public void ClickSignIn()
        {
            btnSignIn.Click();
        }
        public Boolean IsLoginFormDisplayed()
        {
            return formloginPage.Displayed;
        }
        public void ClickCreateAccount()
        {
            btnCreateAccount.Click();
        }
        public void EnterEmailId(string userName)
        {
            txtEmailCreateId.SendKeys(userName);
        }
    }
}
