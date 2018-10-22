using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static Pages.HelpClasses.HelpPage;

namespace Pages.AnnPages
{
    public class AccountHomePage : SuperPage
    {
        public AccountHomePage (IWebDriver driver) : base(driver)
        {
        }
        #region Сonstants
        private readonly string ChangePasswordBtnLocator = "body > div.container.me-body-container > div.row > div.col-xs-12 > div:nth-child(1) > div > div > p:nth-child(7) > a";
        
        #endregion
        
        #region IWebElements
        private IWebElement ChangePasswordBtn => driver.FindElement(By.CssSelector(ChangePasswordBtnLocator));

        #endregion

        #region Methods
        public AccountSettingsPage GotoAccountSettingsPage()
        {
            Thread.Sleep(7000);
            Click(ChangePasswordBtn);
            return new AccountSettingsPage(driver);
        }
        #endregion
    }
}
