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
        private IWebElement ButtonThirdPage123 => driver.FindElement(By.CssSelector("pd"));

        public void WriteTopPhones()
        {
            FindAndWriteTopPhones();
            Click(ButtonThirdPage123);
        }
    }
}
