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
        public void FirstTest()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var searchtest = new SearchStringPage(dr);
            
                searchtest.RunPostiveTest();
                searchtest.RunNegativeTest();
            }
        }
    }
}
