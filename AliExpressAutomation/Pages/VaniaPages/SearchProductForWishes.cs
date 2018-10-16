using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class SearchProductForWishes : SuperPage
    {

        #region ConstantAndButtonsAndFields
        private readonly string iphoneCSSproduct1 = "#hs-list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.info.infoprice > div.add-to-wishlist > a";
        private readonly string buttonMyWishesCSS = "#header > div > div.hm-right > div.nav-wishlist";

        #endregion

        #region FindWebElement
        private IWebElement Iphone6Sproduct1ToWishes
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct1)); }
        }

        private IWebElement ButtonMyWishes
        {
            get { return driver.FindElement(By.CssSelector(buttonMyWishesCSS)); }
        }
        #endregion

        #region Methods

        public SearchProductForWishes(IWebDriver driver) : base(driver)
        {

        }

        public MyWishesPage AddProductToWishes()
        {
            Thread.Sleep(3000);
            Click(Iphone6Sproduct1ToWishes);
            Thread.Sleep(2000);
            Click(ButtonMyWishes);
            return new MyWishesPage(driver);
        }
        #endregion
    }
}