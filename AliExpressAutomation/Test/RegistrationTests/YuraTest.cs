using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Pages.YuraPages;
using OpenQA.Selenium;

namespace Tests.RegistrationTests
{
    [TestFixture]
    public class YuraTest
    {
         
        [Test]
        public void DifferentCurrency()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), opt))
            {
                var mainPage = new MainPage(dr);
                var searchPage = mainPage.NextPage();
                var productinfo = searchPage.NextPage();
                var cartPage = productinfo.NextPage();
                cartPage.RemoveCart();
                Thread.Sleep(5000);
            }
        }
    }
}



