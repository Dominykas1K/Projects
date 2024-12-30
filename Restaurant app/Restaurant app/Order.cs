namespace Restaurant_app
{
    public class Order(Table table)
    {
        public Table Table { get; set; } = table;
        public List<MenuItems> OrderedItems { get; set; } = new List<MenuItems>();
        public decimal TotalPrice => CalculateTotalPrice();
        public DateTime DateTime { get; set; } = DateTime.Now;

        public void AddItem(MenuItems item)
        {
            OrderedItems.Add(item);
        }

        public decimal CalculateTotalPrice() => OrderedItems.Sum(x => x.Price);
    }
}
