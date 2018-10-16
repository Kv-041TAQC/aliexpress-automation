using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;

namespace Tests.RegistrationTests
{
    public class BasicTest
    {
        [SetUp]
        public void StartTestWith()
        {

        }
        [TearDown]
        public void TearDown()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                SearchStringPage screen = new SearchStringPage(dr);
                if(TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
                {
                    screen.TakeScreenShot();
                }
            }
        }
    }
}
