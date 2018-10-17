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
    /// this is the Account Settings Page: home.aliexpress.com/account_settings.htm?spm=a2g0s.8937420.0.0.71d62e0eWKJ0vV&flag=account

    public class AccountSettingsPage : SuperPage
    {
        public AccountSettingsPage (IWebDriver driver) : base(driver)
        {
        }
        #region Constans
        private readonly By ChangePasswordLocator = By.Name("Change Password");

        #endregion

        #region IWebElements
        private IWebElement ChangePasswordBtn => driver.FindElement(ChangePasswordLocator);
        
        #endregion

        public EmailSubscriptionPage GotoEmailSubscriptionPage()
        {
            Click(ChangePasswordBtn);
            return new EmailSubscriptionPage(driver);
        }
         
    }
}
