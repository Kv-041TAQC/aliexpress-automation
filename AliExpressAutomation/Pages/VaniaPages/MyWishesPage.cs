using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class MyWishesPage : SuperPage
    {

        #region ConstantIdButtonsAndFieldsForAddressPageEmployer
        protected readonly string createNewListId = "switchWishListBtn";
        protected readonly string iphoneCSSproduct1 = "body > div.me-main.util-clearfix.wish-list > div.container > div.content > ul > li:nth-child(3) > div.action > a.me-icons.move.js-move";
        protected readonly string iphoneCSSproduct2 = "body > div.me-main.util-clearfix.wish-list > div.container > div.content > ul > li:nth-child(2) > div.action > a.me-icons.move.js-move";
        protected readonly string iphoneCSSproduct3 = "body > div.me-main.util-clearfix.wish-list > div.container > div.content > ul > li:nth-child(1) > div.action > a.me-icons.move.js-move";
        protected readonly string buttonMyWishesCSS = "#header > div > div.hm-right > div.nav-wishlist";
        protected readonly string newListName = "IPhone 6s";
        protected readonly string currentIphoneList = "body > div.me-main.util-clearfix.wish-list > div.me-left-nav-bar > div.left-nav-list > dl > dd:nth-child(2) > a > em";
        #endregion

        public MyWishesPage(IWebDriver driver) : base(driver)
        {

        }

        #region FindWebElementFromIdForAddressPageEmployer
        protected IWebElement searchiphone6Sproduct1
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct1)); }
        }

        protected IWebElement searchiphone6Sproduct2
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct2)); }
        }

        protected IWebElement searchiphone6Sproduct3
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct3)); }
        }

        protected IWebElement searchButtonCreateNewList
        {
            get { return driver.FindElement(By.Id(createNewListId)); }
        }

        protected IWebElement searchCurrentIphoneList
        {
            get { return driver.FindElement(By.CssSelector(currentIphoneList)); }
        }
        #endregion

        public CreatingNewListWishesPage MyWishesCreateList()
        {
            MaximizeWindow();
            Thread.Sleep(2000);
            Click(searchButtonCreateNewList);
            return new CreatingNewListWishesPage(driver);
        }
    }
}
