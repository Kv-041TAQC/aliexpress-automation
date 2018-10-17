using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Pages.MarianPages
{
    public class Samsung6 : SuperPage
    {
        public Samsung6(IWebDriver driver) : base(driver)
        {
        }
        
        #region constants

        private const string bundle = "#sku-1-200003982";
        private const string color = @"sku-2-29";
        private const string quantity = @"p-quantity-increase";
        private const string addToCart = @"j-add-cart-btn";
        private const string close = @"ui-window-close";
        private const string search = @"search-key";
        private const string searchButton = @"search-button";

        #endregion

        #region webElements

        private IWebElement Bundle
        {
            get { return driver.FindElement(By.CssSelector(bundle)); }
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
        


        public ResultSamsung ChooseSamsung7()
        {            
            Thread.Sleep(3000);
            Click(Bundle);
            Thread.Sleep(2000);
            Click(Color);
            Thread.Sleep(2000);
            Click(Quantity);
            Thread.Sleep(2000);
            Click(AddToCart);
            Thread.Sleep(2000);
            Click(Close);
            Thread.Sleep(2000);
            Search.Clear();
            Thread.Sleep(2000);
            SendText(Search, alijson.ValidData[1]);
            Click(SearchButton);
            Thread.Sleep(2000);
            return new ResultSamsung(driver);
        }

    }
}
