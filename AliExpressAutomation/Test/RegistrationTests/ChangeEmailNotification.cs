using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.VaniaPages;
using Pages.AnnPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests.RegistrationTests
{
    [TestFixture]
    public class ChangeEmailNotification
    {
        [Test]
        public void CheckEmailNotification()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
            {
                var mainPageAliexpress = new MainPageAliexpress(dr);
                //  var searchProductForWishes = mainPageAliexpress.MainPageGoToLogin();
                var AccountSettingsPage = AccountSettingsPage.GotoEmailSubscriptionPage();
                var AccountSettingsPage = EmailSubscriptionPage.CheckStatusSubscription();



            }
        }
    }
}