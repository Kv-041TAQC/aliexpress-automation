using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class CreatingNewListWishesPage:SuperPage
    {
        public CreatingNewListWishesPage(IWebDriver driver) : base(driver)
        {

        }

        #region ConstantIdButtonsAndFieldsForAddressPageEmployer
        private readonly string nameNewList = "#j-create-wishlist-dialog > div > div.ui-window-content > div > div.wish-list-name.js-tips > input";
        private readonly string buttonSave = "#j-create-wishlist-dialog > div > div.ui-window-btn > input.ui-button.ui-button-primary.ui-button-medium";
        #endregion

        #region FindWebElementFromIdForAddressPageEmployer
        private IWebElement searchNameNewList
        {
            get { return driver.FindElement(By.CssSelector(nameNewList)); }
        }

        private IWebElement searchButtonSave
        {
            get { return driver.FindElement(By.CssSelector(buttonSave)); }
        }

        #endregion

        #region MethodOfAddressPageEmployer

        public void EnterDataTrue()
        {
            searchNameNewList.Clear();
            SendText(searchNameNewList, alijson.Wishes[0]);          
        }

        public void EnterDataFalse()
        {
            searchNameNewList.Clear();
            SendText(searchNameNewList, alijson.Wishes[1]);
        }

        public MyWishesPageWithNewList CreateNewList(bool correctData)
        {
            MaximizeWindow();
            Thread.Sleep(2000);
            if (correctData)
                EnterDataTrue();
            else
                EnterDataFalse();
            Click(searchButtonSave);
            return new MyWishesPageWithNewList(driver);
        }
        #endregion
    }
}
