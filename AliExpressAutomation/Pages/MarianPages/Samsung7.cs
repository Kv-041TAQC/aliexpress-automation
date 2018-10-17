using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class Samsung7 : SuperPage
    {
        public Samsung7(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string search = "search-key";
        private const string searchButton = "search-button";
        private const string bundle = "sku-1-200003982";
        private const string color = "sku-2-29";       
        private const string addToCart = "j-add-cart-btn";
        private const string close = "ui-window-close";

        #endregion

        #region webElements

        private IWebElement Search
        {
            get { return driver.FindElement(By.Id(search)); }
        }

        private IWebElement SearchButton
        {
            get { return driver.FindElement(By.ClassName(searchButton)); }
        }

        private IWebElement Bundle
        {
            get { return driver.FindElement(By.Id(bundle)); }
        }

        private IWebElement Color
        {
            get { return driver.FindElement(By.Id(color)); }
        }
        
        private IWebElement AddToCart
        {
            get { return driver.FindElement(By.Id(addToCart)); }
        }

        private IWebElement Close
        {
            get { return driver.FindElement(By.ClassName(close)); }
        }

        
        #endregion

        public ResultSamsung ChooseSamsung8()
        {
            Thread.Sleep(1000);
            Click(Bundle);
            Click(Color);            ;
            Click(Close);
            Search.Clear();
            SendText(Search, alijson.ValidData[1]);
            Click(SearchButton);
            return new ResultSamsung(driver);
        }
    }
}
