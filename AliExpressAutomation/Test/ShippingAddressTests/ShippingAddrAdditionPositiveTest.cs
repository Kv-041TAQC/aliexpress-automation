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
    public class ShippingAddrAdditionPositiveTest
    {

        private IWebDriver driver;
        private IWait<IWebDriver> wait;

        [SetUp]
        public void Setup()
        {

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None; // PageLoadStrategy.Eager not supported by Chrome
            // driver = new ChromeDriver("/home/kbogomazov/dotnet_src/lib", options);
            driver = new ChromeDriver(@"F:\src\qa\qa_automation_lib", options);
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Test]
        public void ShippingAddressAdditionPositiveTest()
        {
            AliExpressHomePage homePage = new AliExpressHomePage(driver, wait);
            homePage.NavigateToAliExpressHomepage();
            homePage.LoginToAliExpress();
            MyOrdersPage myOrdersPage = homePage.NavigateToMyOrdersPage();
            ShippingAddressPage shippingAddressPage = myOrdersPage.OpenShippingAddressPage();

            // TODO: change this to JSON or random generation
            Address adr;
            adr.contactName = "John Doe";
            adr.countryRegion = "United States";
            adr.streetAddress = "10 Test Ave";
            adr.apartment = "15";
            adr.stateProvinceRegion = "New York";
            adr.city = "New york";
            adr.zip = "11221";
            adr.mobileNoCountryCode = "+1";
            adr.mobileNumber = "5417543111";

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