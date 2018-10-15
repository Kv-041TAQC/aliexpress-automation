
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.YuraPages;
using Pages.EvgenPages;

namespace Test
{
    [TestFixture]
    public class FirstAliTest
    {
        public class Test_Yura
        {
            [Test]
            public void DifferentCurrency()
            {
                using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
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
}