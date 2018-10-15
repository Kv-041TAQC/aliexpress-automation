using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages.VaniaPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests.RegistrationTests
{
 [TestFixture]
    public class TestsMyWishesIvan
    {
        [Test]
        public void PositiveTestMyWishes()
        {
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory()))
            {
                var mainPageAliexpress = new MainPageAliexpress(dr);
                var login = mainPageAliexpress.MainPageGoToLogin();
                var mainPageAliexpressAutorized = login.LoginAccount();
                var searchProductForWishes = mainPageAliexpressAutorized.SearchProduct();
                var myWishesPage = searchProductForWishes.AddProductToWishes();
                var creatingNewListWishesPage = myWishesPage.MyWishesCreateList();
                var myWishesPageWithNewList = creatingNewListWishesPage.CreateNewList(true);
                myWishesPageWithNewList.MyWishesCreateList();
            }
        }
    }
}
