using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.TopSaling
{
    public class SearchPage3 : SearchPage1
    {
        public SearchPage3(IWebDriver driver) : base(driver) { }

        private IWebElement ButtonThirdPage => driver.FindElement(By.CssSelector("yura_loh"));
        public void WriteTopPhones()
        {
            FindAndWriteTopPhones();
            Click(ButtonThirdPage);
        }
    }
}
