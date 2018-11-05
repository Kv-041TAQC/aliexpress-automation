using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.TopSaling
{
    public class SearchPage3 : SearchPage1
    {
        private string test = "# search-key";
        private IWebElement Test => driver.FindElement(By.CssSelector(test));


        public SearchPage3(IWebDriver driver) : base(driver) { }

        public void WriteTopPhones()
        {
            FindAndWriteTopPhones();
            SendText(Test, Convert.ToString(countPhone));
            Thread.Sleep(3000);
        }
    }
}
