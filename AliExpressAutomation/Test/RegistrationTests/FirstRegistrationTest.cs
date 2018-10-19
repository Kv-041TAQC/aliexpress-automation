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
                dr.Manage().Window.Maximize();
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
                var mainPage = new MyMainPage(dr);
                var searchPage = mainPage.NextPage();
                var goodsPage = searchPage.NextPage();
                var cartPage = goodsPage.NextPage();
                var franceMainPage = cartPage.Nextpage();
                var franceSearchPage = franceMainPage.NextPage();
                var franceGoodsPage = franceSearchPage.NextPage();
                cartPage = franceGoodsPage.NextPage();
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
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var mainPageAliexpress = new MainPageAliexpress(dr);
                var accountHomePage = mainPageAliexpress.GoToAccountHomePage();
                var accounSettingsPage = accountHomePage.GotoAccountSettingsPage();
                var emailSubscriptionPage = accounSettingsPage.GotoEmailSubscriptionPage();
                emailSubscriptionPage.ClickButtonsSubscription();
            }
        }
    }
    #endregion
}

