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
                MsSql MsSql = new MsSql();
                MsSql.Add(new AliGoods() {Price = 1234, Name = "Iphone" });
                MsSql.AddRange(new AliGoods[] {new AliGoods(){ Price = 999, Name = "Samsung" }, new AliGoods() { Price = 750, Name = "Iphone XR" } , new AliGoods() { Price = 1500, Name = "IPhone XS MAX" } });
                MsSql.Delete(2);
                //MsSql.ClearTable();
                //MsSql.AddTestResult(new TestResults() { Name = "TopSallingsTest", Time = "03.11.2018", Result = "Passed", IsRunned = true });
                MsSql.CloseAllConnections();
                Thread.Sleep(3000);

            }

        }

    }
}