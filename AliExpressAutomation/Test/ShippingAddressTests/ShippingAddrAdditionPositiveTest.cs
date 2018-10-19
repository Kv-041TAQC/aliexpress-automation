using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using AliExpress.Helpers;
using AliExpress.Pages;
using System.Threading;
using System;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestFixture]
    public class ShippingAddrAdditionPositiveTest
    {

        private IWebDriver driver;
        private IWait<IWebDriver> wait;

        private TestDataHandler dataHandler;

        [SetUp]
        public void Setup()
        {

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None; // PageLoadStrategy.Eager not supported by Chrome
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
            dataHandler = new TestDataHandler(@".\ShippingAddressTestData");
            dataHandler.WriteTestData();
        }

        [Test]
        public void ShippingAddressAdditionPositiveTest()
        {
            AliExpressHomePage homePage = new AliExpressHomePage(driver, wait);
            homePage.NavigateToAliExpressHomepage();
            homePage.LoginToAliExpress(dataHandler.ReadLoginData());
            MyOrdersPage myOrdersPage = homePage.NavigateToMyOrdersPage();
            ShippingAddressPage shippingAddressPage = myOrdersPage.OpenShippingAddressPage();

            Address adr = dataHandler.ReadAddressData();
            shippingAddressPage.AddNewShippingAddress();
            shippingAddressPage.FillShippingAddressForm(adr);
            shippingAddressPage.ShippingAddressFormSave();
            Assert.True(shippingAddressPage.IsAddressPresent(adr));

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}