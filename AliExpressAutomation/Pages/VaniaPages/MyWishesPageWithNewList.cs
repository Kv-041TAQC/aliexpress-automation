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
        protected readonly string buttonExit = "#userAccountInfo";
        protected readonly string buttonNewList = "# otherWishList > li > a";
        protected readonly string chooseExit = "Выйти";
        #endregion

        #region FindWebElement
        protected IWebElement searchButtonExit
        {
            get { return driver.FindElement(By.CssSelector(iphoneCSSproduct1)); }
        }

        protected IWebElement searchAddToNewList
        {
            get { return driver.FindElement(By.CssSelector(buttonNewList)); }
        }
        #endregion

        #region Methods
        public MyWishesPageWithNewList(IWebDriver driver) : base(driver)
        {

        }

        public void MyWishesAddProductToList()
        {
            Thread.Sleep(5000);
            Click(searchiphone6Sproduct1);
            Thread.Sleep(3000);
            Click(searchAddToNewList);
            //Thread.Sleep(5000);
            //Click(searchiphone6Sproduct2);
            //SelectDropDown(searchiphone6Sproduct2, newListName);
            //Thread.Sleep(5000);
            //Click(searchiphone6Sproduct3);
            //SelectDropDown(searchiphone6Sproduct3, newListName);
            //Thread.Sleep(5000);
            //Click(searchCurrentIphoneList);
            Thread.Sleep(7000);
            Click(searchButtonExit);
            Thread.Sleep(3000);
            SelectDropDown(searchButtonExit, chooseExit);
            Assert.Pass();
        }
        #endregion
    }
}
