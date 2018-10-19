using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Pages.KostiantynPages.Helpers
{
    public class WaitUtilities
    {
        public static string JsDocumentLoadState(IWebDriver driver)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            string documentLoadState = jsExec.ExecuteScript("return document.readyState").ToString();
            return documentLoadState;
        }

    }
}