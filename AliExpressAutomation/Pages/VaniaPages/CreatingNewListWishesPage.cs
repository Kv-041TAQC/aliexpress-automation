using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class CreatingNewListWishesPage : SuperPage
    {
        #region ConstantButtonsAndFields
        private readonly string nameNewList = "#j-create-wishlist-dialog > div > div.ui-window-content > div > div.wish-list-name.js-tips > input";
        private readonly string buttonSave = "#j-create-wishlist-dialog > div > div.ui-window-btn > input.ui-button.ui-button-primary.ui-button-medium";
        #endregion

        #region FindWebElement
        private IWebElement NameNewList
        {
            get { return driver.FindElement(By.CssSelector(nameNewList)); }
        }

        private IWebElement ButtonSave
        {
            get { return driver.FindElement(By.CssSelector(buttonSave)); }
        }

        #endregion

        #region Method

        public CreatingNewListWishesPage(IWebDriver driver) : base(driver)
        {

        }

        public void EnterDataTrue()
        {
            NameNewList.Clear();
            SendText(NameNewList, alijson.Wishes[0]);
        }

        public void EnterDataFalse()
        {
            NameNewList.Clear();
            SendText(NameNewList, alijson.Wishes[1]);
        }

        public MyWishesPageWithNewList CreateNewList(bool correctData)
        {
            Thread.Sleep(2000);
            if (correctData)
                EnterDataTrue();
            else
                EnterDataFalse();
            Click(ButtonSave);
            return new MyWishesPageWithNewList(driver);
        }
        #endregion
    }
}