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
    public class AccountSettingsPage : SuperPage
    {
        // this is Account Settings Page: home.aliexpress.com/account_settings.htm?spm=a2g0s.8937420.0.0.71d62e0eWKJ0vV&flag=account
        public AccountSettingsPage(IWebDriver driver) : base(driver)
        {
        }
        
        #region IWebElements
        private IWebElement EmailNotificationsBtn => driver.FindElement(By.CssSelector("#settings-panel > div:nth-child(3) > ul > li > a"));
        
        #endregion

        public EmailSubscriptionPage GotoEmailSubscriptionPage()
        {
            Thread.Sleep(7000);
            Click(EmailNotificationsBtn);
            return new EmailSubscriptionPage(driver);
        }

    }
  
}
