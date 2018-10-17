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
        private readonly string idSearchField = "search-key";
        private readonly string cssSearchButton = "#form-searchbar > div.searchbar-operate-box > input";
        private readonly string cssCloseAdvertising = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        private readonly By MyAliexpressLocator = By.Name("My AliExpress");
        #endregion

        #region IWebElements
        private IWebElement GlobalSite
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssGlobalSite));
            }
        }

        private IWebElement SearchField
        {
            get
            {
                return driver.FindElement(By.Id(idSearchField));
            }
        }

        private IWebElement SearchButton {
            get
            {
                return driver.FindElement(By.CssSelector(cssSearchButton));
            }
        }

        private IWebElement CloseAdvertising {
            get
            {
                return driver.FindElement(By.CssSelector(cssCloseAdvertising));
            }
        }
        private IWebElement MyAliExpressBtn => driver.FindElement(MyAliexpressLocator);
        #endregion

        public MySearchPageIphone NextPage()
        {
            MaximizeWindow();
            NavigateToUrl(url);
            Thread.Sleep(15000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            Thread.Sleep(5000);
            Click(GlobalSite);
            Thread.Sleep(3000);
            SendText(SearchField, alijson.ValidData[0]);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new MySearchPageIphone(driver);
        }
        public AnnPages.AccountSettingsPage GotoAccountSettingsPage()
        {
            Click(MyAliExpressBtn);
            return new AnnPages.AccountSettingsPage(driver);
        }
    }
}
