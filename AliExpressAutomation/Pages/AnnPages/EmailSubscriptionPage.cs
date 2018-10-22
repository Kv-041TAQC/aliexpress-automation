using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using static Pages.HelpClasses.HelpPage;

namespace Pages.AnnPages
{
    public class EmailSubscriptionPage : SuperPage
    {
        
        public EmailSubscriptionPage(IWebDriver driver) : base(driver)
        {
        }
        #region Constans
        // private readonly string ButtonsSubscription1Locator = "body > div.me-main.util-clearfix.email-subscriptions > div.container > div > div > div > table > tbody > tr:nth-child(1) > td.subs-btn > a";
        private readonly string ButtonsSubscriptionLocator = "td.subs-btn > a";
        private readonly string StatusLocator = "td.subs-status";
        #endregion

        #region IWebElements
        //private IWebElement ButtonsSubscription1 => driver.FindElement(By.CssSelector(ButtonsSubscription1Locator));
        private ReadOnlyCollection <IWebElement> ButtonsSubscription => driver.FindElements(By.CssSelector(ButtonsSubscriptionLocator));
        private ReadOnlyCollection <IWebElement> Status => driver.FindElements(By.CssSelector(StatusLocator));

        #endregion

        #region Methods
        public void ClickButtonsSubscription()
        {
            Thread.Sleep(5000);
            foreach (IWebElement element in ButtonsSubscription)
            {
                Thread.Sleep(1000);
                Click(element);
            }
            Thread.Sleep(5000);
        }

        public bool Check()
        {
            if (ButtonsSubscription[0].Text == "Disable")
            {
                return Status[0].Text == "Enabled";
            } else
            {
                return Status[0].Text == "Disabled";
            }
        }
        
        #endregion
    }
}