using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AliExpress.Helpers
{
    public class WaitUtilities
    {
        /* 
                public static void WaitForElement(IWebDriver driver, Func<IWebDriver, IWebElement>, double timeoutSeconds)
                {      
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                    wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                    // wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    wait.Until(condition);
                    // Console.WriteLine($"Waiting for {element.GetAttribute("class")} to appear.");
                }
        */
        public static void WaitUntilPageLoaded(IWebDriver driver)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            string documentLoadState;

            do
            {
                documentLoadState = (string)jsExec.ExecuteScript("return document.readyState");
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
            while (documentLoadState.Equals("interactive "));

        }

    }
}