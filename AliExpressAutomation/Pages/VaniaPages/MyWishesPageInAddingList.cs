using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class MyWishesPageInAddingList:SuperPage
    {
        
        #region ConstantAndButtonsAndFields
        protected readonly string buttonChoosingList = "#otherWishList > li > a";
        protected readonly string deleteToSomeList = "#editWishListBtns > button.ui-split-button-trigger.ui-button.ui-button-normal.ui-button-medium > span";
        protected readonly string goToDeleteList = "#editWishListBtns > div > ul > li.js-remove";
        protected readonly string deleteConfirm = "body > div.ui-window.ui-window-normal.ui-window-transition > div > div.ui-window-btn > input.ui-button.ui-button-primary.ui-button-medium";
        #endregion

        #region FindWebElement

        protected IWebElement ButtonAddToChoosingList
        {
            get { return driver.FindElement(By.CssSelector(buttonChoosingList)); }
        }

        protected IWebElement ButtonDeleteToSomeList
        {
            get { return driver.FindElement(By.CssSelector(deleteToSomeList)); }
        }

        protected IWebElement ButtonGoToDeleteList
        {
            get { return driver.FindElement(By.CssSelector(goToDeleteList)); }
        }

        protected IWebElement ButtonDeleteConfirm
        {
            get { return driver.FindElement(By.CssSelector(deleteConfirm)); }
        }
        #endregion

        #region Methods
        public MyWishesPageInAddingList(IWebDriver driver) : base(driver)
        {

        }

        public void MyWishesDeleteProductInList()
        {
            Thread.Sleep(3000);
            Click(ButtonDeleteToSomeList);
            Thread.Sleep(3000);
            Click(ButtonGoToDeleteList);
            Thread.Sleep(3000);
            Click(ButtonDeleteConfirm);
            Thread.Sleep(7000);
            Assert.Pass();
        }
        #endregion
    }
}

