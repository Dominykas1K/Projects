namespace Restaurant_app
{
    public class Order
    {
        public int Table { get; set; }
        public string OrderedItems { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateTime { get; set; }

    }
}
