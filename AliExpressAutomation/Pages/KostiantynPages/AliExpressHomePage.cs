using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using AliExpress.Helpers;
using Pages;


namespace AliExpress.Pages
{
    public class AliExpressHomePage : SuperPage
    {

        #region Fields and Constants

        private WebDriverWait wait;
        private const string aliExpressURL = "https://www.aliexpress.com";
        private const string aliExpressLogin = "skaxrfdzeajgee2w@outlook.com";
        private const string aliExpressPassword = "qLEvZxcMVU9xqdQC";


        #endregion

        #region Page Element Locators and Properties

        private By goToGlobalSiteLinkLocator = By.LinkText("Go to Global Site (English)");
        private By signInButtonLocator = By.XPath("//div[@id='user-benefits']/div[@class='user-account']//span[@class='register-btn']/a[@data-role='sign-link']");
        private By aliExpressLoginFormLocator = By.Id("alibaba-login-box");
        private By loginFieldLocator = By.Id("fm-login-id");
        private By passwordFieldLocator = By.Id("fm-login-password");
        private By loginSubmitButtonLocator = By.Id("fm-login-submit");
        private By adsCloseButtonLocator = By.XPath("//a[@data-role='layer-close']");
        private By adsLayerLocator = By.ClassName("ui-window ui-window-normal ui-window-transition ui-newuser-layer-dialog");
        private By myOrdersLinkLocator = By.XPath("//a[contains(@href, 'orderList.htm')]");


        public IWebElement GoToGlobalSiteLink => driver.FindElement(goToGlobalSiteLinkLocator);
        public IWebElement SignInButton => driver.FindElement(signInButtonLocator);
        public IWebElement AliExpressLoginForm => driver.FindElement(aliExpressLoginFormLocator);
        public IWebElement LoginField => driver.FindElement(loginFieldLocator);
        public IWebElement PasswordField => driver.FindElement(passwordFieldLocator);
        public IWebElement LoginSubmitButton => driver.FindElement(loginSubmitButtonLocator);

        public IWebElement AdsCloseButton => driver.FindElement(adsCloseButtonLocator);
        public IWebElement MyOrdersLink => driver.FindElements(myOrdersLinkLocator)[1];

        #endregion

        #region Constructors
        public AliExpressHomePage(IWebDriver driver) : base(driver)
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
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
                wait.Until(ExpectedConditions.ElementToBeClickable(adsCloseButtonLocator));
                Click(AdsCloseButton);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(adsLayerLocator));

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: There was no ad: " + e.Message);
            }
            wait.Until(ExpectedConditions.ElementToBeClickable(goToGlobalSiteLinkLocator));
            Thread.Sleep(15000);
            Click(GoToGlobalSiteLink);
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButtonLocator));
            Click(SignInButton);
            wait.Until(ExpectedConditions.ElementToBeClickable(aliExpressLoginFormLocator));
            driver.SwitchTo().Frame(AliExpressLoginForm);
            // wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementIsVisible(loginFieldLocator));
            Thread.Sleep(15000);
            SendText(LoginField, aliExpressLogin);
            wait.Until(ExpectedConditions.ElementToBeClickable(passwordFieldLocator));
            SendText(PasswordField, aliExpressPassword);
            wait.Until(ExpectedConditions.ElementToBeClickable(loginSubmitButtonLocator));
            Click(LoginSubmitButton);
        }

        public MyOrdersPage NavigateToMyOrdersPage()
        {
            // wait.Until(ExpectedConditions.ElementToBeClickable(myOrdersLinkLocator));
            Thread.Sleep(15000);
            Click(MyOrdersLink);
            return new MyOrdersPage(driver);
        }

        #endregion

    }
}
