using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pages.VasylPages
{
    public class MyGoodsIphonePage : SuperPage
    {
        public MyGoodsIphonePage(IWebDriver driver) : base(driver)
        {
        }

        #region Constans
        private readonly string cssBundleEnglish = "#sku-1-200003985 > span";
        private readonly string cssColorEnglish = "#sku-2-350853 > img";
        private readonly string idCartEnglish = "j-add-cart-btn";
        private readonly string cssGoCartEnglish = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-add-shopcart-dialog > div > div.ui-feedback.ui-feedback-simple > div > div > div > a";

        private readonly string cssBundleFrance = "#sku-1-200003982";
        private readonly string cssColorFrance = "#sku-2-691";
        private readonly string idCartFrance = "j-add-cart-btn";
        private readonly string cssGoCartFrance = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-add-shopcart-dialog > div > div.ui-feedback.ui-feedback-simple > div > div > div > a";

        #endregion

        #region IWebElements
        private IWebElement BundleButtonEnglish
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssBundleEnglish));
            }
        }

        private IWebElement ColorButtonEnglish
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssColorEnglish));
            }
        }

        private IWebElement CartButtonEnglish
        {
            get
            {
                return driver.FindElement(By.Id(idCartEnglish));
            }
        }

        private IWebElement GoCartButtonEnglish
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssGoCartEnglish));
            }
        }

        private IWebElement BundleButtonFrance
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssBundleFrance));
            }
        }

        private IWebElement ColorButtonFrance
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssColorFrance));
            }
        }

        private IWebElement CartButtonFrance
        {
            get
            {
                return driver.FindElement(By.Id(idCartFrance));
            }
        }

        private IWebElement GoCartButtonFrance
        {
            get
            {
                return driver.FindElement(By.CssSelector(cssGoCartFrance));
            }
        }
        #endregion

        public MyCartPage NextPageEnglish()
        {
            Thread.Sleep(3000);
            foreach (string handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
            }
            Thread.Sleep(5000);
            Click(BundleButtonEnglish);
            Thread.Sleep(2000);
            Click(ColorButtonEnglish);
            Thread.Sleep(5000);
            Click(CartButtonEnglish);
            Thread.Sleep(5000);
            Click(GoCartButtonEnglish);
            return new MyCartPage(driver);
        }

        public MyCartPage NextPageFrance()
        {
            Thread.Sleep(3000);
            foreach (string handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
            }
            Thread.Sleep(5000);
            Click(BundleButtonFrance);
            Thread.Sleep(2000);
            Click(ColorButtonFrance);
            Thread.Sleep(5000);
            Click(CartButtonFrance);
            Thread.Sleep(5000);
            Click(GoCartButtonFrance);
            return new MyCartPage(driver);
        }
    }
}
