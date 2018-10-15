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

        public readonly string idButtonLanguage = "#nav-global > div.ng-item.ng-goto-globalsite > a";


        private IWebElement SearchField { get { return driver.FindElement(By.Id("search-key")); } }
        private IWebElement CloseAdvertising { get { return driver.FindElement(By.CssSelector("body > div.ui-window.ui-window-normal.ui-window-transition.ui-newuser-layer-dialog > div > div > a")); } }
        private IWebElement SearchButton { get { return driver.FindElement(By.CssSelector("#form-searchbar > div.searchbar-operate-box > input")); } }
        private IWebElement WarningWindow { get { return driver.FindElement(By.CssSelector("#main-wrap > p > span")); } }





        public IWebElement buttonLanguage
        {
            get { return driver.FindElement(By.CssSelector(idButtonLanguage)); }
        }

        private void InputCorrectData(int index)
        {
            SendText(SearchField, "IPhone 6s");
        }

        public SearchPage NextPage()
        {
            MaximizeWindow();

            NavigateToUrl("https://ru.aliexpress.com");
            if (CloseAdvertising.Displayed)
                Click(CloseAdvertising);
            Thread.Sleep(3000);
            Click(buttonLanguage);
            
            InputCorrectData(0);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);

            Thread.Sleep(5000);
            return new SearchPage(driver);
        }  
    }
}
