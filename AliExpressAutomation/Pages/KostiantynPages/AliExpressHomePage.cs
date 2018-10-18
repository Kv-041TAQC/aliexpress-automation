using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using AliExpress.Helpers;


namespace AliExpress.Pages
{
    public class AliExpressHomePage
    {

        #region Fields and Constants

        private IWebDriver driver;
        private const string aliExpressURL = "https://www.aliexpress.com";
        private const string aliExpressLogin = "skaxrfdzeajgee2w@outlook.com";
        private const string aliExpressPassword = "qLEvZxcMVU9xqdQC";

        private const string aliExpressLoginFormId = "alibaba-login-box";

        #endregion

        #region Page Element Locators  
        public IWebElement GoToGlobalSiteLink => driver.FindElement(By.LinkText("Go to Global Site (English)"));
        public IWebElement SignInButton => driver.FindElement(
            By.XPath("//div[@id='user-benefits']/div[@class='user-account']//span[@class='register-btn']/a[@data-role='sign-link']"));
        public IWebElement AliExpressLoginForm => driver.FindElement(By.Id(aliExpressLoginFormId));
        public IWebElement LoginField => driver.FindElement(By.Id("fm-login-id"));
        public IWebElement PasswordField => driver.FindElement(By.Id("fm-login-password"));
        public IWebElement LoginSubmitButton => driver.FindElement(By.Id("fm-login-submit"));

        public IWebElement AdsCloseButton => driver.FindElement(By.XPath("//a[@data-role='layer-close']"));

        

        public IWebElement MyOrdersLink => driver.FindElements(By.XPath("//a[contains(@href, 'orderList.htm')]"))[1];

        #endregion

        #region Constructors
        public AliExpressHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Methods
        public void NavigateToAliExpressHomepage()
        {
            driver.Navigate().GoToUrl(aliExpressURL);
        }


        public void LoginToAliExpress()
        {

            try
            {
                WaitUtilities.WaitForElement(driver, AdsCloseButton, 15);
                AdsCloseButton.Click();

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: There was no ad: " + e.Message);
            }

            WaitUtilities.WaitForElement(driver, GoToGlobalSiteLink, 15);
            GoToGlobalSiteLink.Click();
            WaitUtilities.WaitForElement(driver, SignInButton, 15);
            SignInButton.Click();
            WaitUtilities.WaitForElement(driver, AliExpressLoginForm, 15);
            driver.SwitchTo().Frame(AliExpressLoginForm);
            WaitUtilities.WaitForElement(driver, LoginField, 15);
            LoginField.SendKeys(aliExpressLogin);
            WaitUtilities.WaitForElement(driver, PasswordField, 15);
            PasswordField.SendKeys(aliExpressPassword);
            WaitUtilities.WaitForElement(driver, LoginSubmitButton, 15);
            LoginSubmitButton.Click();
        }

        public MyOrdersPage NavigateToMyOrdersPage()
        {
            WaitUtilities.WaitForElement(driver, MyOrdersLink, 15);
            MyOrdersLink.Click();
            return new MyOrdersPage(driver);
        }

        #endregion

    }
}
