using OpenQA.Selenium;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public abstract class SuperPage
    {
        protected 
        protected static IWebDriver driver;
        /// <summary>
        /// <para>Custome method for clicking on element</para>
        /// <para>In param send WebElement, in which u whant to click</para>
        /// </summary>
        /// <param name="element">Element.</param>
        public virtual void Click(IWebElement element) => element.Click();
        /// <summary>
        /// <para>Custome method for sending text in WebElements</para>
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="message">Message.</param>
        public virtual void SendText(IWebElement element,string message) => element.SendKeys(message);
        /// <summary>
        /// <para>Custom method for selecting dropdown</para>
        /// <para>In param send webelement and value, which u whant to select</para>
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="value">Value.</param>
        public virtual void SelectDropDown(IWebElement element,string value) => new SelectElement(element).SelectByText(value);
        /// <summary>
        /// Navigates to URL.
        /// </summary>
        /// <param name="url">URL.</param>
        public static void NavigateToUrl(string url) => driver.Navigate().GoToUrl(url);
        /// <summary>
        /// Maximizes the window.
        /// </summary>
        public static void MaximizeWindow() => driver.Manage().Window.Maximize();
        /// <summary>
        /// <para>Custom method for changing screensize settings.</para>
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="heith">Heith.</param>
        public static void ScreenSizeSettings(int width, int heith)
        {
            System.Drawing.Size settings = new System.Drawing.Size(width, heith);
            driver.Manage().Window.Size = settings;
        }
        protected SuperPage(IWebDriver driver)
        {
            SuperPage.driver = driver;
        }
        /// <summary>
        /// <para>Custom method for initialing the json file where you can find DATA for your tests </para>
        /// </summary>
        public static void InitializeJsonFile()
        {
            string filename = "..\\..\\..\\AliExpressTest.json";
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
            {
                FileStream filestream = file.Create();
                filestream.Close();
            }
      
        }
        /// <summary>
        /// <para>Custom method for taking screenshot</para>
        /// </summary>
         public static void TakeScreenShot()
         {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile($"..\\..\\..\\ScreenShots\\ScreenShot.png", ScreenshotImageFormat.Png);
         }
    }
}
