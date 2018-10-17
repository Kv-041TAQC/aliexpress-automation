using NUnit.Framework;
using OpenQA.Selenium;
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
}