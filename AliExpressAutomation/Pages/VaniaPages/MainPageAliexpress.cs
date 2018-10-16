using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class MainPageAliexpress: SuperPage
    {
        #region ConstantIdButtonsAndFields
        private readonly string urlAliexpress = "https://ru.aliexpress.com";
        private readonly string buttonLogin = "#user-benefits > div:nth-child(1) > div.login-status > span.register-btn > a";
        private readonly string emailLogin = "#fm-login-id";
        private readonly string passwordLogin = "#fm-login-password";
        private readonly string buttonSubmit = "#fm-login-submit";
        private const string aliExpressLoginFormId = "alibaba-login-box";
        #endregion

        #region SearchWebElement
        protected IWebElement searchButtonLogin
        {
            get { return driver.FindElement(By.CssSelector(buttonLogin)); }
        }

        protected IWebElement CloseAdvertising
        {
            get { return driver.FindElement(By.CssSelector("body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a")); }
        }

        protected IWebElement SearchButton
        {
            get { return driver.FindElement(By.CssSelector("#search-key")); }
        }

        protected IWebElement SearchField
        {
            get { return driver.FindElement(By.CssSelector("#form-searchbar > div.searchbar-operate-box > input")); }
        }

        private IWebElement searchEmailLogin
        {
            get { return driver.FindElement(By.CssSelector(emailLogin)); }
        }

        private IWebElement searchPasswordLogin
        {
            get { return driver.FindElement(By.CssSelector(passwordLogin)); }
        }

        private IWebElement searchButtonSubmit
        {
            get { return driver.FindElement(By.CssSelector(buttonSubmit)); }
        }
        #endregion

        #region Methods
        public MainPageAliexpress(IWebDriver dr) : base(dr)
        {

        }

        public SearchProductForWishes MainPageGoToLogin()
        {
            MaximizeWindow();
            NavigateToUrl(urlAliexpress);
            Thread.Sleep(30000);
            try
            {
                if (CloseAdvertising.Displayed)
                    Click(CloseAdvertising);
            }
            catch { }
            Thread.Sleep(2000);
            Click(searchButtonLogin);
            Thread.Sleep(7000);
            driver.SwitchTo().Frame(driver.FindElement(By.Id(aliExpressLoginFormId)));
            searchEmailLogin.Clear();
            searchEmailLogin.Click();
            SendText(searchEmailLogin, "i.v.zaichenko70@gmail.com");
            Thread.Sleep(3000);
            searchPasswordLogin.Clear();
            searchPasswordLogin.Click();
            SendText(searchPasswordLogin, "dfyzdfyz70");
            Thread.Sleep(3000);
            Click(searchButtonSubmit);
            Thread.Sleep(10000);
            try
            {
                if (CloseAdvertising.Displayed)
                    Click(CloseAdvertising);
            }
            catch { }
            Thread.Sleep(5000);
            SendText(SearchButton, alijson.ValidData[0]);
            Thread.Sleep(2000);
            Click(SearchField);
            Thread.Sleep(1000);
            return new SearchProductForWishes(driver);

        }
        #endregion
    }
}
