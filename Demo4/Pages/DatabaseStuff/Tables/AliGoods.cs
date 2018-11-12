namespace Pages.DatabaseStuff
{
    public class AliGoods
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Orders { get; set; }

        public bool EqualsGoods(AliGoods aliGoods)
        {
            return this.Orders == aliGoods.Orders;
        }
    }
}
