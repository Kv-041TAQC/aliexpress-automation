using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class MyWishesPageWithNewList : MyWishesPage
    {
        #region ConstantAndButtonsAndFields
        protected readonly string buttonChoosingList = "#otherWishList > li > a";
        protected readonly string addToSomeList = "body > div.me-main.util-clearfix.wish-list > div.container > div.content > ul > li > div.action > a.me-icons.move.js-move";
        protected readonly string goToCreatedList = "body > div.me-main.util-clearfix.wish-list > div.me-left-nav-bar > div.left-nav-list > dl > dd:nth-child(2) > a > em";
        #endregion

        #region FindWebElement

        protected IWebElement ButtonAddToChoosingList
        {
            get { return driver.FindElement(By.CssSelector(buttonChoosingList)); }
        }

        protected IWebElement ButtonAddToSomeList
        {
            get { return driver.FindElement(By.CssSelector(addToSomeList)); }
        }

        protected IWebElement ButtonGoToCreatedList
        {
            get { return driver.FindElement(By.CssSelector(goToCreatedList)); }
        }
        #endregion

        #region Methods
        public MyWishesPageWithNewList(IWebDriver driver) : base(driver)
        {

        }

        public MyWishesPageInAddingList MyWishesAddProductToList()
        {
            Thread.Sleep(3000);
            Click(ButtonAddToSomeList);
            Thread.Sleep(3000);
            Click(ButtonAddToChoosingList);
            Thread.Sleep(3000);
            Click(ButtonGoToCreatedList);
            Thread.Sleep(3000);
            return new MyWishesPageInAddingList(driver);
        }
        #endregion
    }
}