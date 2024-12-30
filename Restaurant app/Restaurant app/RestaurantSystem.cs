
namespace Restaurant_app
{
    public class RestaurantSystem
    {
        public List<Table> Tables { get; set; } = new List<Table>();
        public Menu Menu { get; set; } = new Menu();
        public List<Order> Orders { get; set; } = new List<Order>();

        public void InitializeSystem()
        {
            for (int i = 1; i <= 10; i++)
            {
                Tables.Add(new Table(i, 4));
            }

            Menu.LoadMenuItems();
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
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("netinkamas pasirinkimas");
                    break;
            }
        }
        public void ViewTables()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Staliukai ===");
                foreach (var table in Tables)
                {
                    Console.WriteLine($"Staliukas nr: {table.TableNumber}: {(table.IsOccupied ? "Uzimtas" : "Laisvas")}");
                }
                Console.WriteLine("Noredami gristi atgal i menu spauskite 0");
                int.TryParse(Console.ReadLine(), out int input);
                Console.Clear();
                if (input == 0)
                {
                    SystemMenu();
                }
                else
                {
                    Console.WriteLine("Neteisinga ivesits");
                }
                
            }
        }
        public void CreateOrder()
        {
            while (true)
            {
                Console.WriteLine("Pasirinkite staliuka");
                if (!int.TryParse(Console.ReadLine(), out int tableNumber))
                {
                    Console.WriteLine("Neteisingas staliuko numeris");
                    continue;
                }

                var table = Tables.Find(t => t.TableNumber == tableNumber);
                if (table == null)
                {
                    Console.WriteLine("Neteisingas staliuko numeris");
                    continue;
                }

                if (table.IsOccupied)
                {
                    Console.WriteLine("Staliukas uzimtas");
                    continue;
                }

                table.Occupy();
                var order = new Order(table);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Pasirinkite meniu:");
                    Console.WriteLine("1. Maistas");
                    Console.WriteLine("2. Gerimai");
                    Console.WriteLine("0. Uzbaigti uzsakymo kurima ir grizti i pagrindini meniu");

                    if (!int.TryParse(Console.ReadLine(), out int menuChoice))
                    {
                        Console.WriteLine("Neteisingas pasirinkimas, bandykite dar karta");
                        continue;
                    }

                    if (menuChoice == 0)
                    {
                        Console.Clear();
                        break;
                    }

                    if (menuChoice == 1)
                    {
                        DisplayMenu(order, Menu.FoodItems, "Maisto");
                    }
                    else if (menuChoice == 2)
                    {
                        DisplayMenu(order, Menu.DrinkItems, "Gerimu");
                    }
                    else
                    {
                        Console.WriteLine("Neteisingas pasirinkimas, bandykite dar karta");
                    }
                }

                Orders.Add(order);
                Console.WriteLine($"Uzsakymas padarytas {table.TableNumber} staliukui, suma: {order.TotalPrice} ");               
                PrintAndSaveReceipts(order);
                Console.ReadKey();
                Console.Clear();
                SystemMenu();
            }
        }

        private void PrintAndSaveReceipts(Order order)
        {
            string restaurantReceipt = Receipt.GenerateRestaurantReceipt(order);
            Console.WriteLine(restaurantReceipt);
            string filePath = $"C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\Cekiai\\receipt.txt";
            File.WriteAllText(filePath, restaurantReceipt);
           
            Console.WriteLine("Ar klientas pageidauja cekio? (taip/ne)");
            string customerResponse = Console.ReadLine()?.ToLower();
            if (customerResponse == "taip")
            {
                string customerReceipt = Receipt.GenerateCustomerReceipt(order);
                Console.WriteLine(customerReceipt);
            }
        }

        private void DisplayMenu(Order order, List<MenuItems> items, string menuType)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{menuType} meniu:");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Price} EUR");
                }
                Console.WriteLine("0. Grizti i ankstesni meniu");

                if (!int.TryParse(Console.ReadLine(), out int itemNumber) || itemNumber < 0 || itemNumber > items.Count)
                {
                    Console.WriteLine("Neteisingas pasirinkimas, bandykite dar karta");
                    continue;
                }

                if (itemNumber == 0)
                {
                    break;
                }

                var menuItem = items[itemNumber - 1];
                order.AddItem(menuItem);
                Console.WriteLine($"{menuItem.Name} idetas i uzsakyma");
                Thread.Sleep(1000);

            }
        }
        public void FreeTable()
        {
            Console.WriteLine("Pasirinkite kuri staliuka norite atlaisvinti");
            if (!int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                Console.WriteLine("Neteisingas staliuko numeris");
                return;
            }

            var table = Tables?.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                Console.WriteLine("Staliukas nerastas");
                return;
            }

            if (!table.IsOccupied)
            {
                Console.WriteLine("Staliukas jau yra laisvas");
                return;
            }

            table.Free();
            Console.WriteLine($"Staliukas {table.TableNumber} atlaisvintas");


        }
        
    }

}
