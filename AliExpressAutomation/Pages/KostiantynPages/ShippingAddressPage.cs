using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AliExpress.Helpers;
using System.Threading;
using Pages;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;



namespace AliExpress.Pages
{
    public class ShippingAddressPage : SuperPage
    {

        #region Fields And Constants
        private IWait<IWebDriver> wait;

        private const string contactErrMsgTxt = "Please enter a Contact Name";
        private const string countryRegionErrMsgTxt = "Please select a Country/Region";
        private const string addressErrMsgTxt = "Please enter an Address";
        private const string stateProvinceErrMsgTxt = "Please select a State/Province/Region";
        private const string cityErrMsgTxt = "Please enter a City";
        private const string zipErrMsgTxt = "Please enter a ZIP/Postal Code";
        private const string mobileNoErrMsgTxt = "You must include a Mobile number";

        private const string countryDropDownNotSelectedValue = "--Please Select--";


        #endregion Fields And Constants

        #region Page Element Locators

        // SHIPPING ADDRESS FORM ELEMENTS
        private By addNewAddressButtonLocator = By.LinkText("Add a new address");
        private By allAddressBoxesLocator = By.XPath("//div[contains(@class, 'sa-address-item')]");
        private By contactPersonInputFieldLocator = By.Name("contactPerson");
        private By countryDropDownListLocator = By.Name("country");
        private By addressInputFieldLocator = By.Name("address");
        private By appartmentInputFieldLocator = By.Name("address2");
        private By stateProvinceDropDownListLocator = By.XPath("//div[@class='sa-form']/div[@class='row sa-form-group sa-province-group']/div/select");
        private By cityInputFieldLocator = By.Name("city");
        private By cityDropDownListLocator = By.XPath("//div[@class='row sa-form-group sa-city-group']/div/select");
        private By zipInputFieldLocator = By.Name("zip");
        private By noZipCodeCheckBoxLocator = By.XPath("//div[@class='sa-form']//label[@class='sa-no-zip-code']/input");
        private By phoneCountryLocator = By.Name("phoneCountry");
        private By mobileNumberInputFieldLocator = By.Name("mobileNo");
        private By setAsDefaultCheckBoxLocator = By.XPath("//div[@class='sa-form']//input[@name='isDefault']");


        public IWebElement AddNewAddressButton => driver.FindElement(addNewAddressButtonLocator);
        public IWebElement ContactPersonInputField => driver.FindElement(contactPersonInputFieldLocator);
        public IWebElement CountryDropDownList => driver.FindElement(countryDropDownListLocator);
        public IWebElement AddressInputField => driver.FindElement(addressInputFieldLocator);
        public IWebElement ApartmentInputField => driver.FindElement(appartmentInputFieldLocator);
        public IWebElement StateProvinceDropDownList => driver.FindElement(stateProvinceDropDownListLocator);
        // City field can be input or drop down list depending on the Country / State selection
        public IWebElement CityInputField => driver.FindElement(cityInputFieldLocator);
        public IWebElement CityDropDownList => driver.FindElement(cityDropDownListLocator);
        public IWebElement ZipInputField => driver.FindElement(zipInputFieldLocator);
        public IWebElement NoZipCodeCheckBox => driver.FindElement(noZipCodeCheckBoxLocator);
        public IWebElement PhoneCountryInputField => driver.FindElement(phoneCountryLocator);
        public IWebElement MobileNumberInputField => driver.FindElement(mobileNumberInputFieldLocator);
        public IWebElement SetAsDefaultCheckBox => driver.FindElement(setAsDefaultCheckBoxLocator);

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

        private By contactNameErrorMessageLocator = By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[1]//p[@class='sa-error-tips']");
        private By countryRegionErrorMessageLocator = By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[2]//p[@class='sa-error-tips']");
        private By streetAddressErrorMessageLocator = By.XPath("//div[@id='address-main']/div[@class='sa-form']//div[3]//p[@class='sa-error-tips']");
        private By stateProvinceRegionErrorMessageLocator => By.XPath("//div[@id='address-main']/div[@class='sa-form']//div[4]//p[@class='sa-error-tips']");
        private By cityErrorMessageLocator = By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[5]//p[@class='sa-error-tips']");
        private By zipErrorMessageLocator = By.XPath("//div[@id='address-main']/div[@class='sa-form']//div[6]//p[@class='sa-error-tips']");
        private By mobileNumberErrorMessageLocator = By.XPath("//div[@id='address-main']/div[@class='sa-form']/div[7]//p[@class='sa-error-tips']");

        public IWebElement ContactNameErrorMessage => driver.FindElement(contactNameErrorMessageLocator);
        public IWebElement CountryRegionErrorMessage => driver.FindElement(countryRegionErrorMessageLocator);
        public IWebElement StreetAddressErrorMessage => driver.FindElement(streetAddressErrorMessageLocator);
        public IWebElement StateProvinceRegionErrorMessage => driver.FindElement(stateProvinceRegionErrorMessageLocator);
        public IWebElement CityErrorMessage => driver.FindElement(cityErrorMessageLocator);
        public IWebElement ZipErrorMessage => driver.FindElement(zipErrorMessageLocator);
        public IWebElement MobileNumberErrorMessage => driver.FindElement(mobileNumberErrorMessageLocator);


        // BUTTONS

        private By saveButtonLocator = By.LinkText("Save");
        private By cancelButtonLocator = By.LinkText("Cancel");

        public IWebElement SaveButton => driver.FindElement(saveButtonLocator);
        public IWebElement CancelButton => driver.FindElement(cancelButtonLocator);

        #endregion Page Element Locators

        #region Constructors
        public ShippingAddressPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver)
        {
            this.wait = wait;
        }

        #endregion Constructors

        #region Methods

        public bool CheckErrorMessage(IWebElement element, string message)
        {
            return element.Text.Equals(message);
        }

        public bool IsContactErrorMessagePresentAndCorrect()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(contactNameErrorMessageLocator));
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
                wait.Until(ExpectedConditions.ElementIsVisible(countryRegionErrorMessageLocator));
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
                wait.Until(ExpectedConditions.ElementIsVisible(streetAddressErrorMessageLocator));
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
                wait.Until(ExpectedConditions.ElementIsVisible(stateProvinceRegionErrorMessageLocator));
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
                wait.Until(ExpectedConditions.ElementIsVisible(cityErrorMessageLocator));
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
                wait.Until(ExpectedConditions.ElementIsVisible(zipErrorMessageLocator));
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
                wait.Until(ExpectedConditions.ElementIsVisible(mobileNumberErrorMessageLocator));
                return CheckErrorMessage(MobileNumberErrorMessage, mobileNoErrMsgTxt);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("DEBUG: Mobile number error message has not been found: " + e.Message);
                return false;
            }

        }


        // TODO: Change to: getting collection of the address boxes, find elements within elements and check text
        public bool IsAddressPresent(Address adr)
        {       
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(allAddressBoxesLocator));

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
            wait.Until(ExpectedConditions.ElementToBeClickable(addNewAddressButtonLocator));
            wait.Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete"));
            AddNewAddressButton.Click();
            wait.Until(d => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        // TODO: add success icon checks (1.input 2.click on form 3.check for icon)
        public void FillShippingAddressForm(Address adr)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(contactPersonInputFieldLocator));
            SendText(ContactPersonInputField, adr.contactName);
            wait.Until(ExpectedConditions.ElementToBeClickable(countryDropDownListLocator));
            SelectDropDown(CountryDropDownList, adr.countryRegion);
            SendText(AddressInputField, adr.streetAddress);
            SendText(ApartmentInputField, adr.apartment);
            wait.Until(ExpectedConditions.ElementToBeClickable(stateProvinceDropDownListLocator));
            SelectDropDown(StateProvinceDropDownList, adr.stateProvinceRegion);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityDropDownListLocator));
            SelectDropDown(CityDropDownList, adr.city);
            SendText(ZipInputField, adr.zip);
            PhoneCountryInputField.Clear();
            SendText(PhoneCountryInputField, adr.mobileNoCountryCode);
            SendText(MobileNumberInputField, adr.mobileNumber);
        }

        public void ClearCountryDropDown()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CountryDropDownList));
            SelectDropDown(CountryDropDownList, countryDropDownNotSelectedValue);
        }

        public void ShippingAddressFormSave()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(saveButtonLocator));
            Click(SaveButton);
        }

        public void ShippingAddressFormCancel()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(cancelButtonLocator));
            Click(CancelButton);
        }

        #endregion Methods
    }
}
