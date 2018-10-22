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

        #region ConstantIdButtonsAndFields
        protected readonly string createNewListId = "switchWishListBtn";
        protected readonly string iphoneCSSproduct1 = "body > div.me-main.util-clearfix.wish-list > div.container > div.content > ul > li:nth-child(3) > div.action > a.me-icons.move.js-move";
        protected readonly string buttonMyWishesCSS = "#header > div > div.hm-right > div.nav-wishlist";
        protected readonly string currentIphoneList = "body > div.me-main.util-clearfix.wish-list > div.me-left-nav-bar > div.left-nav-list > dl > dd:nth-child(2) > a > em";
        #endregion



        #region FindWebElement

        protected IWebElement ButtonCreateNewList
        {
            get { return driver.FindElement(By.Id(createNewListId)); }
        }
        #endregion

        #region Methods
        public MyWishesPage(IWebDriver driver) : base(driver)
        {

        }

        public CreatingNewListWishesPage MyWishesCreateList()
        {
            Thread.Sleep(2000);
            Click(ButtonCreateNewList);
            return new CreatingNewListWishesPage(driver);
        }
        #endregion
    }
}