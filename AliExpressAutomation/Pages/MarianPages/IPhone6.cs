using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Pages.MarianPages
{
    public class IPhone6 : SuperPage
    {
        public IPhone6(IWebDriver driver) : base(driver)
        {
        }
        
        #region constants

        private const string bundle = "sku-1-200003985";
        private const string color = "sku-2-496";
        
        private const string quantity = "p-quantity-increase";
        private const string addToCart = "j-add-cart-btn";
        private const string close = "ui-window-close";
        private const string search = "search-key";
        private const string searchButton = "search-button";

        #endregion

        #region webElements

        private IWebElement Bundle
        {
            get { return driver.FindElement(By.Id(bundle)); }
        }

        private IWebElement Color
        {
            get { return driver.FindElement(By.Id(color)); }
        }
               
        private IWebElement Quantity
        {
            get { return driver.FindElement(By.ClassName(quantity)); }
        }

        private IWebElement AddToCart
        {
            get { return driver.FindElement(By.Id(addToCart)); }      
        }

        private IWebElement Close
        {
            get { return driver.FindElement(By.ClassName(close)); }
        }

        private IWebElement Search
        {
            get { return driver.FindElement(By.Id(search)); }
        }

        private IWebElement SearchButton
        {
            get { return driver.FindElement(By.ClassName(searchButton)); }
        }
        #endregion
        


        public ResultIPhone ChooseIPhone6s()
        {            
            Thread.Sleep(2000);
            Click(Bundle);
            Thread.Sleep(1000);
            Click(Color);
            Thread.Sleep(1000);            
            Click(Quantity);
            Thread.Sleep(1000);
            Click(AddToCart);
            Thread.Sleep(2000);
            Click(Close);
            Thread.Sleep(2000);
            Search.Clear();
            SendText(Search, alijson.ValidData[1]);
            Click(SearchButton);
            return new ResultIPhone(driver);
        }

    }
}
