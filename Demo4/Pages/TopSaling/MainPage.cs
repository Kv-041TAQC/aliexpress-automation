using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pages.HelpClass;

namespace Pages.TopSaling
{
    /// <summary>
    /// <para>Class of Main page Aliexpress</para>
    /// </summary>
    public class MainPage : SuperPage
    {
        #region ConstantsForMainPage
        private readonly string urlAliexpress = "https://ru.aliexpress.com";
        private readonly string selectorCloseAdvertising = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        private readonly string CssSelectorbtnCategories = "#home-firstscreen > div > div > div.categories > div > div.categories-content-title > span.site-categories-title";
        private readonly string CssSelectorbtnCellphones = "#home-firstscreen > div > div > div.categories > div > div.categories-list-box > dl.cl-item.cl-item-phones > dt > span > a:nth-child(1)";
        private readonly string CssSelectorEnglishWeb = "#nav-global > div.ng-item.ng-goto-globalsite > a";

        #endregion

        #region Methods
        /// <summary>
        /// <para>Method for go to main page Aliexpress</para>
        /// </summary>
        /// <param name="driver">Web Driver.</param>
        public MainPage(IWebDriver driver) : base(driver) { }


        /// <summary>
        /// <para>Method for go to main page Aliexpress</para>
        /// </summary>
        public void GoToMainPage()
        {
            driver.Manage().Window.FullScreen();
            NavigateToUrl(urlAliexpress);
        }

        /// <summary>
        /// <para>Method for close advertasing</para>
        /// </summary>
        public void CloseAdvertasing()
        {
                Click(CssSearchWebElements(selectorCloseAdvertising));
        }

        /// <summary>
        /// <para>Method for go to english main page Aliexpress and go to list of goods</para>
        /// </summary>
        public SearchPage1 GoToTheSearchPhones()
        {
            Click(CssSearchWebElements(CssSelectorEnglishWeb));
            // Click(CssSearchWebElements(CssSelectorbtnCategories));
            Click(CssSearchWebElements(CssSelectorbtnCellphones));
            return new SearchPage1(driver);
        }
        #endregion
    }
}
