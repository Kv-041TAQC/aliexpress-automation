﻿using OpenQA.Selenium;
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
        private readonly string iphoneCSSproduct2 = "#hs-list-items > li:nth-child(2) > div.right-block.util-clearfix > div > div.info.infoprice > div.add-to-wishlist > a";
        private readonly string iphoneCSSproduct3 = "#hs-list-items > li:nth-child(3) > div.right-block.util-clearfix > div > div.info.infoprice > div.add-to-wishlist > a";
        private readonly string buttonMyWishesCSS = "#header > div > div.hm-right > div.nav-wishlist";

        #endregion

        #region FindWebElement
        private IWebElement searchiphone6Sproduct1
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct1)); }
        }

        private IWebElement searchiphone6Sproduct2
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct2)); }
        }

        private IWebElement searchiphone6Sproduct3
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct3)); }
        }

        private IWebElement searchbuttonMyWishes
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
            Thread.Sleep(4000);
            Click(searchiphone6Sproduct1);
            //Thread.Sleep(4000);
            //Click(searchiphone6Sproduct2);
            //Thread.Sleep(4000);
            //Click(searchiphone6Sproduct3);
            Thread.Sleep(4000);
            Click(searchbuttonMyWishes);
            return new MyWishesPage(driver);
        }
        #endregion
    }
}