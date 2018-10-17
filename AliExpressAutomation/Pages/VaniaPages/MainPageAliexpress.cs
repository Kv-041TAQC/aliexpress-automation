using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class MainPageAliexpress : SuperPage
    {
        #region ConstantIdButtonsAndFields
        private readonly string urlAliexpress = "https://ru.aliexpress.com";
        private readonly string buttonLogin = "#user-benefits > div:nth-child(1) > div.login-status > span.register-btn > a";
        private readonly string emailLogin = "#fm-login-id";
        private readonly string passwordLogin = "#fm-login-password";
        private readonly string buttonSubmit = "#fm-login-submit";
        private readonly string CssCloseAdvertising = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        private readonly string CssSearchButton = "#search-key";
        private readonly string CssSearchField = "#form-searchbar > div.searchbar-operate-box > input";
        private const string aliExpressLoginFormId = "alibaba-login-box";
        private const string email = "i.v.zaichenko70@gmail.com";
        private const string password = "dfyzdfyz70";
        #endregion

        #region SearchWebElement
        protected IWebElement ButtonLogin
        {
            get { return driver.FindElement(By.CssSelector(buttonLogin)); }
        }

        protected IWebElement CloseAdvertising
        {
            get { return driver.FindElement(By.CssSelector(CssCloseAdvertising)); }
        }

        protected IWebElement SearchButton
        {
            get { return driver.FindElement(By.CssSelector(CssSearchButton)); }
        }

        protected IWebElement SearchField
        {
            get { return driver.FindElement(By.CssSelector(CssSearchField)); }
        }

        private IWebElement EmailLogin
        {
            get { return driver.FindElement(By.CssSelector(emailLogin)); }
        }

        private IWebElement PasswordLogin
        {
            get { return driver.FindElement(By.CssSelector(passwordLogin)); }
        }

        private IWebElement ButtonSubmit
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
            Thread.Sleep(15000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            Thread.Sleep(2000);
            Click(ButtonLogin);
            Thread.Sleep(5000);
            driver.SwitchTo().Frame(driver.FindElement(By.Id(aliExpressLoginFormId)));
            EmailLogin.Clear();
            SendText(EmailLogin, email);
            Thread.Sleep(1000);
            PasswordLogin.Clear();
            SendText(PasswordLogin, password);
            Thread.Sleep(1000);
            Click(ButtonSubmit);
            Thread.Sleep(5000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
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