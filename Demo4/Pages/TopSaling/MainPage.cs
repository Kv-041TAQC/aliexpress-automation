using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pages.HelpClass;

namespace Pages.TopSaling
{
    public class MainPage : SuperPage
    {
        #region ConstantsForMainPage
        public readonly string urlAliexpress = "https://ru.aliexpress.com";
        public readonly string selectorCloseAdvertising = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        public readonly string CssSelectorbtnCategories = "#home-firstscreen > div > div > div.categories > div > div.categories-content-title > span.site-categories-title";
        public readonly string CssSelectorbtnCellphones = "#home-firstscreen > div > div > div.categories > div > div.categories-list-box > dl.cl-item.cl-item-phones > dt > span > a:nth-child(1)";
        public readonly string CssSelectorEnglishWeb = "#nav-global > div.ng-item.ng-goto-globalsite > a";

        #endregion


        public MainPage(IWebDriver driver) : base(driver) { }

        #region WebElements
        /* private IWebElement CloseAdvertising => driver.FindElement(By.CssSelector(selectorCloseAdvertising));
         private IWebElement ButtonCategories => driver.FindElement(By.CssSelector(CssSelectorbtnCategories));
         private IWebElement ButtonCellphoens => driver.FindElement(By.CssSelector(CssSelectorbtnCellphones));
         private IWebElement ButtonLanguage => driver.FindElement(By.CssSelector(CssSelectorEnglishWeb));
         **/
        #endregion

        #region Methods
        public void GoToEnglishMainPage()
        {
            driver.Manage().Window.FullScreen();
            NavigateToUrl(urlAliexpress);
        }

        public void CloseAdvertasing()
        {
                Click(CssSearchWebElements(selectorCloseAdvertising));
        }


        public SearchPage1 GoToTheSearchPhones()
        {
            Click(CssSearchWebElements(CssSelectorEnglishWeb));
            Click(CssSearchWebElements(CssSelectorbtnCategories));
            Click(CssSearchWebElements(CssSelectorbtnCellphones));
            return new SearchPage1(driver);
        }
        #endregion
    }
}
