using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class Cart : SuperPage
    {
        public Cart(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string remove = @"#\33 2869686576-200000828\3a 200003982\23 iphone\20 6\20 \20 16GB\3b 14\3a 350850\23 Gold > td.product-operate > div > form > a";
        private const string piece = @"#\33 2846486845-200000828\3a 200003985\23 Used\20 iPhone\20 7\3b 14\3a 200001438\23 256GB\20 Rose\20 Gold > td.product-quantity > input.product-quantity-input.ui-textfield.ui-textfield-system";
        private const string addPiece = "quantity-add";
        private const string addOk = "btn-ok-quantity";
        private const string buy = "#page > div.util-clearfix > div > div.bottom-info.util-clearfix > div.bottom-info-right > div.bottom-info-right-wrapper > form > input.buy-now.ui-button.ui-button-primary.ui-button-large";
        #endregion

        #region webElements

        private IWebElement Remove
        {
            get { return driver.FindElement(By.CssSelector(remove)); }
        }

        private IWebElement Piece
        {
            get { return driver.FindElement(By.CssSelector(piece)); }
        }

        private IWebElement AddPiece
        {
            get { return driver.FindElement(By.Id(addPiece)); }
        }

        private IWebElement AddOk
        {
            get { return driver.FindElement(By.Id(addOk)); }
        }

        private IWebElement Buy
        {
            get { return driver.FindElement(By.CssSelector(buy)); }
        }

        #endregion

        public void Finish()
        {
            Thread.Sleep(3000);
            Click(Remove);
            Thread.Sleep(3000);
            Click(Piece);
            Thread.Sleep(3000);
            Click(AddPiece);
            Thread.Sleep(3000);
            Click(AddOk);
            Thread.Sleep(3000);
            Click(Buy);
            Thread.Sleep(3000);
            Assert.Pass();
        }


    }
}
