using System;
using System.Collections.Generic;
using System.Text;
using Pages.DatabaseStuff;

namespace Pages.HelpClass
{
    public class HelpClass
    {
        public HelpClass()
        {

        }

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
 
    }
}
