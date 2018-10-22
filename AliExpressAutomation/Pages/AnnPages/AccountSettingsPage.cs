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
        public AccountSettingsPage(IWebDriver driver) : base(driver)
        {
        }

        #region Сonstants
        private readonly string EmailNotificationsBtnLocator = "#settings-panel > div:nth-child(3) > ul > li > a";
        #endregion

        #region IWebElements
        private IWebElement EmailNotificationsBtn => driver.FindElement(By.CssSelector(EmailNotificationsBtnLocator));

        #endregion

        #region Methods
        public EmailSubscriptionPage GotoEmailSubscriptionPage()
        {
            Thread.Sleep(7000);
            //Click(EmailNotificationsBtn);
            driver.Navigate().GoToUrl(@"https://my.aliexpress.com/subscription/email_subscription_management.htm");
            return new EmailSubscriptionPage(driver);
        }
        #endregion
    }

}
