using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_app
{
    public class RestaurantSystem
    {
        public List<Table> Tables { get; set; } = new List<Table>();
        public Menu Menu { get; set; }
        public Order Order { get; set; }

        public void InitializeSystem()
        {
            for (int i = 0; i <= 10 ; i++)
            {
                Tables.Add(new Table(i, 4));
            }

            Menu.LoadMenuItems("C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\FoodItems.json", "C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\DrinkItems.json");
        }

        public void SystemMenu()
        {
            Console.WriteLine("=== Restaurant System ===");
            Console.WriteLine("1. Staliukai");
            Console.WriteLine("2. Pildyti uzsakyma");
            Console.WriteLine("3. Atlaisvinti staliuka");
            Console.WriteLine("4. Iseiti");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ViewTables();
                    break;
                case "2":
                    CreateOrder();
                    break;
                case "3":
                    FreeTable();
                    break;
                case "4":
                    Exit();
                    break;
                default:
                    Console.WriteLine("netinkamas pasirinkimas");
                    break;
            }
        }
        public void ViewTables()
        {

        }
        public void CreateOrder()
        {
            Console.WriteLine("Pasirinkite staliuka");
            if (int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                var table = Tables.Find(t => t.TableNumber == tableNumber);
                if (table != null && !table.IsOccupied)
                {
                    table.Occupy();
                    var order = new Order(table);

                    Console.WriteLine("Meniu");
                    for (int i = 0; i < Menu.Items.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Menu.Items[i].Name} - {Menu.Items[i].Price} EUR");
                    }

                }
            }

        }
        public void FreeTable()
        {
        }
        public void Exit()
        {

        }
    }

}
