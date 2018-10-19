using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pages.EvgenPages;
using static Pages.HelpClasses.HelpPage;

namespace Pages.VasylPages
{
    public class MyMainPage : SearchStringPage
    {
        public MyMainPage(IWebDriver driver) : base(driver)
        {
        }

        #region Constants
        private readonly string url = "https://ru.aliexpress.com/";
        private readonly string cssGlobalSite = "#nav-global > div.ng-item.ng-goto-globalsite > a";
        private readonly string cssCloseAdvertising = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        #endregion

        #region IWebElements
        private IWebElement GlobalSite
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssGlobalSite));
            }
        }

        private IWebElement CloseAdvertising {
            get
            {
                return driver.FindElement(By.CssSelector(cssCloseAdvertising));
            }
        }
        
        #endregion

        public MySearchPageIphone NextPage()
        {
            NavigateToUrl(url);
            Thread.Sleep(2000);
            MaximizeWindow();
            Thread.Sleep(15000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            Thread.Sleep(5000);
            Click(GlobalSite);
            Thread.Sleep(3000);
            SendText(SearchField, alijson.ValidData[1]);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new MySearchPageIphone(driver);
        }
       
    }
}
