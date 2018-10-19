using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class ResultIPhone : SuperPage
    {
        public ResultIPhone(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string ipho6 = "#limage_32831607745";
        private const string ipho6s = "#limage_32726463724";
        private const string ipho7 = "#limage_32846486845";
        #endregion

        #region webElements
               
        private IWebElement Ipho6
        {
            get { return driver.FindElement(By.CssSelector(ipho6)); }
        }

        private IWebElement Ipho6s
        {
            get { return driver.FindElement(By.CssSelector(ipho6s)); }
        }

        private IWebElement Ipho7
        {
            get { return driver.FindElement(By.CssSelector(ipho7)); }
        }

        #endregion

        #region 

        public IPhone6 GoIPhone6()
        {
            Thread.Sleep(3000);
            Click(Ipho6);
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

            return new IPhone6(driver);
            
        }
        
        public IPhone6S GoIPhone6s()
            {
            Thread.Sleep(3000);
            Click(Ipho6s);
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
            return new IPhone6S(driver);
            }

        public IPhone7 GoIPhone7()
            {
            Thread.Sleep(3000);
            Click(Ipho7);
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
            return new IPhone7(driver);
            }

            #endregion
        
    }
}
