using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VasylPages
{
    public class MyCartPage : SuperPage
    {
        public MyCartPage(IWebDriver driver) : base(driver)
        {
        }

        #region Constans
        private readonly string idLanguage = "switcher-language-info";
        private readonly string cssLanguageFrance = "#nav-global > div.ng-item.ng-switcher.ng-switcher-language.active > div > ul > li:nth-child(4) > a";
        private readonly string cssRemoveAll = "#page > div.util-clearfix > div > div.bottom-info.util-clearfix > div.bottom-info-left > form > a";
        private readonly string cssOk = "body > div.ui-window.ui-window-normal.ui-window-transition > div > div.ui-window-btn > input.ui-button.ui-button-primary.ui-button-medium";
        #endregion

        #region IWebElements
        private IWebElement LanguageDropList
        {
            get
            {
                return driver.FindElement(By.Id(idLanguage));
            }
        }

        private IWebElement LanguageFrance
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssLanguageFrance));
            }
        }

        private IWebElement RemoveAll
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssRemoveAll));
            }
        }

        private IWebElement ButtonOk
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssOk));
            }
        }
        #endregion

        public void RemoveCart()
        {
            Thread.Sleep(5000);
            Click(RemoveAll);
            Thread.Sleep(2000);
            Click(ButtonOk);
            Thread.Sleep(2000);
            Assert.Pass();
        } 

        public MyFranceMainPage Nextpage()
        {
            Thread.Sleep(2000);
            Click(LanguageDropList);
            Thread.Sleep(2000);
            Click(LanguageFrance);
            Thread.Sleep(2000);
            return new MyFranceMainPage(driver);
        }
    }
}
