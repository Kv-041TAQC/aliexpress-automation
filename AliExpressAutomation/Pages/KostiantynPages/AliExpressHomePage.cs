﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using AliExpress.Helpers;
using Pages;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace AliExpress.Pages
{
    public class AliExpressHomePage : SuperPage
    {

        #region Fields and Constants

        private IWait<IWebDriver> wait;
        private const string aliExpressURL = "https://www.aliexpress.com";
        
        // private const string aliExpressLogin = "skaxrfdzeajgee2w@outlook.com";
        // private const string aliExpressPassword = "qLEvZxcMVU9xqdQC";


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
            IWait<IWebDriver> longAdWait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            try
            {
                longAdWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                longAdWait.Until(ExpectedConditions.ElementToBeClickable(adsCloseButtonLocator));
                Click(AdsCloseButton);
                longAdWait.Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete"));
                // longAdWait.Until(ExpectedConditions.InvisibilityOfElementLocated(adsLayerLocator));
                // longAdWait.Until(ExpectedConditions.StalenessOf(driver.FindElement(adsLayerLocator)));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Could not locate ad: " + e.Message);
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("DEBUG: Timed out while waiting for ad: " + e.Message);
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(goToGlobalSiteLinkLocator));
            Click(GoToGlobalSiteLink);
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButtonLocator));
            Click(SignInButton);

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(aliExpressLoginFormLocator));
            wait.Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete"));
            wait.Until(ExpectedConditions.ElementIsVisible(aliExpressLoginFormLocator));
            driver.SwitchTo().Frame(AliExpressLoginForm);
            
            var frameWait = new WebDriverWait(driver, wait.Timeout);
            frameWait.Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete"));
            frameWait.Until(ExpectedConditions.ElementIsVisible(loginFieldLocator));
            SendText(LoginField, login.login);
            frameWait.Until(ExpectedConditions.ElementIsVisible(passwordFieldLocator));
            SendText(PasswordField, login.password);
            frameWait.Until(ExpectedConditions.ElementIsVisible(loginSubmitButtonLocator));
            Click(LoginSubmitButton);
            frameWait.Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public MyOrdersPage NavigateToMyOrdersPage()
        {
            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            var pageWait = new WebDriverWait(driver, wait.Timeout);
            
            pageWait.Until(ExpectedConditions.ElementIsVisible(myOrdersIconLocator));
            Click(MyOrdersLink);
            return new MyOrdersPage(driver, pageWait);
        }

        #endregion



    }
}