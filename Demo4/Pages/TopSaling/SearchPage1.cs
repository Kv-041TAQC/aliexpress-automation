using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pages.TopSaling
{
    /// <summary>
    /// <para>Class of first search page with goods in Aliexpress website</para>
    /// </summary>
    public class SearchPage1 : SuperPage
    {
        #region Constants
        protected int minimumForTopSaling = 1000;
        protected int maxPhonesOnPages = 48;
        private string cssFirstGoodName = "#list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.detail > h3 > a > span";
        private string cssFirstGoodPrice = "#list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.info.infoprice > span > span.value";
        private string cssFirstGoodOrders = "#list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em";
        private string cssButtonSecondPage = "#pagination-bottom > div.ui-pagination-navi.util-left > span";
        private string firstHalfCss = "#list-items > li:nth-child(";
        private string secondHalfCssPrice = ") > div.right-block.util-clearfix > div > div.info.infoprice > span > span.value";
        private string secondHalfCssName = ") > div.right-block.util-clearfix > div > div.detail > h3 > a > span";
        private string secondHalfCssOrders = ") > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em";
        private char symbolSpace= ' ';
        private char symbolComa = ',';
        private char symbolHyphen = '-';
        private char symbolRusR = 'р';
        #endregion
        
        #region Methods
        /// <summary>
        /// <para>Method for go to main page Aliexpress</para>
        /// </summary>
        /// <param name="driver">Web Driver.</param>
        public SearchPage1(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// <para>Method for parse orders</para>
        /// </summary>
        /// <param name="notParseOrder">String for parse orders.</param>
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
        /// <summary>
        /// <para>Method for parse price</para>
        /// </summary>
        /// <param name="price">String for parse price.</param>
        protected decimal ParsePrice(string price)
        {
            char[] priceChars = price.ToCharArray();
            price = "";
            foreach(char symbol in priceChars)
            {
                if (symbol == symbolSpace)
                    continue;
                else if(symbol == symbolComa)
                {
                    price += symbolComa;
                    continue;
                }
                else if (symbol == symbolHyphen || symbol == symbolRusR)
                    break;
                else
                    price += symbol;

            }
            decimal result;
            decimal.TryParse(price, out result);
            return result;
        }


        /// <summary>
        /// <para>Method for adding Top goods in array</para>
        /// </summary>
        public void FindAndWriteTopPhones()
        {
            try
            {
                var firstNameElement = CssSearchWebElements(cssFirstGoodName);
                var firstPriceElement = CssSearchWebElements(cssFirstGoodPrice);
                var firstOrdersElement = CssSearchWebElements(cssFirstGoodOrders);
                int firstOrders = ParseOrders(firstOrdersElement.Text);
                if (firstOrders > minimumForTopSaling)
                {
                    phones[countPhone].name = firstNameElement.Text;
                    phones[countPhone].price = ParsePrice(firstPriceElement.Text);
                    phones[countPhone].orders = ParseOrders(firstOrdersElement.Text);
                    countPhone++;
                }
            }

            catch { }
 

            for (int i = 2; i <= maxPhonesOnPages; i++)
            {
                string ordersCss = firstHalfCss + Convert.ToString(i) + secondHalfCssOrders;
                int orders = 0;
                try
                {
                    var ordersElement = CssSearchWebElements(ordersCss);
                    orders = ParseOrders(ordersElement.Text);
                }
                catch (NoSuchElementException)
                {                  
                }

                if (orders > minimumForTopSaling)
                {
                    string nameCss = firstHalfCss + Convert.ToString(i) + secondHalfCssName;
                    var nameElement = CssSearchWebElements(nameCss);
                    string priceCss = firstHalfCss + Convert.ToString(i) + secondHalfCssPrice;
                    var priceElement = CssSearchWebElements(priceCss);

                    phones[countPhone].name = nameElement.Text;
                    phones[countPhone].price = ParsePrice(priceElement.Text);
                    phones[countPhone].orders = orders;
                    countPhone++;
                }

            }
        }

        /// <summary>
        /// <para>Method for go to next page of goods</para>
        /// </summary>
        public SearchPage2 GoToSecondPage()
        {
            Click(CssSearchWebElements(cssButtonSecondPage));
            return new SearchPage2(driver);
        }

        #endregion
    }
}