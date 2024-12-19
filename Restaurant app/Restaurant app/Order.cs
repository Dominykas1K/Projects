namespace Restaurant_app
{
    public class Order
    {
        public Table Table { get; set; }
        public string OrderedItems { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateTime { get; set; }

        public Order(Table table)
        {
            Table = table;
        }
    }
}
