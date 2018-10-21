using System.Threading;
using OpenQA.Selenium;
using Pages.KostiantynPages;

namespace Pages.VasylPages
{
    public class LocalMainMethodsPage : AliExpressHomePage
    {
        public LocalMainMethodsPage(IWebDriver driver) : base(driver)
        {
        }

        public MyShoppingPage NextPageFrance()
        {
            Thread.Sleep(2000);
            SendText(SearchField, alijson.ValidData[1]);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new MyShoppingPage(driver);
        }

        public MyShoppingPage NextPageEnglish()
        {
            driver.Manage().Window.FullScreen();
            NavigateToAliExpressHomepage();
            Thread.Sleep(15000);
            Click(AdsCloseButton);
            Thread.Sleep(5000);
            Click(GoToGlobalSiteLink);
            Thread.Sleep(3000);
            SendText(SearchField, alijson.ValidData[1]);
            Thread.Sleep(1000);
            Click(SearchButton);
            Thread.Sleep(1000);
            return new MyShoppingPage(driver);
        }
    }
}
