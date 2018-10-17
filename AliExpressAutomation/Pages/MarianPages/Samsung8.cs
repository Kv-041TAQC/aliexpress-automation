using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class Samsung8 : SuperPage
    {
        public Samsung8(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string cart = "#header > div > div.hm-right > div.nav-cart.nav-cart-box > a";
        private const string bundle = "sku-1-200003982";
        private const string color = "sku-2-193";
        private const string addToCart = "j-add-cart-btn";
        private const string close = "ui-window-close";

        #endregion

        #region webElements

        private IWebElement Cart
        {
            get { return driver.FindElement(By.CssSelector(cart)); }
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

        public Cart GoToCart()
        {
            Thread.Sleep(1000);
            Click(Bundle);
            Click(Color); ;
            Click(Close);
            Click(Cart);
            
            return new Cart (driver);
        }
    }
}
