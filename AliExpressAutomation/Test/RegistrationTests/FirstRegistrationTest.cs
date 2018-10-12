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
        [Test]
        public void FirstSearchStringPositiveTest()
        {
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(),options))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunPostiveTest(0);
            }
        }
    }
    [TestFixture]
    [Parallelizable]
    public class SearchStringNegativeTest
    {
        ChromeOptions options = new ChromeOptions();
        [Test]
        public void FirstSearchStringNegativeTest()
        {
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(),options))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunNegativeTest(0);
            }
        }

    }

}

