using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using AliExpress.Helpers;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Tests
    {

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None; // PageLoadStrategy.Eager not supported by Chrome
            driver = new ChromeDriver("/home/kbogomazov/dotnet_src/lib", options);
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            Helpers helper = new Helpers(driver);
            helper.NavigateToAliExpressHomepage();
            helper.LoginToAliExpress();
            Thread.Sleep(5000);

        }
    }
}