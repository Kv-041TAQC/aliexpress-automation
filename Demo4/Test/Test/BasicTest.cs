using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using Pages.DatabaseStuff;

namespace Tests.Test
{
    [TestFixture]
    public class BasicTest
    {
        [Test]
        public void Test()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                dr.Navigate().GoToUrl("http://www.google.com");
                MsSql ms = new MsSql();
                ms.Add(new AliGoods() {Name = "random1",Price = 100,Orders = 3 });
                ms.AddRange(new AliGoods[] { new AliGoods() { Name = "random1", Price = 100, Orders = 3 }, new AliGoods() { Name = "random1", Price = 100, Orders = 3 }, new AliGoods() { Name = "random1", Price = 100, Orders = 3 } });
                ms.Add(new TestResults() {TestErrorMessage = "VseRabotaet",TestName = "Ya zhe govoril",TestResult = "" });
            }
        }
    }
}
