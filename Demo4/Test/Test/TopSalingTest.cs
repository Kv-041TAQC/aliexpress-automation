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
using NUnit.Framework.Interfaces;

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
                HelpClass helper = new HelpClass();
                
                var mainPage = new MainPage(dr);
                mainPage.GoToEnglishMainPage();
                try
                {
                    mainPage.CloseAdvertasing();
                }
                catch { }
                var searchPage1 = mainPage.GoToTheSearchPhones();
                searchPage1.FindAndWriteTopPhones();  
                
                var searchPage2 = searchPage1.GoToSecondPage();
                searchPage2.FindAndWriteTopPhones();

                var searchPage3 = searchPage2.GoToThirdPage();
                searchPage3.FindAndWriteTopPhones();

                AliGoods[] aliGoods = new AliGoods[SuperPage.countPhone];
                helper.ConverterStructGoodsToClass(aliGoods);
                aliGoods.Clone();
                //MsSql msSql = new MsSql();
                //msSql.ClearTable("aligoods");
                //msSql.AddRange(aliGoods);

                //TestResults testResults = new TestResults();
                //DateTime nowTime = new DateTime();
                //nowTime = DateTime.Now;
                //string nowTimeStr = nowTime.ToLongDateString();
                //testResults.TestName = "test" + nowTimeStr;
                //testResults.TestRunnigTime = nowTimeStr;

                ////Asserts

                //if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
                //{
                //    testResults.TestResult = "Failed";
                //    testResults.TestErrorMessage = TestContext.CurrentContext.Result.Message;
                //}
                //else
                //{
                //    testResults.TestResult = "Passed";
                //    testResults.TestErrorMessage = "Test Passed";
                //}

                //msSql.Add(testResults);
            }
        }
    }
}