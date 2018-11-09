using System;
using System.IO;
using NUnit.Framework;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Pages.DatabaseStuff;

namespace Tests.Test
{
    [TestFixture]
    [AllureNUnit]
    public class BasicTest
    {

        [OneTimeSetUp]
        public void CleanupResultDirectory()
        {
            AllureExtensions.WrapSetUpTearDownParams(() => { AllureLifecycle.Instance.CleanupResultDirectory(); },
                "Cleanup Allure Results Directory");
        }

        
        [Test]
        [AllureTag("NUnit","Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Core")]
        public void Test()
        {
            ChromeOptions chrome = new ChromeOptions();
            // options.AddExtensions("/full/path/to/extension.crx");

            using (RemoteWebDriver dr = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chrome))
            {
                dr.Navigate().GoToUrl("http://www.google.com");
                MsSql ms = new MsSql();
                ms.Add(new AliGoods() {Name = "random1",Price = 100,Orders = 3 });
                ms.AddRange(new AliGoods[] { new AliGoods() { Name = "random1", Price = 100, Orders = 3 }, new AliGoods() { Name = "random1", Price = 100, Orders = 3 }, new AliGoods() { Name = "random1", Price = 100, Orders = 3 } });
            }
        }
    }
}
