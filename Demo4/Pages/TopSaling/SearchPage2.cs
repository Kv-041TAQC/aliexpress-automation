using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Pages.TopSaling
{
    /// <summary>
    /// <para>Class of second search page with goods in Aliexpress website</para>
    /// </summary>
    public class SearchPage2 : SearchPage1
    {   
        #region Constants
        private string cssButtonThirdPage = "#pagination-bottom > div.ui-pagination-navi.util-left > a:nth-child(4)";
        #endregion

        #region Methods
        /// <summary>
        /// <para>Method for go to main page Aliexpress</para>
        /// </summary>
        /// <param name="driver">Web Driver.</param>
        public SearchPage2(IWebDriver driver) : base(driver){}

        /// <summary>
        /// <para>Method for go to next page of goods</para>
        /// </summary>
        public SearchPage3 GoToThirdPage()
        {
            Click(CssSearchWebElements(cssButtonThirdPage));
            return new SearchPage3(driver);
        }

        #endregion
    }
}
