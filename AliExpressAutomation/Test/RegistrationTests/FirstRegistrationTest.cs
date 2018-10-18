using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;
using Pages.EvgenPages;
using OpenQA.Selenium;
using Pages.VaniaPages;
using Pages.VasylPages;

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
    #endregion
    #region Tests by Kostya
    #endregion
    #region Tests by Anna
    #endregion
}

