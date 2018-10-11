using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using System.Threading;

namespace Test
{
    [TestFixture]
    public class SearchStringPositiveTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FirstSearchStringPositiveTest(int index)
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunPostiveTest(index);
            }
        }
    }
    [TestFixture]
    public class SearchStringNegativeTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FirstSearchStringNegativeTest(int index)
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunNegativeTest(index);
            }
        }
    }
}

