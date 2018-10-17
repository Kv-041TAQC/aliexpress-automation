using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pages.VasylPages
{
    public class MySearchPageFrance : SuperPage
    {
        public MySearchPageFrance(IWebDriver driver) : base(driver)
        {
        }

        #region ConstantID
        private readonly string idImage = "limage_32757043166";
        #endregion

        #region WebElemebts
        private IWebElement Image
        {
            get
            {
                return driver.FindElement(By.Id(idImage));
            }
        }
        #endregion

        public MyGoodsFrancePage NextPage()
        {
            Thread.Sleep(2000);
            Click(Image);
            return new MyGoodsFrancePage(driver);
        }
    }
}
