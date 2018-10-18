using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AliExpress.Helpers;
using System.Threading;



namespace AliExpress.Pages
{
    public class ShippingAddressPage
    {

        #region Fields And Constants
        private IWebDriver driver;

        private const string contactErrMsgTxt = "Please enter a Contact Name";
        private const string countryRegionErrMsgTxt = "Please select a Country/Region";
        private const string addressErrMsgTxt = "Please enter an Address";
        private const string stateProvinceErrMsgTxt = "Please select a State/Province/Region";
        private const string cityErrMsgTxt = "Please enter a City";
        private const string zipErrMsgTxt = "Please enter a ZIP/Postal Code";
        private const string mobileNoErrMsgTxt = "You must include a Mobile number";


        #endregion Fields And Constants

        #region Page Element Locators
        public IWebElement AddNewAddressButton => driver.FindElement(By.LinkText("Add a new address"));

        // SHIPPING ADDRESS FORM ELEMENTS
        public IWebElement ContactPersonInputField => driver.FindElement(By.Name("contactPerson"));
        public SelectElement CountryDropDownList => new SelectElement(driver.FindElement(By.Name("country")));
        public IWebElement AddressInputField => driver.FindElement(By.Name("address"));
        public IWebElement ApartmentInputField => driver.FindElement(By.Name("address2"));
        public SelectElement StateProvinceDropDownList => new SelectElement(driver.FindElement(
            By.XPath("//div[@class='sa-form']/div[@class='row sa-form-group sa-province-group']/div/select")));
        // City field can be input or drop down list depending on the Country / State selection
        public IWebElement CityInputField => driver.FindElement(By.Name("city"));
        public SelectElement CityDropDownList => new SelectElement(driver.FindElement(By.XPath("//div[@class='row sa-form-group sa-city-group']/div/select")));
        public IWebElement ZipInputField => driver.FindElement(By.Name("zip"));
        public IWebElement NoZipCodeCheckBox => driver.FindElement(By.XPath("//div[@class='sa-form']//label[@class='sa-no-zip-code']/input"));
        public IWebElement PhoneCountryInputField => driver.FindElement(By.Name("phoneCountry"));
        public IWebElement MobileNumberInputField => driver.FindElement(By.Name("mobileNo"));
        public IWebElement SetAsDefaultCheckBox => driver.FindElement(By.XPath("//div[@class='sa-form']//input[@name='isDefault']"));

        // SUCCESS ICONS
        public IWebElement ContactNameSuccessIcon => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[1]//div[@class='sa-success-icon']"));
        public IWebElement CountryRegionSuccessIcon => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[2]//div[@class='sa-success-icon']"));
        public IWebElement StreetAddressSuccessIcon => driver.FindElement(
            By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[3]/ul[@class='sa-form-control sa-street-wrapper']/li[1]//div[@class='sa-success-icon']"));
        public IWebElement ApartmentSuccessIcon => driver.FindElement(
            By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[3]/ul[@class='sa-form-control sa-street-wrapper']/li[2]//div[@class='sa-success-icon']"));
        public IWebElement StateProvinceRegionSuccessIcon => driver.FindElement(
            By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[@class='row sa-form-group sa-province-group']//div[@class='sa-success-icon']"));
        public IWebElement CitySuccessIcon => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[5]//div[@class='sa-success-icon']"));
        public IWebElement ZipSuccessIcon => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[6]//div[@class='sa-success-icon']"));
        public IWebElement MobileNumberSuccessIcon => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[7]//div[@class='sa-success-icon']"));

        // ERROR MESSAGES
        public IWebElement ContactNameErrorMessage => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[1]//p[@class='sa-error-tips']"));
        public IWebElement CountryRegionErrorMessage => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[2]//p[@class='sa-error-tips']"));
        public IWebElement StreetAddressErrorMessage => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']//div[3]//p[@class='sa-error-tips']"));
        public IWebElement StateProvinceRegionErrorMessage => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']//div[4]//p[@class='sa-error-tips']"));
        public IWebElement CityErrorMessage => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[5]//p[@class='sa-error-tips']"));
        public IWebElement ZipErrorMessage => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']//div[6]//p[@class='sa-error-tips']"));
        public IWebElement MobileNumberErrorMessage => driver.FindElement(By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[7]//p[@class='sa-error-tips']"));


        // BUTTONS
        public IWebElement SaveButton => driver.FindElement(By.LinkText("Save"));
        public IWebElement CancelButton => driver.FindElement(By.LinkText("Cancel"));

        #endregion Page Element Locators

        #region Constructors
        public ShippingAddressPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion Constructors

        #region Methods

        // TODO: ERROR CHECKING :make this into something more beautiful
        private bool CheckErrorMessage(IWebElement element, string message)
        {
            WaitUtilities.WaitForElement(driver, element, 15);
            return element.Text.Equals(message);
        }

        public bool IsContactErrorMessagePresentAndCorrect()
        {
            try
            {
                return CheckErrorMessage(ContactNameErrorMessage, contactErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Contact error message has not been found: " + e.Message);
                return false;
            }

        }

        public bool IsCountryRegionErrorMessagePresentAndCorrect()
        {
            try
            {
                return CheckErrorMessage(CountryRegionErrorMessage, countryRegionErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Country/Region error message has not been found: " + e.Message);
                return false;
            }

        }

        public bool IsAddressErrorMessagePresentAndCorrect()
        {
            try
            {
                return CheckErrorMessage(StreetAddressErrorMessage, addressErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Address error message has not been found: " + e.Message);
                return false;
            }

        }

        public bool IsStateErrorMessagePresentAndCorrect()
        {
            try
            {
                return CheckErrorMessage(StateProvinceRegionErrorMessage, stateProvinceErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: State error message has not been found: " + e.Message);
                return false;
            }

        }

        public bool IsCityErrorMessagePresentAndCorrect()
        {
            try
            {
                return CheckErrorMessage(CityErrorMessage, cityErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: City error message has not been found: " + e.Message);
                return false;
            }

        }

        public bool IsZipErrorMessagePresentAndCorrect()
        {
            try
            {
                return CheckErrorMessage(ZipErrorMessage, zipErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Zip code error message has not been found: " + e.Message);
                return false;
            }

        }

        public bool IsMobileNumberErrorMessagePresentAndCorrect()
        {
            try
            {
                return CheckErrorMessage(MobileNumberErrorMessage, mobileNoErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Mobile number error message has not been found: " + e.Message);
                return false;
            }

        }


        // TODO: Change to: getting collection of the address boxes, find elements within elements and check text
        //       throw some exceptions or error/debug messages
        //       with XPath regex contains() element finding
        //       how to make those multiple condition checking more elegant
        public bool IsAddressPresent(Address adr)
        {
            Thread.Sleep(15000);
            if (!driver.PageSource.Contains(adr.contactName))
            {
                Console.WriteLine(adr.contactName + " have not been found.");
                return false;

            }
            if (!driver.PageSource.Contains(adr.streetAddress))
            {
                Console.WriteLine(adr.streetAddress + " have not been found.");
                return false;
            }
            if (!driver.PageSource.Contains(adr.apartment))
            {
                Console.WriteLine(adr.apartment + " have not been found.");
                return false;
            }
            if (!driver.PageSource.Contains(adr.stateProvinceRegion))
            {
                Console.WriteLine(adr.stateProvinceRegion + " have not been found.");
                return false;
            }
            if (!driver.PageSource.Contains(adr.countryRegion))
            {
                Console.WriteLine(adr.countryRegion + " have not been found.");
                return false;
            }
            if (!driver.PageSource.Contains(adr.mobileNoCountryCode))
            {
                Console.WriteLine(adr.mobileNoCountryCode + " have not been found.");
                return false;
            }
            if (!driver.PageSource.Contains(adr.mobileNumber))
            {
                Console.WriteLine(adr.mobileNumber + " have not been found.");
                return false;
            }

            return true;
        }

        public void AddNewShippingAddress()
        {
            WaitUtilities.WaitForElement(driver, AddNewAddressButton, 15);
            AddNewAddressButton.Click();
        }

        // TODO: add success icon checks (1.input 2.click on form 3.check for icon)
        public void FillShippingAddressForm(Address adr)
        {
            ContactPersonInputField.SendKeys(adr.contactName);
            CountryDropDownList.SelectByText(adr.countryRegion);
            AddressInputField.SendKeys(adr.streetAddress);
            ApartmentInputField.SendKeys(adr.apartment);
            StateProvinceDropDownList.SelectByText(adr.stateProvinceRegion);
            CityDropDownList.SelectByText(adr.city);
            ZipInputField.SendKeys(adr.zip);
            PhoneCountryInputField.Clear();
            PhoneCountryInputField.SendKeys(adr.mobileNoCountryCode);
            MobileNumberInputField.SendKeys(adr.mobileNumber);
            SaveButton.Click();
        }

        #endregion Methods
    }
}
