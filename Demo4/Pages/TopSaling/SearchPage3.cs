using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.TopSaling
{
    /// <summary>
    /// <para>Class of third search page with goods in Aliexpress website</para>
    /// </summary>
    public class SearchPage3 : SearchPage1
    {
        #region Constructor
        /// <summary>
        /// <para>Method for go to main page Aliexpress</para>
        /// </summary>
        /// <param name="driver">Web Driver.</param>
        public SearchPage3(IWebDriver driver) : base(driver) { }
        #endregion
    }
}
