using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VaniaPages
{
    public class MainPageAliexpressAutorized : MainPageAliexpress
    {
        public MainPageAliexpressAutorized(IWebDriver dr) : base(dr)
        {

        }

        public SearchProductForWishes SearchProduct()
        {
            InputCorrectData(0);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new SearchProductForWishes(driver);
        }
    }
}
