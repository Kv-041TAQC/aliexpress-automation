using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using AliExpress.Helpers;
using AliExpress.Pages;
using System.Threading;
using System;
using OpenQA.Selenium.Support.UI;

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
            // driver = new ChromeDriver("/home/kbogomazov/dotnet_src/lib", options);
            driver = new ChromeDriver(@"F:\src\qa\qa_automation_lib", options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [Test]
        public void Test1()
        {
            Helpers helper = new Helpers(driver);
            helper.NavigateToAliExpressHomepage();
            Thread.Sleep(5000); // why this works only here
            helper.LoginToAliExpress();
            ShippingAddressPage shippingAddressPage = new ShippingAddressPage(driver);
            shippingAddressPage.FillShippingAddressForm();

        }
    }
}