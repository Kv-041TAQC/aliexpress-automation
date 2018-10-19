using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using AliExpress.Pages;
using static Pages.HelpClasses.HelpPage;

namespace Pages.VasylPages
{
    public class LocalMainMethodsPage : AliExpressHomePage
    {
        public LocalMainMethodsPage(IWebDriver driver) : base(driver)
        {
        }

        private By searchFieldLocator = By.Id("search-key");
        private By searchButtonLocator = By.CssSelector("#form-searchbar > div.searchbar-operate-box > input");

        private IWebElement SearchField
        {
            get
            {
                return driver.FindElement(searchFieldLocator);
            }
        }

        private IWebElement SearchButton
        {
            get
            {
                return driver.FindElement(searchButtonLocator);
            }
        }

        public MyShoppingPage NextPageFrance()
        {
            Thread.Sleep(2000);
            SendText(SearchField, alijson.ValidData[1]);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new MyShoppingPage(driver);
        }

        public MyShoppingPage NextPageEnglish()
        {
            MaximizeWindow();
            NavigateToAliExpressHomepage();
            Thread.Sleep(15000);
            Click(AdsCloseButton);
            Thread.Sleep(5000);
            Click(GoToGlobalSiteLink);
            Thread.Sleep(3000);
            SendText(SearchField, alijson.ValidData[1]);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new MyShoppingPage(driver);
        }
    }
}
