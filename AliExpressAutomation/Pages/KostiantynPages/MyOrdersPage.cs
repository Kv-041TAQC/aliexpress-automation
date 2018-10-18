using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using AliExpress.Helpers;


namespace AliExpress.Pages
{
    public class MyOrdersPage
    {

        #region Fields and Constants
        private IWebDriver driver;

        #endregion

        #region Page Element Locators
        public IWebElement ShipmentAddressLink => driver.FindElement(By.LinkText("Shipping Address"));

        #endregion

        #region Constructors
        public MyOrdersPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods
        public ShippingAddressPage OpenShippingAddressPage()
        {
            WaitUtilities.WaitForElement(driver, ShipmentAddressLink, 15);
            ShipmentAddressLink.Click();
            return new ShippingAddressPage(driver);
        }
        #endregion

    }
}