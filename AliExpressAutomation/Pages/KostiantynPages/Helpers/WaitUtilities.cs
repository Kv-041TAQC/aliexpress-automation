using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Pages.KostiantynPages.Helpers
{
    public class WaitUtilities
    {
        public static void WaitForElementNTimes(IWebDriver driver, By locator, int time, int numberOfTimes)
        {

            for (int i = 0; i < numberOfTimes; i++)
            {
                try
                {
                    Thread.Sleep(time);
                    driver.FindElement(locator);
                    Console.WriteLine("Sleeping");

                }
                catch (NoSuchElementException e)
                {

                }
            }
        }


        public static string JsDocumentLoadState(IWebDriver driver)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            string documentLoadState = jsExec.ExecuteScript("return document.readyState").ToString();
            return documentLoadState;
        }

    }
}