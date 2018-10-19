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
        #region Constans
        private readonly string ButtonsSubscriptionLocator = "td.subs-btn > a";
        
        #endregion
        
        #region IWebElements
        private ReadOnlyCollection<IWebElement> ButtonsSubscription => driver.FindElements(By.CssSelector("td.subs-btn > a"));
        
        #endregion

        #region Methods
        public void ClickButtons()
        {
            Thread.Sleep(10000);
            var test = ButtonsSubscription;
            Thread.Sleep(7000);
            foreach (IWebElement element in test)
            {
                element.Click();
                Thread.Sleep(2000);
            }
            #endregion
        }
    }
}