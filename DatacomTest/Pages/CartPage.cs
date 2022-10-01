using DatacomTest.Drivers;
using OpenQA.Selenium;

namespace DatacomTest.Pages
{
    public class CartPage : DriverHelper
    {
        IWebElement txtTotal => Driver.FindElement(By.XPath("//td[@id='total_product']"));

        public string TotalCartValue()
        {
            return txtTotal.Text.Replace("$","");
        }

    }
}
