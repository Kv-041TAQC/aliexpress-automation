using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VasylPages
{
    public class MyFranceMainPage : SuperPage
    {
        public MyFranceMainPage(IWebDriver driver) : base(driver)
        {
        }

        #region Constants
        private readonly string cssGlobalSite = "#nav-global > div.ng-item.ng-goto-globalsite > a";
        private readonly string idSearchField = "search-key";
        private readonly string cssSearchButton = "#form-searchbar > div.searchbar-operate-box > input";
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

        private IWebElement SearchButton
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssSearchButton));
            }
        }
        #endregion

        public MySearchPageFrance NextPage()
        {
            Thread.Sleep(2000);
            SendText(SearchField, alijson.ValidData[0]);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new MySearchPageFrance(driver);
        }
    }
}