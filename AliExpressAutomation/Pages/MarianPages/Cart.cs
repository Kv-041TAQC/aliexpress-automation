using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Pages.MarianPages
{
    public class Cart : SuperPage
    {
        public Cart(IWebDriver driver) : base(driver)
        {
        }

        #region constants

        private const string remove = @"#\33 2528638346-200000828\3a 200003982\23 S6\20 G920F\3b 14\3a 29\23 Black > td.product-operate > div > form > a";
        private const string piece = @"#\33 2846412268-200000828\3a 200003982\23 S8-\28 G950F\29 \3b 14\3a 193\23 Black\20 \28 Single\20 Sim\29 > td.product-quantity > input.product-quantity-input.ui-textfield.ui-textfield-system";
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
            get { return driver.FindElement(By.CssSelector(addPiece)); }
        }

        private IWebElement AddOk
        {
            get { return driver.FindElement(By.CssSelector(addOk)); }
        }

        private IWebElement Buy
        {
            get { return driver.FindElement(By.CssSelector(buy)); }
        }

        #endregion

        public ResultSamsung ChooseSamsung8()
        {
            Thread.Sleep(1000);
            Click(Remove);
            Click(Piece); ;
            Click(AddPiece);
            Click(AddOk);
            Click(Buy);
            return new ResultSamsung(driver);
        }


    }
}
