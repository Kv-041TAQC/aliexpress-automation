using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using Pages.MarianPages;
using OpenQA.Selenium;

namespace Test
{
    [TestFixture]
    public class FirstAliTest
    {
        [Test]
        //[Parallelizable]
        public void SearchStringPositiveTest()
        {

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(),options))
            {
                dr.Manage().Window.Maximize();
                //var searchtest = new SearchStringPage(dr);
                //searchtest.RunPostiveTest(0);
                //searchtest.RunPostiveTest(1);                
                var mydriver = new Main(dr);
                mydriver.NavigateToAli();
                ResultSamsung resultSamsung6 = mydriver.ChooseSamsung6();
                
                Samsung6 samsung6 = resultSamsung6.GoSams6();
               
                ResultSamsung resultSamsung7 = samsung6.ChooseSamsung7();
                Samsung7 samsung7 = resultSamsung7.GoSams7();
                ResultSamsung resultSamsung8 = samsung7.ChooseSamsung8();
                Samsung8 samsung8 = resultSamsung8.GoSams8();
                Cart cart = samsung8.GoToCart();






            }
        }
        //[Test]
        //[Parallelizable]
        //public void SearchStringNegativeTest()
        //{
        //    using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
        //    {
        //        var searchtest = new SearchStringPage(dr);
        //        searchtest.RunNegativeTest(0);
        //    }
        //}
    }
}
