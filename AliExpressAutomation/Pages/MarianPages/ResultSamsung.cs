using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class ResultSamsung : SuperPage
    {
        public ResultSamsung(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string sams6 = "#limage_32528638346";
        private const string sams7 = "#limage_32775278157";
        private const string sams8 = "#limage_32846412268";
        #endregion

        #region webElements
               
        private IWebElement Sams6
        {
            get { return driver.FindElement(By.CssSelector(sams6)); }
        }

        private IWebElement Sams7
        {
            get { return driver.FindElement(By.CssSelector(sams7)); }
        }

        private IWebElement Sams8
        {
            get { return driver.FindElement(By.CssSelector(sams8)); }
        }

        #endregion

        #region 

        public Samsung6 GoSams6()
        {
            Thread.Sleep(3000);
            Click(Sams6);
            Thread.Sleep(1000);
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                driver.SwitchTo().Window(tabs[0]);
                Thread.Sleep(2000);
                driver.Close();                
                Thread.Sleep(2000);
                foreach (string handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                }
            }

            return new Samsung6(driver);
            
        }
        
        public Samsung7 GoSams7()
            {
            Thread.Sleep(3000);
            Click(Sams7);
            Thread.Sleep(1000);
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                driver.SwitchTo().Window(tabs[0]);
                Thread.Sleep(2000);
                driver.Close();
                Thread.Sleep(2000);
                foreach (string handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                }
            }
            return new Samsung7(driver);
            }

        public Samsung8 GoSams8()
            {
            Thread.Sleep(3000);
            Click(Sams8);
            Thread.Sleep(1000);
            var tabs = driver.WindowHandles;
            if (tabs.Count > 1)
            {
                driver.SwitchTo().Window(tabs[0]);
                Thread.Sleep(2000);
                driver.Close();
                Thread.Sleep(2000);
                foreach (string handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                }
            }
            return new Samsung8(driver);
            }

            #endregion
        
    }
}
