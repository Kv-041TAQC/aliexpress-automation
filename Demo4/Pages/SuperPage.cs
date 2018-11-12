using OpenQA.Selenium;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Pages.HelpClass;

namespace Pages
{
    /// <summary>
    /// <para>Abstract class with needed some methods and constants for testing Aliexpress</para>
    /// </summary>
    public abstract class SuperPage
    {
        #region Constants
        protected IWebDriver driver;
        protected Actions actionshandler;
        protected IAlert alerthandler;

        public static Phone[] phones;
        public static int countPhone;
        #endregion

        #region Custom Methods
        /// <summary>
        /// <para>Constructor with driver</para>
        /// </summary>
        /// <param name="driver">driver.</param>
        protected SuperPage(IWebDriver driver)
        {
            actionshandler = new Actions(driver);
            this.driver = driver;

        }

        /// <summary>
        /// <para>Custome method for finding element by css</para>
        /// </summary>
        /// <param name="css">Css.</param>
        protected IWebElement CssSearchWebElements(string css)
        {
            return driver.FindElement(By.CssSelector(css));
        }
        /// <summary>
        /// <para>Custome method for finding element by id</para>
        /// </summary>
        /// <param name="id">ID.</param>
        protected IWebElement IDSearchWebElements(string id)
        {
            return driver.FindElement(By.Id(id));
        }
        /// <summary>
        /// <para>Custome method for finding element by xpath</para>
        /// </summary>
        /// <param name="xpath">Xpath.</param>
        protected IWebElement XpathSearchWebElements(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }
        /// <summary>
        /// <para>Custome method for finding element by className</para>
        /// </summary>
        /// <param name="className">ClassName.</param>
        protected IWebElement ClassNameSearchWebElements(string className)
        {
            return driver.FindElement(By.ClassName(className));
        }
        /// <summary>
        /// <para>Custome method for clicking on element</para>
        /// <para>In param send WebElement, in which u whant to click</para>
        /// </summary>
        /// <param name="element">Element.</param>
        protected virtual void Click(IWebElement element) {
           Thread.Sleep(10000);
	   element.Click();
           Thread.Sleep(10000);
        }
        /// <summary>
        /// <para>Custome method for sending text in WebElements</para>
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="message">Message.</param>
        protected virtual void SendText(IWebElement element,string message) => element.SendKeys(message);
        /// <summary>
        /// <para>Custom method for selecting dropdown</para>
        /// <para>In param send webelement and value, which u whant to select</para>
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="value">Value.</param>
        protected virtual void SelectDropDown(IWebElement element,string value) => new SelectElement(element).SelectByText(value);
        /// <summary>
        /// Navigates to URL.
        /// </summary>
        /// <param name="url">URL.</param>
        protected void NavigateToUrl(string url) {
			driver.Navigate().GoToUrl(url);
			Thread.Sleep(5000);
        }
		/// <summary>
        /// Maximizes the window.
        /// </summary>
        protected void MaximizeWindow() => driver.Manage().Window.Maximize();
        /// <summary>
        /// <para>Custom method for changing screensize settings.</para>
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="heith">Heith.</param>
        protected void ScreenSizeSettings(int width, int heith)
        {
            System.Drawing.Size settings = new System.Drawing.Size(width, heith);
            driver.Manage().Window.Size = settings;
        }
        /// <summary>
        /// Custom method for stepping forward.
        /// </summary>
        protected void StepForward()
        {
            driver.Navigate().Forward();
        }
        /// <summary>
        /// Custom method for stepping back.
        /// </summary>
        protected void StepBack()
        {
            driver.Navigate().Back();
        }
        #endregion
    }
}
