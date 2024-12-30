namespace Restaurant_app
{
    public class Order
    {
        public Table Table { get; set; }
        public List<MenuItems> OrderedItems { get; set; } = new List<MenuItems>();
        public decimal TotalPrice => CalculateTotalPrice();
        public DateTime DateTime { get; set; }

        public Order(Table table)
        {
            Table = table;
            DateTime = DateTime.Now;
        }

        public void AddItem(MenuItems item)
        {
            OrderedItems.Add(item);
        }

        public decimal CalculateTotalPrice()
        {
            return OrderedItems.Sum(x => x.Price);
        }
    }
}
