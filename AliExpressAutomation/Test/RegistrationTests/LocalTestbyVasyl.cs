using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.VasylPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests.RegistrationTests
{
    [TestFixture]
    [Parallelizable]
    public class LocalTestbyVasyl
    {
        [Test]
        public void LocalTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var mainPage = new MyMainPage(dr);
                var searchPage = mainPage.NextPage();
                var goodsPage = searchPage.NextPage();
                var cartPage = goodsPage.NextPage();
                var franceMainPage = cartPage.Nextpage();
                var franceSearchPage = franceMainPage.NextPage();
                var franceGoodsPage = franceSearchPage.NextPage();
                cartPage = franceGoodsPage.NextPage();
                cartPage.RemoveCart();
            }
        }
    }
}
