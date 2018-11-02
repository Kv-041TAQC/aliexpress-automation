using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using Pages.TopSaling;

namespace Tests.Test
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
                MainPage  screen = new MainPage(dr);
                if(TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
                {
                    screen.TakeScreenShot();
                }
            }
        }
    }
}
