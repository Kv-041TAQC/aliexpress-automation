using System;
using System.Collections.Generic;
using System.Text;
using Pages.DatabaseStuff;

namespace Pages.HelpClass
{
    /// <summary>
    /// <para>Class for convert from array of struct to array of objects</para>
    /// </summary>
    public class HelpClass
    {
        #region Methods
        /// <summary>
        /// <para>Empty constructor</para>
        /// </summary>
        public HelpClass()
        {

        }
        /// <summary>
        /// <para>Converter from array of struct to array of objects</para>
        /// </summary>
        /// <param name="aliGoods">Array with objects</param>
        public void ConverterStructGoodsToClass(AliGoods[] aliGoods)
        {
            for (int i = 0; i < SuperPage.countPhone; i++)
            {
                aliGoods[i] = new AliGoods();
                aliGoods[i].Name = SuperPage.phones[i].name;
                aliGoods[i].Price = SuperPage.phones[i].price;
                aliGoods[i].Orders = SuperPage.phones[i].orders;
            }
        }

        #endregion
    }
}
