using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Pages.KostiantynPages.Helpers
{
    public class WaitUtilities
    {
        public static void WaitForElementNTimes(IWebDriver driver, By locator, TimeSpan time, int numberOfRepeats)
        {

            for (int i = 0; i < numberOfRepeats; i++)
            {
                try
                {
                    Console.WriteLine("Trying to find element.");
                    IWebElement element = driver.FindElement(locator);
                    if (element != null)
                    {
                        return;
                    }
                    

                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(time);
                    Console.WriteLine("Sleeping");
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