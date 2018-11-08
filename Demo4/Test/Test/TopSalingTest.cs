using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using Pages.TopSaling;
using Pages.DatabaseStuff;
using System.Collections.Generic;
using System.Collections;

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
                ms.ClearTable("testresults");
                ArrayList list = new ArrayList();
                list.AddRange(ms.GetAll("aligoods"));

                Thread.Sleep(3000);
            }

        }

    }
}