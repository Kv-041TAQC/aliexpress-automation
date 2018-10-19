using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.EvgenPages;
using static Pages.HelpClasses.HelpPage;

namespace Pages.YuraPages
{
    public class ShoppingCartPage : SearchStringPage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver) { }

        #region Constants
        private readonly string cssRemoveAll = "#page > div.util-clearfix > div > div.bottom-info.util-clearfix > div.bottom-info-left > form > a";
        private readonly string cssbuttonOk = "body > div.ui-window.ui-window-normal.ui-window-transition > div > div.ui-window-btn > input.ui-button.ui-button-primary.ui-button-medium";
        #endregion
       
        #region WebElements
        private IWebElement RemoveAll
        {
            get{return driver.FindElement(By.CssSelector(cssRemoveAll));}
        }

        private IWebElement buttonOk
        {
            get { return driver.FindElement(By.CssSelector(cssbuttonOk)); }
        }
        #endregion
        
        #region Methods
        public void RemoveCart()
        {
            Thread.Sleep(5000);
            Click(RemoveAll);
            Click(buttonOk);
        }
        #endregion
    }

}
