using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VasylPages
{
        public class MyGoodsFrancePage : SuperPage
        {
            public MyGoodsFrancePage(IWebDriver driver) : base(driver)
            {
            }

            #region Constans
            private readonly string cssBundle = "#sku-1-200003982";
            private readonly string cssColor = "#sku-2-691";
            private readonly string idCart = "j-add-cart-btn";
            private readonly string cssGoCart = "body > div.ui-window.ui-window-normal.ui-window-transition.ui-add-shopcart-dialog > div > div.ui-feedback.ui-feedback-simple > div > div > div > a";

            #endregion

            #region IWebElements
            private IWebElement BundleButton
            {
                get
                {
                    return driver.FindElement(By.CssSelector(cssBundle));
                }
            }

            private IWebElement ColorButton
            {
                get
                {
                    return driver.FindElement(By.CssSelector(cssColor));
                }
            }

            private IWebElement CartButton
            {
                get
                {
                    return driver.FindElement(By.Id(idCart));
                }
            }

            private IWebElement GoCartButton
            {
                get
                {
                    return driver.FindElement(By.CssSelector(cssGoCart));
                }
            }
            #endregion

            public MyCartPage NextPage()
            {
                Thread.Sleep(3000);
                foreach (string handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                }
                Thread.Sleep(5000);
                Click(BundleButton);
                Thread.Sleep(2000);
                Click(ColorButton);
                Thread.Sleep(5000);
                Click(CartButton);
                Thread.Sleep(5000);
                Click(GoCartButton);
                return new MyCartPage(driver);
            }
        }
}
