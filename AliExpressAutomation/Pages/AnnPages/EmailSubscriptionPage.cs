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
    class EmailSubscriptionPage : SuperPage
    {
        /// this is the Email Subscription Page: my.aliexpress.com/subscription/email_subscription_management.htm
       
        public EmailSubscriptionPage(IWebDriver driver) : base(driver)
        {
        }
        #region Constans
        private readonly By ButtonsSubscriptionLocator = By.CssSelector("a.ui-button.ui-button-normal.ui-button-medium");
        private readonly By StatusSubscriptionLocator = By.CssSelector("td.subs-status");
        
        #endregion


        #region IWebElements
        private ReadOnlyCollection<IWebElement> ButtonsSubscription
        {
            get
            {
                return driver.FindElements(ButtonsSubscriptionLocator);
            }
        }

        private ReadOnlyCollection<IWebElement> StatusSubscription
        {
            get
            {
                return driver.FindElements(StatusSubscriptionLocator);
            }
        }

        #endregion

        public void ClickButtons()
        {
            foreach (IWebElement element in ButtonsSubscription)
            {
                element.Click();
            }
        }
        public bool CheckStatusSubscription(string value)
        {
            var count = 0;

            foreach (IWebElement element in StatusSubscription)
            {
                if (element.Text == value)
                {
                    count++;
                } else
                {
                    return false;
                }
            }
            return true;
        }
    }
}