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
    public class ShippingAddrAdditionNegativeTest
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
        public void ShippingAddressAdditionNegativeTest()
        {
            AliExpressHomePage homePage = new AliExpressHomePage(driver, wait);
            homePage.NavigateToAliExpressHomepage();
            homePage.LoginToAliExpress();
            MyOrdersPage myOrdersPage = homePage.NavigateToMyOrdersPage();
            ShippingAddressPage shippingAddressPage = myOrdersPage.OpenShippingAddressPage();
            shippingAddressPage.AddNewShippingAddress();
            shippingAddressPage.ClearCountryDropDown();
            shippingAddressPage.ShippingAddressFormSave();

            Assert.True(shippingAddressPage.IsContactErrorMessagePresentAndCorrect());
            Assert.True(shippingAddressPage.IsCountryRegionErrorMessagePresentAndCorrect());
            Assert.True(shippingAddressPage.IsAddressErrorMessagePresentAndCorrect());
            Assert.True(shippingAddressPage.IsStateErrorMessagePresentAndCorrect());
            Assert.True(shippingAddressPage.IsCityErrorMessagePresentAndCorrect());
            Assert.True(shippingAddressPage.IsZipErrorMessagePresentAndCorrect());
            Assert.True(shippingAddressPage.IsMobileNumberErrorMessagePresentAndCorrect());

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}