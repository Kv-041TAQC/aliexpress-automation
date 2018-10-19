using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pages.VasylPages
{
    public class MyShoppingPage : SuperPage
    {
        public MyShoppingPage(IWebDriver driver) : base(driver)
        {
        }

        #region ConstantID
        private readonly string idImageEnglish= "limage_32726463724";
        private readonly string idImageFrance = "limage_32757043166";
        #endregion

        #region WebElemebts
        private IWebElement ImageEnglish
        {
            get
            {
                return driver.FindElement(By.Id(idImageEnglish));
            }
        }

        private IWebElement ImageFrance
        {
            get
            {
                return driver.FindElement(By.Id(idImageFrance));
            }
        }
        #endregion

        public MyGoodsIphonePage NextPageEnglish()
        {
            Thread.Sleep(5000);
            Click(ImageEnglish);
            return new MyGoodsIphonePage(driver);
        }

        public MyGoodsIphonePage NextPageFrance()
        {
            Thread.Sleep(5000);
            Click(ImageFrance);
            return new MyGoodsIphonePage(driver);
        }
    }
}
