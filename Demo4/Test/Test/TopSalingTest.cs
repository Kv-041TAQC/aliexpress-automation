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
                MsSql ms = new MsSql();
                ms.Add(new TestResults() {TestName ="Super Yura test",TestResult = "Passed", TestRunnigTime = $"07.11.2018",TestErrorMessage = "Yura error" });
                ms.CloseAllConnections();
                Thread.Sleep(3000);

            }

        }

    }
}