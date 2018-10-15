using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class MainPageAliexpress: EvgenPages.SearchStringPage
    {
        private readonly string buttonLogin = "# nav-user-account > div.user-account-info > div > span.account-unsigned > a:nth-child(1)";



        public MainPageAliexpress(IWebDriver dr) : base(dr)
        {

        }
        /// <summary>
        /// Runs the postive test.In param send index of valid data in array
        /// </summary>
        /// 
        protected IWebElement searchButtonLogin
        {
            get { return driver.FindElement(By.CssSelector(buttonLogin)); }
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
    }
}
