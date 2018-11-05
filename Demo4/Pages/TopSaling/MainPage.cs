using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.TopSaling
{
    public class MainPage : SuperPage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        #region Constants
        private readonly string urlAliexpress = "https://ru.aliexpress.com";
        private readonly string selectorCloseAdvertising = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        private readonly string CssSelectorbtnCategories = "#home-firstscreen > div > div > div.categories > div > div.categories-content-title > span.site-categories-title";
        private readonly string CssSelectorbtnCellphones = "#home-firstscreen > div > div > div.categories > div > div.categories-list-box > dl.cl-item.cl-item-phones > dt > span > a:nth-child(1)";
        private readonly string CssSelectorEnglishWeb = "#nav-global > div.ng-item.ng-goto-globalsite > a";

        #endregion

        #region WebElements
        private IWebElement CloseAdvertising => driver.FindElement(By.CssSelector(selectorCloseAdvertising));
        private IWebElement BtnCategories => driver.FindElement(By.CssSelector(CssSelectorbtnCategories));
        private IWebElement BtnCellphoens => driver.FindElement(By.CssSelector(CssSelectorbtnCellphones));
        private IWebElement ButtonLanguage => driver.FindElement(By.CssSelector(CssSelectorEnglishWeb));

        #endregion

        #region Methods

        public SearchPage1 GoToTheSearchPhones()
        {
            driver.Manage().Window.FullScreen();
            NavigateToUrl(urlAliexpress);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            Click(ButtonLanguage);
            Click(BtnCategories);
            Click(BtnCellphoens);
            return new SearchPage1(driver);
        }

        #endregion
    }
}
