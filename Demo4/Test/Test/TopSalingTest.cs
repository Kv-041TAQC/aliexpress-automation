using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using Pages.TopSaling;
using Pages.DatabaseStuff;
using Pages;
using Pages.HelpClass;

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
                 SuperPage.phones = new Phone[144];

                var mainPage = new MainPage(dr);
                mainPage.GoToEnglishMainPage();
                mainPage.CloseAdvertasing();
                
                var searchPage1 = mainPage.GoToTheSearchPhones();
                searchPage1.FindAndWriteTopPhones();  
                
                var searchPage2 = searchPage1.GoToSecondPage();
                searchPage2.FindAndWriteTopPhones();

                var searchPage3 = searchPage2.GoToThirdPage();
                searchPage3.FindAndWriteTopPhones();

                SuperPage.phones.Clone();  
                //MsSql msSql = new MsSql();
                //msSql.ClearTable("aligoods");
                //AliGoods[] arr = new AliGoods[SuperPage.countPhone];
                //for (int i = 0; i < SuperPage.countPhone; i++)
                //{
                    
                //}                   
                //msSql.AddRange(arr);


            }
        }
    }
}