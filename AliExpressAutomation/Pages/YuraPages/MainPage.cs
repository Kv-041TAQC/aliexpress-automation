using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pages.EvgenPages;
using static Pages.HelpClasses.HelpPage;

namespace Pages.YuraPages
{
    public class MainPage : SuperPage
    {
        public MainPage(IWebDriver driver) : base(driver) { }
        private void InputCorrectData(int index)
        {
            SendText(SearchField, "IPhone 6s");
        }

        #region Constatnts
        public readonly string idButtonLanguage = "#nav-global > div.ng-item.ng-goto-globalsite > a";
        public readonly string idSearchField = "search-key";
        public readonly string selectorCloseAdvertising = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a";
        public readonly string selecctorButtonSearch = "#form-searchbar > div.searchbar-operate-box > input";
        public readonly string selectorButtonLanguage = "#nav-global > div.ng-item.ng-goto-globalsite > a";
        public readonly string selectorWarningWindow = "#main-wrap > p > span";
        #endregion

        #region WebElements
        private IWebElement SearchField { get { return driver.FindElement(By.Id(idSearchField)); } }
        private IWebElement CloseAdvertising { get { return driver.FindElement(By.CssSelector(selectorCloseAdvertising)); } }
        private IWebElement SearchButton { get { return driver.FindElement(By.CssSelector(selecctorButtonSearch)); } }
        private IWebElement WarningWindow { get { return driver.FindElement(By.CssSelector(selectorWarningWindow)); } }
        public IWebElement buttonLanguage { get { return driver.FindElement(By.CssSelector(idButtonLanguage)); } }
        #endregion

        #region Methods
        public SearchPage NextPage()
        {
            MaximizeWindow();
            NavigateToUrl("https://ru.aliexpress.com");
            Thread.Sleep(15000);
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            Thread.Sleep(2000); Thread.Sleep(3000);
            Click(buttonLanguage);
            Thread.Sleep(2000);
            InputCorrectData(1);
            Thread.Sleep(2000);
            Click(SearchButton);
            Thread.Sleep(2000);
            return new SearchPage(driver);
        }
        #endregion
    }
}
