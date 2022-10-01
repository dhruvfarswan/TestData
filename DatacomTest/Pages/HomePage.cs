using DatacomTest.Drivers;
using OpenQA.Selenium;

namespace DatacomTest.Pages
{
    public class HomePage : DriverHelper
    {
        IWebElement lnkSignIn => Driver.FindElement(By.ClassName("login"));
        IList<IWebElement> listAddtoCart => Driver.FindElements(By.XPath("//a[@class='product_img_link']//following::div[@class ='button-container']/a[@title='Add to cart']"));
        List<IWebElement> products = new List<IWebElement>();
        IWebElement btnConitune => Driver.FindElement(By.XPath("//span[@title='Continue shopping']"));
        IList<IWebElement> listPriceOfProducts => Driver.FindElements(By.XPath("//h5[@itemprop='name']/following-sibling::div[@class ='content_price']/span[@class='price product-price']"));
        List<IWebElement> productPrice = new List<IWebElement>();
        public void ClickSignIn() => lnkSignIn.Click();
        IWebElement btnShoppingCart => Driver.FindElement(By.XPath("//a[@title='View my shopping cart']"));

        public void SelectAddToCartForProducts(int n)
        {
            foreach (IWebElement element in listAddtoCart)
            {
                products.Add(element);
            }
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", products[n]);
        }
        public string GetProductPrice(int n)
        {
            foreach (IWebElement element in listPriceOfProducts)
            {
                productPrice.Add(element);
            }
            return productPrice[n].Text.Replace("$","");
        }
        public void ClickContinueButton() => btnConitune.Click();
        public void ClickShoppingCartButton() => btnShoppingCart.Click();
    }

    

}
