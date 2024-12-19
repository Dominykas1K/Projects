using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_app
{
    public class MenuItems
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItems(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
