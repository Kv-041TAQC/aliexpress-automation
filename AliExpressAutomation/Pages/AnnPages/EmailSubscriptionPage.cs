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
        /// this is the Email Subscription Page: my.aliexpress.com/subscription/email_subscription_management.htm
       
        public EmailSubscriptionPage(IWebDriver driver) : base(driver)
        {
        }
        //#region Constans
        //private readonly string ButtonsSubscriptionLocator = "a.ui-button.ui-button-normal.ui-button-medium";
        // private readonly string StatusSubscriptionLocator = "td.subs-status";  
       // #endregion


        #region IWebElements
        private IWebElement ButtonsSubscription1 => driver.FindElement(By.CssSelector("body > div.me-main.util-clearfix.email-subscriptions > div.container > div > div > div > table > tbody > tr:nth-child(1) > td.subs-btn > a"));

        //private IWebElement ButtonsSubscription2 => driver.FindElements(By.CssSelector("body > div.me-main.util-clearfix.email-subscriptions > div.container > div > div > div > table > tbody > tr:nth-child(2) > td.subs-btn > a"));
        //private ReadOnlyCollection<IWebElement> StatusSubscription => driver.FindElements(By.CssSelector(StatusSubscriptionLocator));

        #endregion

        //public void ClickButtons()
        //{
        //    Thread.Sleep(7000);
        //    foreach (IWebElement element in ButtonsSubscription)
        //    {
        //        element.Click();
        //    }
        //}
        public void ClickButtonsSubscription1()
        {
            Thread.Sleep(7000);
            Click(ButtonsSubscription1);
           
        }
        //public bool CheckStatusSubscription(string value)
        //{
        //    Thread.Sleep(7000);
        //    var count = 0;

        //    foreach (IWebElement element in StatusSubscription)
        //    {
        //        if (element.Text == value)
        //        {
        //            count++;
        //        } else
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

    }
}