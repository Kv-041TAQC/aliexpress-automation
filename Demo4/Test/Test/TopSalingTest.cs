using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using Pages.TopSaling;
using Pages.DatabaseStuff;

namespace Test
{
    [TestFixture]
     public class TopSallingTest
    {

        [Test]
        public void TopSalling()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                dr.Navigate().GoToUrl("http://www.google.com");
                SqlServer<AliGoods> sqlServer = new SqlServer<AliGoods>();
                sqlServer.Add(new AliGoods() {Price = 9999, Name = "firstproductasdasdas" });
                sqlServer.AddRange(new AliGoods[] {new AliGoods(){ Price = 9999, Name = "firstproduct" }, new AliGoods() { Price = 9999, Name = "firstproduct" } , new AliGoods() { Price = 9999, Name = "firstproduct" } });
                sqlServer.Delete(2);
                Thread.Sleep(3000);

            }

        }

    }
}