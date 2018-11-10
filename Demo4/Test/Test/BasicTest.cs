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
        public void TestTest()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                dr.Navigate().GoToUrl("http://www.google.com");
                MsSql ms = new MsSql();
                //ms.Add(new AliGoods() {Name = "Suka_Rabotaet",Price = 9999,Orders = 3 });
                ms.Add(new TestResults() { TestResult = "VSE_BLA_RABOTAET", TestName = "Yura_TI_RAK", TestErrorMessage = "AAAAAAAAAAAAA!!!", TestRunnigTime = "SEGODNA!" });
                ms.CloseAllConnections();
            }
        }
    }
}
