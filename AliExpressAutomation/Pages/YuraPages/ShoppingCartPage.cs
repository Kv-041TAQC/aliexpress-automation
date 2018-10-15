using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.EvgenPages;
using static Pages.HelpClasses.HelpPage;

namespace Pages.YuraPages
{
    public class ShoppingCartPage : SearchStringPage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver) { }

        private readonly string cssRemoveAll = "#page > div.util-clearfix > div > div.bottom-info.util-clearfix > div.bottom-info-left > form > a";

        private IWebElement RemoveAll
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssRemoveAll));
            }
        }
        public void RemoveCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            Click(RemoveAll);
        }
    }

}
