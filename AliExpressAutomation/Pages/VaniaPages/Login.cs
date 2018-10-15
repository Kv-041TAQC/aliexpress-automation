using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static Pages.HelpClasses.HelpPage;

namespace Pages.VaniaPages
{
    public class Login : SuperPage
    {
        #region ConstantIdButtonsAndFieldsForAddressPageEmployer
        private readonly string emailLogin = "fm-login-id";
        private readonly string passwordLogin = "fm-login-password";
        private readonly string buttonSubmit = "fm-login-submit";
        #endregion

        #region FindWebElementFromIdForAddressPageEmployer
        private IWebElement searchEmailLogin
        {
            get { return driver.FindElement(By.Id(emailLogin)); }
        }

        private IWebElement searchPasswordLogin
        {
            get { return driver.FindElement(By.Id(passwordLogin)); }
        }

        private IWebElement searchButtonSubmit
        {
            get { return driver.FindElement(By.Id(buttonSubmit)); }
        }
        #endregion

        #region MethodOfAddressPageEmployer

        public Login(IWebDriver driver) : base(driver)
        {

        }

        public void EnterData()
        {
            searchEmailLogin.Clear();
            SendText(searchEmailLogin, "i.v.zaichenko70@gmail.com");
            searchPasswordLogin.Clear();
            SendText(searchPasswordLogin, "dfyzdfyz70");
        }


        public MainPageAliexpressAutorized LoginAccount()
        {
            MaximizeWindow();
            Thread.Sleep(2000);
            EnterData();
            Click(searchButtonSubmit);
            return new MainPageAliexpressAutorized(driver);
        }
        #endregion
    }
}
