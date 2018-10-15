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

        private readonly string buttonLogin = "# nav-user-account > div.user-account-info > div > span.account-unsigned > a:nth-child(1)";
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
            get { return driver.FindElement(By.CssSelector("#form-searchbar > div.searchbar-operate-box > input")); }
        }

        protected IWebElement SearchField
        {
            get { return driver.FindElement(By.Id("search-key")); }
        }


        #endregion

        #region Methods
        public MainPageAliexpress(IWebDriver dr) : base(dr)
        {

        }

        public Login MainPageGoToLogin()
        {
            MaximizeWindow();
            NavigateToUrl("https://ru.aliexpress.com");
            Thread.Sleep(7000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            Thread.Sleep(2000);
            Click(searchButtonLogin);
            return new Login(driver);
        }
        #endregion
    }
}
