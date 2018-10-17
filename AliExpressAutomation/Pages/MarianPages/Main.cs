using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class Main : SuperPage
    {
        private readonly string url = @"https://ru.aliexpress.com/";
        public Main(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string search = "search-key";
        private const string searchButton = "search-button";
        private const string cart = "#header > div > div.hm-right > div.nav-cart.nav-cart-box > a";
        private const string cartNum = "nav-cart-num";
        private const string closeSpam = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        #endregion

        #region webElements

        private IWebElement CloseSpam
        {
            get { return driver.FindElement(By.CssSelector(closeSpam)); }
        }

        private IWebElement Search
        {
            get { return driver.FindElement(By.Id(search)); }
        }

        private IWebElement SearchButton
        {
            get { return driver.FindElement(By.ClassName(searchButton)); }
        }

        private IWebElement Cart
        {
            get { return driver.FindElement(By.CssSelector(cart)); }
        }

        private IWebElement CartNum
        {
            get { return driver.FindElement(By.CssSelector(cartNum)); }
        }

        #endregion

        public void NavigateToAli()
        {
            driver.Navigate().GoToUrl(this.url);
        }

        public ResultSamsung ChooseSamsung6()
        {
            Thread.Sleep(4000);
            Click(CloseSpam);
            Thread.Sleep(2000);
            Search.Clear();
            SendText(Search, alijson.ValidData[1]);
            Click(SearchButton);
            return new ResultSamsung(driver);
        }

    }
}
