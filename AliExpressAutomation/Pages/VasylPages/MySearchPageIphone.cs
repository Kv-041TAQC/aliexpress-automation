using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pages.VasylPages
{
    public class MySearchPageIphone : SuperPage
    {
        public MySearchPageIphone(IWebDriver driver) : base(driver)
        {
        }

        #region ConstantID
        private readonly string idImage= "limage_32726463724";
        #endregion

        #region WebElemebts
        private IWebElement Image {
            get
            {
                return driver.FindElement(By.Id(idImage));
            }
        }
        #endregion

        public MyGoodsIphonePage NextPage()
        {
            Thread.Sleep(5000);
            Click(Image);
            return new MyGoodsIphonePage(driver);
        } 
    }
}
