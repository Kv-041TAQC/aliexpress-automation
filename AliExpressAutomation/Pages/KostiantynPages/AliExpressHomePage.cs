using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace AliExpress.Helpers
{
    public class Helpers
    {

        private IWebDriver driver;
        private const string aliExpressURL = "https://www.aliexpress.com";
        private const string aliExpressLogin = "skaxrfdzeajgee2w@outlook.com";
        private const string aliExpressPassword = "qLEvZxcMVU9xqdQC";

        private const string aliExpressLoginFormId = "alibaba-login-box";


        public IWebElement SignInButton => driver.FindElement(
            By.XPath("//div[@id='user-benefits']/div[@class='user-account']//span[@class='register-btn']/a[@data-role='sign-link']"));

        public IWebElement LoginField => driver.FindElement(By.Id("fm-login-id"));
        public IWebElement PasswordField => driver.FindElement(By.Id("fm-login-password"));
        public IWebElement LoginSubmitButton => driver.FindElement(By.Id("fm-login-submit"));

        public IWebElement AdsCloseButton => driver.FindElement(By.XPath("//a[@data-role='layer-close']"));

        public IWebElement GoToGlobalSiteLink => driver.FindElement(By.LinkText("Go to Global Site (English)"));

        // TODO: change to click in the drop down menu, change to finding by text My Orders
        public IWebElement MyOrdersLink => driver.FindElements(By.XPath("//a[contains(@href, 'orderList.htm')]"))[1];

        // TODO: change to something more adequate
        public IWebElement ShipmentAddressLink => driver.FindElement(By.LinkText("Shipping Address"));

        public IWebElement AddNewAddressButton => driver.FindElement(By.LinkText("Add a new address"));



        public Helpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToAliExpressHomepage()
        {
            driver.Navigate().GoToUrl(aliExpressURL);
        }

        public void WaitForElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            Console.WriteLine($"Waiting for {element.GetAttribute("class")} to appear.");
            Thread.Sleep(15000);
        }

        public void LoginToAliExpress()
        {

            // TODO: try to set cookie
            // TODO: try to find those elements using class attribute

            // <a href="javascript:;" class="close-layer" data-role="layer-close">x</a>
            // <a data-role="goto-globalsite" class="link-goto-globalsite notranslate" rel="nofollow" href="http://www.aliexpress.com/">Go to Global Site (English)</a>
            try
            {
                WaitForElement(AdsCloseButton);
                AdsCloseButton.Click();

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: There was no ad: " + e.Message);
            }


            WaitForElement(GoToGlobalSiteLink);
            GoToGlobalSiteLink.Click();
            WaitForElement(SignInButton);
            SignInButton.Click();
            WaitForElement(driver.FindElement(By.Id(aliExpressLoginFormId)));
            driver.SwitchTo().Frame(driver.FindElement(By.Id(aliExpressLoginFormId))); // TODO: change to lambda expression or something cool
            WaitForElement(LoginField);
            LoginField.SendKeys(aliExpressLogin);
            WaitForElement(PasswordField);
            PasswordField.SendKeys(aliExpressPassword);
            WaitForElement(LoginSubmitButton);
            LoginSubmitButton.Click();

            // Click My Orders link
            // <a href="//trade.aliexpress.com/orderList.htm"><span class="order-icon entrance-icon">&nbsp;</span> <span class="entrance-name flex-vertical middle-center">My Orders</span> </a>
            // <a href="//trade.aliexpress.com/orderList.htm?spm=2114.11010108.01010.4.16d4649bidxqVM" data-spm-anchor-id="2114.11010108.01010.4"><span class="order-icon entrance-icon" data-spm-anchor-id="2114.11010108.01010.i0.16d4649bidxqVM">&nbsp;</span> <span class="entrance-name flex-vertical middle-center">My Orders</span> </a>
            // <a href="//trade.aliexpress.com/orderList.htm?spm=2114.11010108.01010.4.3503649b4YDP6z" data-spm-anchor-id="2114.11010108.01010.4"><span class="order-icon entrance-icon">&nbsp;</span> <span class="entrance-name flex-vertical middle-center" data-spm-anchor-id="2114.11010108.01010.i0.3503649b4YDP6z">My Orders</span> </a>
            WaitForElement(MyOrdersLink);
            MyOrdersLink.Click();

            // Click shipping address menu
            // <a href="http://ilogisticsaddress.aliexpress.com/addressList.htm">Shipping Address</a>
            WaitForElement(ShipmentAddressLink);
            ShipmentAddressLink.Click();

            // Click "Add new address" button
            // <a href="javascript:;" class="ui-button ui-button-primary ui-button-large sa-add-a-new-address" data-spm-anchor-id="a2g0s.8850659.0.0">Add a new address</a>
            WaitForElement(AddNewAddressButton);
            AddNewAddressButton.Click();
        }

        public void OpenMyOrdersPage()
        {

        }

        public void OpenShipmentAddress()
        {

        }

        // TODO: move all this stuff into:
        // Homepage
        // MyAliExpress page
        // which switches into My Orders and other options
        // in helper class should be waiters, ads/popup windows checking/closing
        // make normal class hierarchy
        // work with ajax / js


    }
}
