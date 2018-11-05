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
        private string cssButtonSecondPage = "#pagination-bottom > div.ui-pagination-navi.util-left > span";
        private string firstHalfXpath = "//*[@id='list-items']/li[";

        //private string firstHalfXpathPrice = "//*[@id='list-items']/li[";
        private string secondHalfXpathPrice = "]/div[1]/div/div[2]/span/span[1]";

        //private string firstHalfXpathName = "//*[@id='list-items']/li[";
        private string secondHalfXpathName = "]/div[1]/div/div[1]/h3/a/span";

        //private string firstHalfXpathOrders = "//*[@id='list-items']/li[";
        private string secondHalfXpathOrders = "]/div[1]/div/div[2]/div[2]/span[3]/a/em";

        #endregion

        #region WebElements
        protected IWebElement SearchWebElements(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }
        private IWebElement ButtonSecondPage => driver.FindElement(By.CssSelector(cssButtonSecondPage));

        #endregion
//# list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em
//# list-items > li.list-item.list-item-first.util-clearfix.list-item-180 > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em
//# list-items > li:nth-child(2) > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em
//# list-items > li:nth-child(14) > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em
//# list-items > li:nth-child(35) > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em
//# list-items > li:nth-child(48) > div.right-block.util-clearfix > div > div.info.infoprice > div.rate-history > span.order-num > a > em
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

        protected void FindAndWriteTopPhones()
        {
            for (int i = 1; i <= maxPhonesOnPages; i++)
            {
                string ordersXpath = firstHalfXpath + i + secondHalfXpathOrders;
                var ordersElement = SearchWebElements(ordersXpath);
                int orders = ParseOrders(ordersElement.Text);
                if (orders > minimumForTopSaling)
                {
                    string nameXpath = firstHalfXpath + i + secondHalfXpathName;
                    var nameElement = SearchWebElements(nameXpath);
                    string priceXpath = firstHalfXpath + i + secondHalfXpathPrice;
                    var priceElement = SearchWebElements(priceXpath);
                    phones[countPhone].name = nameElement.Text;
                    phones[countPhone].price = priceElement.Text;
                    phones[countPhone].orders = orders;
                    countPhone++;
                }

            }
        }

        public SearchPage2 WriteTopPhonesAndGoToSecondPage()
        {
            FindAndWriteTopPhones();
            Click(ButtonSecondPage);
            return new SearchPage2(driver);
        }

        #endregion
    }
}