using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using AliExpress.Helpers;
using Pages;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace AliExpress.Pages
{
    public class MyOrdersPage : SuperPage
    {

        #region Fields and Constants
        private IWait<IWebDriver> wait;

        #endregion

        #region Page Element Locators
        
        private By shipmentAddressLinkLocator = By.LinkText("Shipping Address");
        public IWebElement ShipmentAddressLink => driver.FindElement(shipmentAddressLinkLocator);

        #endregion

        #region Constructors
        public MyOrdersPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver)
        {
            this.wait = wait;
        }
        #endregion

        #region Methods
        public ShippingAddressPage OpenShippingAddressPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(shipmentAddressLinkLocator));
            Click(ShipmentAddressLink);
            return new ShippingAddressPage(driver, wait);
        }
        #endregion

    }
}