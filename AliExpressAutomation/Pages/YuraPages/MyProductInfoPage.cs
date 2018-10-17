using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pages.EvgenPages;
using static Pages.HelpClasses.HelpPage;

namespace Pages.YuraPages
{
    public class MyProductInfoPage : SearchStringPage
    {
        public MyProductInfoPage(IWebDriver dr) : base(dr) { }

        #region Constants
        public readonly string idBundle = "#sku-1-200003982 > span";
        public readonly string idBundle2 = "#sku-1-200003985 > span";
        public readonly string CssSelectorColour = "#sku-2-691 > img";
        public readonly string CssSelectorColour2 = "#sku-2-29 > img";
        public readonly string CssSelectorQantity = "#j-product-quantity-info > dd > div.quantity-info-main > span.p-quantity-modified > i.p-quantity-increase";
        public readonly string idbuttonAddtoCard = "#j-add-cart-btn";
        public readonly string idButtonContinueShoping = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-add-shopcart-dialog > div > div.ui-feedback.ui-feedback-simple > div > div > div > button";
        public readonly string CssSelectorViewShopCard = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-add-shopcart-dialog > div > div.ui-feedback.ui-feedback-simple > div > div > div > a";
        public readonly string idMenuCurrency = "#switcher-info > span.currency";
        public readonly string CssSelectorCountry = "#nav-global > div.ng-item.ng-switcher.active > div > div > div.switcher-shipto.item.util-clearfix > div > div.link-fake-selector > div > span > span";
        public readonly string NameCountry = "#nav-global > div.ng-item.ng-switcher.active > div > div > div.switcher-shipto.item.util-clearfix > div > div.list-container > a:nth-child(3) > span > span";
        public readonly string CssSelectorCurrency = "#nav-global > div.ng-item.ng-switcher.active > div > div > div.switcher-currency.item.util-clearfix > div > span > a";
        public readonly string Currency = "#nav-global > div.ng-item.ng-switcher.active > div > div > div.switcher-currency.item.util-clearfix > div > ul > li:nth-child(9) > a";
        public readonly string CssSelectorButtonSave = "#nav-global > div.ng-item.ng-switcher.active > div > div > div.switcher-btn.item.util-clearfix > button";
        #endregion

        #region WebElements
        public IWebElement ClickBundle
        {
            get { return driver.FindElement(By.CssSelector(idBundle)); }
        }

        public IWebElement ClickBundle2
        {
            get { return driver.FindElement(By.CssSelector(idBundle2)); }
        }

        public IWebElement ClickColour
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorColour)); }
        }

        public IWebElement ClickColour2
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorColour2)); }
        }

        //public IWebElement ClickQantity
        //{
        //    get { return driver.FindElement(By.Id(CssSelectorQantity)); }
        //}
        public IWebElement buttonAddtoCard
        {
            get { return driver.FindElement(By.CssSelector(idbuttonAddtoCard)); }
        }

        public IWebElement buttonContinueShoping
        {
            get { return driver.FindElement(By.CssSelector(idButtonContinueShoping)); }
        }

        public IWebElement MenuCurrency
        {
            get { return driver.FindElement(By.CssSelector(idMenuCurrency)); }
        }

        public IWebElement DropListCounty
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorCountry)); }
        }

        public IWebElement DropListCurrency
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorCurrency)); }
        }

        public IWebElement buttonSave
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorButtonSave)); }
        }

        public IWebElement buttonViewShopInfo
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorViewShopCard)); }
        }
        public IWebElement buttonCurrency
        {
            get { return driver.FindElement(By.CssSelector(Currency)); }
        }

        public IWebElement buttonCountry
        {
            get { return driver.FindElement(By.CssSelector(NameCountry)); }
        }
        #endregion

        #region Methods for test
        public ShoppingCartPage NextPage()
        {
            Thread.Sleep(5000);
            foreach (string handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
            }
            Thread.Sleep(2000);
            Click(ClickBundle);
            Thread.Sleep(2000);
            Click(ClickColour);
            Thread.Sleep(2000);
            //Click(ClickQantity);
            Click(buttonAddtoCard);
            Thread.Sleep(2000);
            Click(buttonContinueShoping);
            Thread.Sleep(2000);

            Click(MenuCurrency);
            Thread.Sleep(2000);
            Click(DropListCounty);
            Thread.Sleep(2000);
            Click(buttonCountry);
            Thread.Sleep(2000);
            Click(DropListCurrency);
            Thread.Sleep(2000);
            Click(buttonCurrency);
            Thread.Sleep(2000);
            Click(buttonSave);
            Thread.Sleep(2000);

            Click(ClickBundle2);
            Thread.Sleep(2000); ;
            Click(ClickColour2);
            Thread.Sleep(2000);
            Click(buttonAddtoCard);
            Thread.Sleep(2000);
            Click(buttonViewShopInfo);
            Thread.Sleep(2000);

            return new ShoppingCartPage(driver);
        }
        #endregion
    }
}
