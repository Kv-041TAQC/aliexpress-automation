using System;
using System.Threading;
using NUnit.Framework;
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
        protected IWebElement SearchField { get { return driver.FindElement(By.Id("search-key")); } }
        private IWebElement CloseAdvertising { get { return driver.FindElement(By.CssSelector("body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a")); }}
        protected IWebElement SearchButton{ get { return driver.FindElement(By.CssSelector("#form-searchbar > div.searchbar-operate-box > input")); }}
        private IWebElement WarningWindow{ get { return driver.FindElement(By.CssSelector("#main-wrap > p > span")); } }
        private bool result = false;
        #endregion
        #region Methods for test
        protected void InputCorrectData(int index)
        {
            SendText(SearchField, currentjson.ValidData[index]);
        }
        private void InputInvalidData(int index)
        {
            SendText(SearchField, currentjson.InvalidData[index]);
        }
        /// <summary>
        /// Runs the postive test.In param send index of valid data in array
        /// </summary>
        /// <param name="NumberOfTest">Number of test.</param>
        public void RunPostiveTest(int NumberOfTest)
        {
            NavigateToUrl("https://ru.aliexpress.com");
            Thread.Sleep(2000);
            //ScreenSizeSettings(2560, 1600);
            driver.Manage().Window.FullScreen();
            Thread.Sleep(12000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            InputCorrectData(NumberOfTest);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            try{
                result = WarningWindow.Displayed;
            }
            catch(NoSuchElementException)
            {
                Assert.Pass();
            }
        }
        /// <summary>
        /// Runs the negative test.In param send index of invalid data in array
        /// </summary>
        /// <param name="NumberOfTest">Number of test.</param>
        public void RunNegativeTest(int NumberOfTest)
        {
            NavigateToUrl("https://ru.aliexpress.com");
            Thread.Sleep(2000);
            //ScreenSizeSettings(2560, 1600);
            driver.Manage().Window.FullScreen();
            Thread.Sleep(12000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            InputInvalidData(NumberOfTest);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            Assert.IsTrue(WarningWindow.Displayed);
        }
        #endregion
    }
}