using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pages.TopSaling
{
    public class SearchPage1 : SuperPage
    {
        public SearchPage1(IWebDriver driver) : base(driver) { }

        #region Constants
        protected int minimumForTopSaling = 1000;
        protected int maxPhonesOnPages = 48;
        private string cssFirstGoodName = "#list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.detail > h3 > a > span";
        private string cssFirstGoodPrice = "#list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.info.infoprice > span > span.value";
        private string cssFirstGoodOrders = "#list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em";
        private string cssButtonSecondPage = "#pagination-bottom > div.ui-pagination-navi.util-left > span";
        private string firstHalfCss = "#list-items > li:nth-child(";



        //private string firstHalfXpathPrice = "//*[@id='list-items']/li[";
        private string secondHalfCssPrice = ") > div.right-block.util-clearfix > div > div.info.infoprice > span > span.value";

        //private string firstHalfXpathName = "//*[@id='list-items']/li[";
        private string secondHalfCssName = ") > div.right-block.util-clearfix > div > div.detail > h3 > a > span";

        //private string firstHalfXpathOrders = "//*[@id='list-items']/li[";
        private string secondHalfCssOrders = ") > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em";

        #endregion

        #region WebElements
        protected IWebElement SearchWebElements(string css)
        {
            return driver.FindElement(By.CssSelector(css));
        }
        private IWebElement ButtonSecondPage => driver.FindElement(By.CssSelector(cssButtonSecondPage));

        #endregion

        #region Methods
        protected int ParseOrders(string notParseOrder)
        {
            string parseOrder = "";
            char[] symbolsOrder = notParseOrder.ToCharArray();
            foreach (char symbol in symbolsOrder)
            {
                if (char.IsDigit(symbol) == true)
                {
                    parseOrder += symbol;
                }
            }
            return Convert.ToInt32(parseOrder);
        }

        public void FindAndWriteTopPhones()
        {
                var firstNameElement = SearchWebElements(cssFirstGoodName);
                var firstPriceElement = SearchWebElements(cssFirstGoodPrice);
                var firstOrdersElement = SearchWebElements(cssFirstGoodOrders);
                phones[0].name = firstNameElement.Text;
                phones[0].price = firstPriceElement.Text;
                phones[0].orders = ParseOrders(firstOrdersElement.Text);

            for (int i = 2; i <= maxPhonesOnPages; i++)
            {
                string ordersCss = firstHalfCss + Convert.ToString(i) + secondHalfCssOrders;
                var ordersElement = SearchWebElements(ordersCss);
                int orders = ParseOrders(ordersElement.Text);
                if (orders > minimumForTopSaling)
                {
                    string nameCss = firstHalfCss + Convert.ToString(i) + secondHalfCssName;
                    var nameElement = SearchWebElements(nameCss);
                    string priceCss = firstHalfCss + Convert.ToString(i) + secondHalfCssPrice;
                    var priceElement = SearchWebElements(priceCss);
                    phones[countPhone].name = nameElement.Text;
                    phones[countPhone].price = priceElement.Text;
                    phones[countPhone].orders = orders;
                    countPhone++;
                }

            }
        }

        public SearchPage2 GoToSecondPage()
        {
            //FindAndWriteTopPhones();
            Click(ButtonSecondPage);
            return new SearchPage2(driver);
        }

        #endregion
    }
}