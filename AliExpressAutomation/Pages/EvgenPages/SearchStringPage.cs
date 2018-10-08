using System;
using System.Threading;
using OpenQA.Selenium;
using static Pages.HelpClasses.HelpPage;

namespace Pages.EvgenPages
{
    //Positive and negative test of the search string
    public class SearchStringPage : SuperPage
    {
        public SearchStringPage(IWebDriver dr) : base(dr)
        {
            currentjson = alijson;
        }
        #region Constants and WebElements
        private JsonHandlerClass currentjson;
        private IWebElement SearchField { get { return driver.FindElement(By.Id("search-key")); } }
        private IWebElement CloseAdvertising { get { return driver.FindElement(By.CssSelector("body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a")); }}
        #endregion
        #region Methods for test
        private void InputCorrectData()
        {
            Click(CloseAdvertising);
            SendText(SearchField, "Correct data");
        }
        private void InputInvalidData()
        {
            SendText(SearchField, "Invalid data");
        }
        public void RunPostiveTest()
        {
            NavigateToUrl("https://ru.aliexpress.com");
            InputCorrectData();
        }
        public void RunNegativeTest()
        {
            NavigateToUrl("https://ru.aliexpress.com");
            InputInvalidData();
        }
        #endregion
    }
}
