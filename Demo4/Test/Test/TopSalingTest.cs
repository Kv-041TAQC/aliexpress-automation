using System;
using System.Collections;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Pages;
using Pages.DatabaseStuff;
using Pages.HelpClass;
using Pages.TopSaling;

namespace Test
{
    [TestFixture]
    [AllureNUnit]
    /// <summary>
    /// <para>Test of *Find Top Phones and add it to data base* </para>
    /// </summary>
    public class TopSallingTest
    {
        [OneTimeSetUp]
        public void CleanupResultDirectory()
        {
            AllureExtensions.WrapSetUpTearDownParams(() => { AllureLifecycle.Instance.CleanupResultDirectory(); },
                "Cleanup Allure Results Directory");
        }
        
        [Test]
        [AllureTag("NUnit","Debug")]
        [AllureIssue("GitHub#1", "https://github.com/Kv-041TAQC/aliexpress-automation")]
        [AllureFeature("Core")]
        /// <summary>
        /// <para>Top saling test</para>
        /// </summary>
        public void TopSalling()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (RemoteWebDriver dr = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options))
            {
                SuperPage.phones = new Phone[144];
                HelpClass helper = new HelpClass();
                
                var mainPage = new MainPage(dr);
                mainPage.GoToMainPage();
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
                MsSql msSql = new MsSql();
                msSql.ClearTable("aligoods");
                msSql.AddRange(aliGoods);

                ArrayList getsFromDataBase = new ArrayList();
                getsFromDataBase = msSql.GetAll("aliGoods");
                
                int countphone = 0;
                foreach(AliGoods element in getsFromDataBase)
                {
                    Assert.IsTrue(element.EqualsGoods(aliGoods[countphone++]));
                }
                msSql.CloseAllConnections();
            }

        }
        /// <summary>
        /// <para>TearDown top saling test</para>
        /// </summary>
        [TearDown]
        public void tearDown()
        {
            MsSql msSql = new MsSql();
            TestResults testResults = new TestResults();
            DateTime nowTime = new DateTime();
            nowTime = DateTime.Now;
            string nowTimeStr = nowTime.ToLongDateString();
            testResults.TestName = "Test " + nowTimeStr;
            testResults.TestRunnigTime = nowTimeStr;


            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                testResults.TestResult = "Failed";
                testResults.TestErrorMessage = TestContext.CurrentContext.Result.Message;
            }
            else
            {
                testResults.TestResult = "Passed";
                testResults.TestErrorMessage = "Test Passed";
            }

            msSql.Add(testResults);
            msSql.CloseAllConnections();
        }
    }
}
