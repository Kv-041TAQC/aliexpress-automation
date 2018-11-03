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
                MsSql<AliGoods> MsSql = new MsSql<AliGoods>();
                MsSql.Add(new AliGoods() {Price = 9999, Name = "sssssss" });
                MsSql.AddRange(new AliGoods[] {new AliGoods(){ Price = 9999, Name = "firstproduct" }, new AliGoods() { Price = 9999, Name = "firstproduct" } , new AliGoods() { Price = 9999, Name = "firstproduct" } });
                MsSql.Delete(2);
               // MsSql.ClearTable();
                //MsSql.AddTestResult(new TestResults() { Name = "TopSallingsTest", Time = "03.11.2018", Result = "Passed", IsRunned = true });
                MsSql.CloseAllConnections();
                Thread.Sleep(3000);

            }

        }

    }
}