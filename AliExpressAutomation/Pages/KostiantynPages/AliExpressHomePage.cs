using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Pages.KostiantynPages.Helpers;
using Pages;
using Pages.AnnPages;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Pages.KostiantynPages
{
    public class AliExpressHomePage : SuperPage
    {
        #region Fields and Constants

        private IWait<IWebDriver> wait;
        private const string aliExpressURL = "https://www.aliexpress.com";

        #endregion

        #region Page Element Locators and Properties

        private By goToGlobalSiteLinkLocator = By.LinkText("Go to Global Site (English)");
        private By signInButtonLocator = By.XPath("//div[@id='user-benefits']/div[@class='user-account']//span[@class='register-btn']/a[@data-role='sign-link']");
        private By aliExpressLoginFormLocator = By.Id("alibaba-login-box");
        private By loginFieldLocator = By.Id("fm-login-id");
        private By passwordFieldLocator = By.Id("fm-login-password");
        private By loginSubmitButtonLocator = By.Id("fm-login-submit");
        private By adsCloseButtonLocator = By.XPath("//a[@data-role='layer-close']");
        private By adsLayerLocator = By.XPath("//div[@class='ui-window ui-window-normal ui-window-transition ui-newuser-layer-dialog']");

        private By newUserAdNotificationLocator = By.ClassName("ui-newuser-coupon-tips");

        private By myOrdersIconLocator = By.CssSelector(".order-icon");
        private By myOrdersLinkLocator = By.XPath("//div[@class='fast-entry']//a[contains(@href, 'orderList.htm')]");

        private By searchFieldLocator = By.Id("search-key");
        private By searchButtonLocator = By.CssSelector("#form-searchbar > div.searchbar-operate-box > input");

        public IWebElement SearchField
        {
            get
            {
                return driver.FindElement(searchFieldLocator);
            }
        }
        public IWebElement SearchButton
        {
            get
            {
                return driver.FindElement(searchButtonLocator);
            }
        }
        public IWebElement GoToGlobalSiteLink => driver.FindElement(goToGlobalSiteLinkLocator);
        public IWebElement SignInButton => driver.FindElement(signInButtonLocator);
        public IWebElement AliExpressLoginForm => driver.FindElement(aliExpressLoginFormLocator);
        public IWebElement LoginField => driver.FindElement(loginFieldLocator);
        public IWebElement PasswordField => driver.FindElement(passwordFieldLocator);
        public IWebElement LoginSubmitButton => driver.FindElement(loginSubmitButtonLocator);

        public IWebElement AdsCloseButton => driver.FindElement(adsCloseButtonLocator);
        public IWebElement MyOrdersLink => driver.FindElement(myOrdersLinkLocator);

       
       
        #endregion

        #region Constructors

        public AliExpressHomePage(IWebDriver driver) : base(driver)
        {

        }
        public AliExpressHomePage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver)
        {
            this.wait = wait;
        }

        #endregion

        #region Methods
        public void NavigateToAliExpressHomepage()
        {
            driver.Navigate().GoToUrl(aliExpressURL);
        }


        public void LoginToAliExpress(Login login)
        {

            bool isAdClosed = false;
            try
            {
                WaitUtilities.WaitForElementNTimes(driver, adsCloseButtonLocator, 5000, 3);
                Click(AdsCloseButton);
                isAdClosed = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Could not locate ad: " + e.Message);
            }

            WaitUtilities.WaitForElementNTimes(driver, goToGlobalSiteLinkLocator, 5000, 3);
            wait.Until(ExpectedConditions.ElementToBeClickable(goToGlobalSiteLinkLocator));
            Click(GoToGlobalSiteLink);

            if (!isAdClosed)
            {
                try
                {
                    WaitUtilities.WaitForElementNTimes(driver, adsCloseButtonLocator, 5000, 3);
                    Click(AdsCloseButton);
                    isAdClosed = true;

                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine("DEBUG: Could not locate ad: " + e.Message);
                }
            }
            
            WaitUtilities.WaitForElementNTimes(driver, signInButtonLocator, 5000, 3);
            Click(SignInButton);


            WaitUtilities.WaitForElementNTimes(driver, aliExpressLoginFormLocator, 5000, 3);
            driver.SwitchTo().Frame(AliExpressLoginForm);

      
            WaitUtilities.WaitForElementNTimes(driver, loginFieldLocator, 5000, 3);
            SendText(LoginField, login.login);

      
            WaitUtilities.WaitForElementNTimes(driver, passwordFieldLocator, 5000, 3);
            SendText(PasswordField, login.password);

      
            WaitUtilities.WaitForElementNTimes(driver, loginSubmitButtonLocator, 5000, 3);
            Click(LoginSubmitButton);

        }

        public MyOrdersPage NavigateToMyOrdersPage()
        {
    
            WaitUtilities.WaitForElementNTimes(driver, myOrdersLinkLocator, 5000, 3);
            Click(MyOrdersLink);
            return new MyOrdersPage(driver, wait);
        }
        
         #endregion


    }
}
