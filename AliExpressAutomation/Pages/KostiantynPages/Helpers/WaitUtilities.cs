using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AliExpress.Helpers
{
    public class WaitUtilities
    {

        public static void WaitForElement(IWebDriver driver, IWebElement element, double timeoutSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            Console.WriteLine($"Waiting for {element.GetAttribute("class")} to appear.");
        }

    }
}