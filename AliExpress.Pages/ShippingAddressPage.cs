using System;
using OpenQA.Selenium;



namespace AliExpress.Pages
{
    public class ShippingAddressPage
    {
        private IWebDriver driver;
        public ShippingAddressPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #region Page Element Locators
        // 10 elements

        // <input name="contactPerson" class="ui-textfield ui-textfield-system sa-contact-name js-input-field sa-error-field" type="text" maxlength="128" data-spm-anchor-id="a2g0s.8850659.0.i1.3d4a4c4dw7y1kW">
        public IWebElement ContactPersonInputField => driver.FindElement(By.Name("contactPerson"));

        // <select name="country" class="ui-textfield ui-textfield-system sa-country" data-spm-anchor-id="a2g0s.8850659.0.i3.3d4a4c4dw7y1kW"><</option></select>
        public IWebElement CountryDropDownList => driver.FindElement(By.Name("country"));

        // <input name="address" class="ui-textfield ui-textfield-system js-input-field" type="text" placeholder="Street address" maxlength="256">
        public IWebElement AddressInputField => driver.FindElement(By.Name("address"));

        // <input name="address2" class="ui-textfield ui-textfield-system js-input-field" type="text" placeholder="Apartment, suite, unit etc. (optional)" maxlength="256">
        public IWebElement ApartmentInputField => driver.FindElement(By.Name("address2"));

        // TODO: use better Xpath here, or something else
        // <select class="ui-textfield ui-textfield-system" style="display: inline-block;"></select>
        // //div[@id='address-main']/div[@class='sa-form']/div[@class='row sa-form-group sa-province-group']/div/select[@class='ui-textfield ui-textfield-system']
        public IWebElement StateProvinceDropDownList => driver.FindElement(
            By.XPath("//div[@class='sa-form']/div[@class='row sa-form-group sa-province-group']/div/select"));

        // <input name="city" type="text" class="ui-textfield ui-textfield-system sa-error-field" maxlength="64" data-spm-anchor-id="a2g0s.8850659.0.i1.46b34c4dhEovLL" style="display: inline-block;">
        public IWebElement CityInputField => driver.FindElement(By.Name("city"));

        // <input name="zip" class="ui-textfield ui-textfield-system sa-zip js-input-field" type="text" maxlength="10">
        public IWebElement ZipInputField => driver.FindElement(By.Name("zip"));

        // <input type="checkbox" class="js-checkbox-field" value="" style="">
        public IWebElement NoZipCodeCheckBox => driver.FindElement(By.XPath("//div[@class='sa-form']//label[@class='sa-no-zip-code']/input"));

        // <input name="phoneCountry" class="ui-textfield ui-textfield-system sa-country-code js-input-field" type="text" maxlength="8">
        public IWebElement PhoneCountryInputField => driver.FindElement(By.Name("phoneCountry"));

        // <input name="mobileNo" class="ui-textfield ui-textfield-system sa-phone-number js-input-field" type="text" maxlength="16">
        public IWebElement MobileNumberInputField => driver.FindElement(By.Name("mobileNo"));

        // <input type="checkbox" class="js-input-field" name="isDefault" value="" style="">
        // //div[@id='address-main']/div[@class='sa-form']//input[@name='isDefault']
        public IWebElement SetAsDefaultCheckBox => driver.FindElement(By.XPath("//div[@class='sa-form']//input[@name='isDefault']"));

        // <a href="javascript:;" class="ui-button ui-button-primary ui-button-medium sa-confirm" style="">Save</a>
        public IWebElement SaveButton => driver.FindElement(By.LinkText("Save"));

        // <a href="javascript:;" class="ui-button ui-button-normal ui-button-medium sa-cancel" style="display: inline-block;">Cancel</a>
        public IWebElement CancelButton => driver.FindElement(By.LinkText("Cancel"));

        #endregion

        // TODO: should methods a la InputCity() be created or just one fill form method
        // probably should if they will randomly generate data in place or get data from JSON file
        // shouldn't they be defined as Set() methods of properties ?


        public void FillShippingAddressForm()
        {

        }
    }
}
