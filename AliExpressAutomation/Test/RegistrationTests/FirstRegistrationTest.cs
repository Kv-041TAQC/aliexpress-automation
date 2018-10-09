using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;

namespace Test
{
    [TestFixture]
    public class FirstAliTest
    {
        [Test]
        [Parallelizable]
        public void SearchStringPositiveTest()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunPostiveTest(0);
                searchtest.RunPostiveTest(1);
            }
        }
        [Test]
        [Parallelizable]
        public void SearchStringNegativeTest()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunNegativeTest(0);
            }
        }
    }
}
