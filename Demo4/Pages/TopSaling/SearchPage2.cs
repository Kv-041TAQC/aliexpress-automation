using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Pages.TopSaling
{
    public class SearchPage2 : SearchPage1
    {
        public SearchPage2(IWebDriver driver) : base(driver){}

        #region Constants
        private string cssButtonThirdPage = "#pagination-bottom > div.ui-pagination-navi.util-left > a:nth-child(4)";

        #endregion

        #region WebElements
        //private IWebElement ButtonThirdPage => driver.FindElement(By.CssSelector(cssButtonThirdPage));

        #endregion

        #region Methods
       
        public SearchPage3 GoToThirdPage()
        {
            //FindAndWriteTopPhones();
            Click(CssSearchWebElements(cssButtonThirdPage));
            return new SearchPage3(driver);
        }

        #endregion
    }
}
