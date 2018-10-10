using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using System.Threading;

namespace Test
{
    [TestFixture]
    public class FirstAliTest
    {
        [Test]
        [Parallelizable]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(1)]
        public void SearchStringPositiveTest(int index)
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunPostiveTest(index);
            }
        }
        [Test]
        [Parallelizable]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(1)]
        public void SearchStringNegativeTest(int index)
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunNegativeTest(index);
            }
        }
    }
}
