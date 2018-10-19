using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pages.EvgenPages;
using static Pages.HelpClasses.HelpPage;

namespace Pages.YuraPages
{
    public class SearchPage : SearchStringPage
    {
        public SearchPage(IWebDriver dr) : base(dr) { }

        #region Constants
        public readonly string idClickImage = "#limage_32726463724";
        #endregion

        #region Constants
        public IWebElement ClickImage
        {
            get { return driver.FindElement(By.CssSelector(idClickImage)); }
        }
        #endregion
        
        #region Methods
        public MyProductInfoPage NextPage()
        {
            Thread.Sleep(2000);
            Click(ClickImage);
            Thread.Sleep(2000);
            return new MyProductInfoPage(driver);
        }
        #endregion
    }

}
