using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using AliExpress.Helpers;
using Pages;


namespace AliExpress.Pages
{
    public class MyOrdersPage : SuperPage
    {

        #region Fields and Constants
        private WebDriverWait wait;

        #endregion

        #region Page Element Locators
        
        private By shipmentAddressLinkLocator = By.LinkText("Shipping Address");
        public IWebElement ShipmentAddressLink => driver.FindElement(shipmentAddressLinkLocator);

        #endregion

        #region Constructors
        public MyOrdersPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }
        #endregion

        #region Methods
        public ShippingAddressPage OpenShippingAddressPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(shipmentAddressLinkLocator));
            Click(ShipmentAddressLink);
            return new ShippingAddressPage(driver);
        }
        #endregion

    }
}