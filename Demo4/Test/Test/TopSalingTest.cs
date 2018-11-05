using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using Pages.TopSaling;

namespace Test
{
    [TestFixture]
    [Parallelizable]
    public class TopSallingTest
    {
        [Test]
        public void TopSalling()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var mainPage = new MainPage(dr);
                var searchPage1 = mainPage.GoToTheSearchPhones();
                var searchPage2 = searchPage1.WriteTopPhonesAndGoToSecondPage();
                var searchPage3 = searchPage2.WriteTopPhonesAndGoToThirdPage();
                searchPage3.WriteTopPhones();

            }
        }
    }
}