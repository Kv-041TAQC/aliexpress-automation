using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using OpenQA.Selenium;

namespace Test
{
    [TestFixture]
    [Parallelizable]
    public class SearchStringPositiveTest
    {
        ChromeOptions options = new ChromeOptions();
        static int[] arr = new int[] { 1, 2, 3 };
        [Test,TestCaseSource("arr")]
        public void FirstSearchStringPositiveTest(int index)
        {
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(),options))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunPostiveTest(index);
            }
        }

    }
    [TestFixture]
    [Parallelizable]
    public class SearchStringNegativeTest
    {
        ChromeOptions options = new ChromeOptions();
        static int[] arr = new int[] { 1, 2, 3 };
        [Test, TestCaseSource("arr")]
        public void FirstSearchStringNegativeTest(int index)
        {
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(),options))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunNegativeTest(index);
            }
        }
    }

}

