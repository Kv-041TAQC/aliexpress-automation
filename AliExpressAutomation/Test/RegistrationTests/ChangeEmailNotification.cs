using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.VaniaPages;
using Pages.AnnPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Tests.RegistrationTests
{
    //[TestFixture]
    //public class CheckEmailNotification
    //{
    //    [Test]
    //    public void CheckEmailNotificationTest()
    //    {
    //        ChromeOptions options = new ChromeOptions();
    //        options.PageLoadStrategy = PageLoadStrategy.None;
    //        using (ChromeDriver dr = new ChromeDriver(Directory.GetCurrentDirectory(), options))
    //        {
    //            var mainPageAliexpress = new MainPageAliexpress(dr);
    //            var accountHomePage = mainPageAliexpress.GoToAccountHomePage();
    //            var accounSettingsPage = accountHomePage.GotoAccountSettingsPage();
    //            var emailSubscriptionPage = accounSettingsPage.GotoEmailSubscriptionPage();
    //           // Assert.True(emailSubscriptionPage.CheckStatusSubscription("Enabled"));
                
    //        }
    //    }

        
    //}

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
                emailSubscriptionPage.ClickButtons();
                //Assert.True(emailSubscriptionPage.CheckStatusSubscription("Disabled"));
                               
            }
        }


    }
}