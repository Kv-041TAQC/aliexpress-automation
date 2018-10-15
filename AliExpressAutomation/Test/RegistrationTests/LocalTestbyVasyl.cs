using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages.VasylPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests.RegistrationTests
{
    [TestFixture]
    public class LocalTestbyVasyl
    {
        [Test]
        public void LocalTest()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
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
