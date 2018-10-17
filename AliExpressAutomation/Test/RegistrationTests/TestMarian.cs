using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Pages.MarianPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.RegistrationTests
{
    [TestFixture]
    public class TestMarian
    {
        [Test]
        public void CartTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                dr.Manage().Window.Maximize();
                var mydriver = new Main(dr);
                mydriver.NavigateToAli();
                ResultIPhone resultIPhone6 = mydriver.ChooseIPhone();
                IPhone6 iphone6 = resultIPhone6.GoIPhone6();
                ResultIPhone resultIPhone6s = iphone6.ChooseIPhone6s();
                IPhone6S iphone6S = resultIPhone6s.GoIPhone6s();
                ResultIPhone resultIPhone7 = iphone6S.ChooseIPhone7();
                IPhone7 iphone7 = resultIPhone7.GoIPhone7();
                Cart cart = iphone7.GoToCart();
                cart.Finish();
            }
        }
    }
}