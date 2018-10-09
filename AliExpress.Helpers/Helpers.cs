using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace AliExpress.Helpers
{
    public class Helpers
    {

        private IWebDriver driver;
        private const string aliExpressURL = "https://www.aliexpress.com";
        private const string aliExpressLogin = "skaxrfdzeajgee2w@outlook.com";
        private const string aliExpressPassword = "qLEvZxcMVU9xqdQC";


        public IWebElement SignInButton => driver.FindElement(
            By.XPath("//div[@id='user-benefits']/div[@class='user-account']//span[@class='register-btn']/a[@data-role='sign-link']"));

        public IWebElement LoginField => driver.FindElement(By.Id("fm-login-id"));
        public IWebElement PasswordField => driver.FindElement(By.Id("fm-login-password"));
        public IWebElement LoginSubmitButton => driver.FindElement(By.Id("fm-login-submit"));

        // public IWebElement AdsCloseButton => driver.FindElement(By.XPath("//a[@data-role='layer-close']"));
        public IWebElement AdsCloseButton => driver.FindElement(By.XPath("/html/body/div[7]/div/div/a"));
        public IWebElement GoToGlobalSiteLink => driver.FindElement(By.LinkText("Go to Global Site (English)"));



        public Helpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToAliExpressHomepage()
        {
            driver.Navigate().GoToUrl(aliExpressURL);
        }

        public void LoginToAliExpress()
        {

            // TODO: try to set cookie
            // TODO: try to find those elements using class attribute

            // <a href="javascript:;" class="close-layer" data-role="layer-close">x</a>
            // <a data-role="goto-globalsite" class="link-goto-globalsite notranslate" rel="nofollow" href="http://www.aliexpress.com/">Go to Global Site (English)</a>
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(AdsCloseButton));
            Thread.Sleep(5000);

            AdsCloseButton.Click();
            GoToGlobalSiteLink.Click();
            SignInButton.Click();
            LoginField.SendKeys(aliExpressLogin);
            PasswordField.SendKeys(aliExpressPassword);
            LoginSubmitButton.Click();
        }
    }
}
