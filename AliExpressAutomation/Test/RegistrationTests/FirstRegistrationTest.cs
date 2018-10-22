using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using OpenQA.Selenium;
using Pages.YuraPages;
using System.Threading;
using Pages.MarianPages;
using Pages.VasylPages;
using Pages.VaniaPages;
using Pages.AnnPages;
using Pages.KostiantynPages;
using Pages.KostiantynPages.Helpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace Test
{
    #region Tests by Evgen
    [TestFixture]
    [Parallelizable]
    public class SearchStringPositiveTest
    {
        ChromeOptions options = new ChromeOptions();
        public static int[] arr = new int[] { 0, 1, 2 };

        [Test, TestCaseSource("arr")]
        public void FirstSearchStringPositiveTest(int index)
        {
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunPostiveTest(index);
            }
        }

    }
    [TestFixture]
    [Parallelizable]
    public class SearchStringNegativeTest
    {
        ChromeOptions options = new ChromeOptions();
        static int[] arr = new int[] { 0, 1, 2 };

        [Test, TestCaseSource("arr")]
        public void FirstSearchStringNegativeTest(int index)
        {
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var searchtest = new SearchStringPage(dr);
                searchtest.RunNegativeTest(index);
            }
        }
    }
    #endregion
    #region Tests by Ivan
    [TestFixture]
    [Parallelizable]
    public class TestsMyWishesIvan
    {
        [Test]
        public void PositiveTestMyWishes()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var mainPageAliexpress = new MainPageAliexpress(dr);
                var searchProductForWishes = mainPageAliexpress.MainPageGoToLogin();
                var myWishesPage = searchProductForWishes.AddProductToWishes();
                var creatingNewListWishesPage = myWishesPage.MyWishesCreateList();
                var myWishesPageWithNewList = creatingNewListWishesPage.CreateNewList(true);
                var myWishesPageInAddingList = myWishesPageWithNewList.MyWishesAddProductToList();
                myWishesPageInAddingList.MyWishesDeleteProductInList();
            }
        }
    }
    #endregion
    #region Tests by Marian
    [TestFixture]
    public class TestMarian
    {
        [Test]
        public void CartTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                dr.Manage().Window.FullScreen();
                var mydriver = new Main(dr);
                mydriver.NavigateToAli();
                ResultIPhone resultIPhone6 = mydriver.ChooseIPhone();
                IPhone6 iphone6 = resultIPhone6.GoIPhone6();
                ResultIPhone resultIPhone6s = iphone6.ChooseIPhone6s();
                IPhone6S iphone6S = resultIPhone6s.GoIPhone6s();
                ResultIPhone resultIPhone7 = iphone6S.ChooseIPhone7();
                IPhone7 iphone7 = resultIPhone7.GoIPhone7();
                Cart cart = iphone7.GoToCart();
                cart.Finish();
            }
        }
    }
    #endregion
    #region Tests by Vasyl
    [TestFixture]
    [Parallelizable]
    public class LocalTestbyVasyl
    {
        [Test]
        public void LocalTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var mainPage = new LocalMainMethodsPage(dr);
                var searchPage = mainPage.NextPageEnglish();
                var goodsPage = searchPage.NextPageEnglish();
                var cartPage = goodsPage.NextPageEnglish();
                mainPage = cartPage.Nextpage();
                searchPage = mainPage.NextPageFrance();
                goodsPage = searchPage.NextPageFrance();
                cartPage = goodsPage.NextPageFrance();
                cartPage.RemoveCart();
            }
        }
    }
    #endregion
    #region Tests by Yura
    [TestFixture]
    [Parallelizable]
    public class YuraTest
    {

        [Test]
        public void DifferentCurrency()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), opt))
            {
                var mainPage = new MainPage(dr);
                var searchPage = mainPage.NextPage();
                var productinfo = searchPage.NextPage();
                var cartPage = productinfo.NextPage();
                cartPage.RemoveCart();
            }
        }
    }
    #endregion
    #region Tests by Kostya
    [TestFixture]
    public class ShippingAddrAdditionPositiveTest
    {

        [Test]
        public void ShippingAddressAdditionPositiveTest()
        {

            TestDataHandler dataHandler = new TestDataHandler(@".\ShippingAddressTestData");
            dataHandler.WriteTestData();

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None; // PageLoadStrategy.Eager not supported by Chrome

            using (ChromeDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                driver.Manage().Window.Maximize();
                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                AliExpressHomePage homePage = new AliExpressHomePage(driver, wait);
                homePage.NavigateToAliExpressHomepage();
                homePage.LoginToAliExpress(dataHandler.ReadLoginData());
                MyOrdersPage myOrdersPage = homePage.NavigateToMyOrdersPage();
                ShippingAddressPage shippingAddressPage = myOrdersPage.OpenShippingAddressPage();

                Address adr = dataHandler.ReadAddressData();
                shippingAddressPage.AddNewShippingAddress();
                shippingAddressPage.FillShippingAddressForm(adr);
                shippingAddressPage.ShippingAddressFormSave();
                Assert.True(shippingAddressPage.IsAddressPresent(adr));
            }

        }
    }

    [TestFixture]
    public class ShippingAddrAdditionNegativeTest
    {

        [Test]
        public void ShippingAddressAdditionNegativeTest()
        {

            TestDataHandler dataHandler = new TestDataHandler(@".\ShippingAddressTestData");
            dataHandler.WriteTestData();

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None; // PageLoadStrategy.Eager not supported by Chrome

            using (ChromeDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                driver.Manage().Window.Maximize();

                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                AliExpressHomePage homePage = new AliExpressHomePage(driver, wait);
                homePage.NavigateToAliExpressHomepage();
                homePage.LoginToAliExpress(dataHandler.ReadLoginData());
                MyOrdersPage myOrdersPage = homePage.NavigateToMyOrdersPage();
                ShippingAddressPage shippingAddressPage = myOrdersPage.OpenShippingAddressPage();
                shippingAddressPage.AddNewShippingAddress();
                shippingAddressPage.ClearCountryDropDown();
                shippingAddressPage.ShippingAddressFormSave();

                Assert.Multiple(() =>
                 {
                     Assert.True(shippingAddressPage.IsContactErrorMessagePresentAndCorrect());
                     Assert.True(shippingAddressPage.IsCountryRegionErrorMessagePresentAndCorrect());
                     Assert.True(shippingAddressPage.IsAddressErrorMessagePresentAndCorrect());
                     Assert.True(shippingAddressPage.IsStateErrorMessagePresentAndCorrect());
                     Assert.True(shippingAddressPage.IsCityErrorMessagePresentAndCorrect());
                     Assert.True(shippingAddressPage.IsZipErrorMessagePresentAndCorrect());
                     Assert.True(shippingAddressPage.IsMobileNumberErrorMessagePresentAndCorrect());
                 });


            }

        }
    }




    #endregion
    #region Tests by Anna
    [TestFixture]
    public class ChangeEmailNotification
    {
        [Test]
        public void ChangeEmailNotificationTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
           // using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            using (ChromeDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                driver.Manage().Window.Maximize();
                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                var aliExpressHomePage = new AliExpressHomePage(driver);
                var accountHomePage = aliExpressHomePage.GoToAccountHomePage();
                var accounSettingsPage = accountHomePage.GotoAccountSettingsPage();
                var emailSubscriptionPage = accounSettingsPage.GotoEmailSubscriptionPage();
                emailSubscriptionPage.ClickButtonsSubscription();
            }
        }
    }
    #endregion
}

