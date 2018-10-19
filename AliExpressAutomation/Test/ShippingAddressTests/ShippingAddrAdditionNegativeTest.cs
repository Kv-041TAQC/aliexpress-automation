using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Pages.KostiantynPages.Helpers;
using Pages.KostiantynPages;
using System.Threading;
using System;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestFixture]
    public class ShippingAddrAdditionNegativeTest
    {

        [Test]
        public void ShippingAddressAdditionNegativeTest()
        {

            TestDataHandler dataHandler = new TestDataHandler(@".\ShippingAddressTestData");
            dataHandler.WriteTestData();

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None; // PageLoadStrategy.Eager not supported by Chrome

            using (ChromeDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                driver.Manage().Window.Maximize();

                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                AliExpressHomePage homePage = new AliExpressHomePage(driver, wait);
                homePage.NavigateToAliExpressHomepage();
                homePage.LoginToAliExpress(dataHandler.ReadLoginData());
                MyOrdersPage myOrdersPage = homePage.NavigateToMyOrdersPage();
                ShippingAddressPage shippingAddressPage = myOrdersPage.OpenShippingAddressPage();
                shippingAddressPage.AddNewShippingAddress();
                shippingAddressPage.ClearCountryDropDown();
                shippingAddressPage.ShippingAddressFormSave();

                Assert.Multiple(() =>
                 {
                    Assert.True(shippingAddressPage.IsContactErrorMessagePresentAndCorrect());
                    Assert.True(shippingAddressPage.IsCountryRegionErrorMessagePresentAndCorrect());
                    Assert.True(shippingAddressPage.IsAddressErrorMessagePresentAndCorrect());
                    Assert.True(shippingAddressPage.IsStateErrorMessagePresentAndCorrect());
                    Assert.True(shippingAddressPage.IsCityErrorMessagePresentAndCorrect());
                    Assert.True(shippingAddressPage.IsZipErrorMessagePresentAndCorrect());
                    Assert.True(shippingAddressPage.IsMobileNumberErrorMessagePresentAndCorrect());
                });


            }

        }
    }
}