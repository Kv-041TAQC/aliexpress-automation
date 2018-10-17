using OpenQA.Selenium;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using static Pages.HelpClasses.HelpPage;

namespace Pages
{
    public abstract class SuperPage
    {
#region Custom Methods
        /// <summary>
        /// <para>Custome method for clicking on element</para>
        /// <para>In param send WebElement, in which u whant to click</para>
        /// </summary>
        /// <param name="element">Element.</param>
        protected virtual void Click(IWebElement element) => element.Click();
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
        protected void NavigateToUrl(string url) => driver.Navigate().GoToUrl(url);
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
        /// <para>Custom method for initialing the json file where you can find DATA for your tests </para>
        /// </summary>
        private void InitializeJsonFile()
        {
            string filename = "..\\..\\..\\AliExpressTest.json";
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
            {
                FileStream filestream = file.Create();
                filestream.Close();
            }
            for(int i = 0;i < 1;i++)
            {
                alijson = new JsonHandlerClass();
                alijson.Login = "testostesoron@gmail.com";
                alijson.Password = "Qwertytrewq";
                alijson.Wishes = new string[]{"IPhones"};
                alijson.Countries = new string[] { "Ukraine", "Uganda", "StranaAgressor" };
                alijson.Сurrencies = new string[] { "USD", "GRN", "EUR" };
                alijson.Email = "testostesoron@gmail.com";
                alijson.ValidData = new string[] { "IPhone 7", "IPhone 6s", "Samsung Galaxy 8","MacBook Pro 13","JBL Go Mini","Xiaomi Redmi Note 5", "IPhone 6","Samsung Galaxy 7" };
                alijson.InvalidData = new string[] { "Asus aser pro super class","Meizu Middle-14s","Samsung Galaxy-Useless","Asus ZinPone 3.14","Xiaomi mi Nein" };
            }
            using (FileStream fileSt = new FileStream(filename,FileMode.Open))
            {
                jsonSerializer.WriteObject(fileSt, alijson);
            }
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
        internal JsonHandlerClass alijson;
        protected Actions actionshandler;//For extra actions
        protected IAlert alerthandler;
        private DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(JsonHandlerClass));
        #endregion
        protected SuperPage(IWebDriver driver)
        {
            actionshandler = new Actions(driver);
            this.driver = driver;
            InitializeJsonFile();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
    }
}
