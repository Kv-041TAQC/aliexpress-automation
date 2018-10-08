using OpenQA.Selenium;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public abstract class SuperPage
    {
        protected static IWebDriver driver;
        ////Custom Methods////
        public virtual void Click(IWebElement element) => element.Click();
        public virtual void SendText(IWebElement element,string message) => element.SendKeys(message);
        public virtual void SelectDropDown(IWebElement element,string value) => new SelectElement(element).SelectByText(value);
        public static void NavigateToUrl(string url) => driver.Navigate().GoToUrl(url);
        public static void MaximizeWindow() => driver.Manage().Window.Maximize();
      
        public static void ScreenSizeSettings(int width, int heith)
        {
            System.Drawing.Size settings = new System.Drawing.Size(width, heith);
            driver.Manage().Window.Size = settings;
        }
        protected SuperPage(IWebDriver driver)
        {
            SuperPage.driver = driver;
        }
        ////Work with Json////
        public static void InitializeJsonFile(int numberOfRandomPeople)
        {
            string filename = "..\\..\\..\\HomePayUsers.json";
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
            {
                FileStream filestream = file.Create();
                filestream.Close();
            }
      
        }
         public static void TakeScreenShot()
         {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile($"..\\..\\..\\ScreenShots\\ScreenShot№{HelpClass.NumberOfTests}.png", ScreenshotImageFormat.Png);
            HelpClass.NumberOfTests++;
         }
    }
}
