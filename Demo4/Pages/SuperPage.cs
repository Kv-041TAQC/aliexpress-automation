using OpenQA.Selenium;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Pages
{
    public abstract class SuperPage
    {
        #region Custom Methods
        protected string[,] Phones = new string[144,2];
        /// <summary>
        /// <para>Custome method for clicking on element</para>
        /// <para>In param send WebElement, in which u whant to click</para>
        /// </summary>
        /// <param name="element">Element.</param>
        protected virtual void Click(IWebElement element)
        {
            element.Click();
            Thread.Sleep(3000);
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
        protected void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(8000);
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
        
        /// <summary>
        /// <para>Custom method for taking screenshot</para>
        /// </summary>
        public void TakeScreenShot()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile($"..\\..\\..\\ScreenShots\\ScreenShot.png", ScreenshotImageFormat.Png);
        }
        #endregion
        #region Constants
        protected IWebDriver driver;
        protected Actions actionshandler;//For extra actions
        protected IAlert alerthandler;
        #endregion
        protected SuperPage(IWebDriver driver)
        {
            actionshandler = new Actions(driver);
            this.driver = driver;
        }
    }
}