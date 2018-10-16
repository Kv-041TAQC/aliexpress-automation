using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using System.Threading;
using Pages.YuraPages;
using OpenQA.Selenium;

namespace Test
{
    [TestFixture]
    public class Test_Yura
    {
        [Test]
        public void DifferentCurrency()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(),opt))
            {
                var mainPage = new MainPage(dr);
                var searchPage = mainPage.NextPage();
                var productinfo = searchPage.NextPage();
                var cartPage = productinfo.NextPage();
                cartPage.RemoveCart();
            }
        }
    }
}