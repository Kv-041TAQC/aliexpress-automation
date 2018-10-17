using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class IPhone6S : SuperPage
    {
        public IPhone6S(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string search = "search-key";
        private const string searchButton = "search-button";
        private const string bundle = "sku-1-200003985";
        private const string color = "sku-2-350850";       
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

        public ResultIPhone ChooseIPhone7()
        {
            Thread.Sleep(2000);
            Click(Bundle);
            Thread.Sleep(1000);
            Click(Color);
            Thread.Sleep(1000);
            Click(AddToCart);
            Thread.Sleep(2000);
            Click(Close);
            Thread.Sleep(2000);
            Search.Clear();
            SendText(Search, alijson.ValidData[0]);
            Click(SearchButton);
            return new ResultIPhone(driver);
        }
    }
}
