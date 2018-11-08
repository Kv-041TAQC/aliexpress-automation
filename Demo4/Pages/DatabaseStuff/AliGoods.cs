using System;
using System.Collections.Generic;
using System.Text;

namespace Pages.DatabaseStuff
{
    public class AliGoods : MainTable
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
