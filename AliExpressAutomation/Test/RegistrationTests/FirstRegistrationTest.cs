using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using System.Threading;
using OpenQA.Selenium;

namespace Test
{
    [TestFixture]
    public class SearchStringPositiveTest
    {
        ChromeOptions options = new ChromeOptions();
        [TestCase(0)]
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
    public class SearchStringNegativeTest
    {
        ChromeOptions options = new ChromeOptions();
        [TestCase(0)]
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

