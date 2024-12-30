
namespace Restaurant_app
{
    public class RestaurantSystem
    {
        public List<Table> Tables { get; set; } = new List<Table>();
        public Menu Menu { get; set; } = new Menu();
        public List<Order> Orders { get; set; } = new List<Order>();

        public void InitializeSystem()
        {
            Tables.Add(new Table(1, 2));
            Tables.Add(new Table(2, 4));
            Tables.Add(new Table(3, 6));
            Tables.Add(new Table(4, 4));
            Tables.Add(new Table(5, 2));

            Menu.LoadMenuItems();
        }

        public void SystemMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Restaurant System ===");
                Console.WriteLine("1. Staliukai");
                Console.WriteLine("2. Pildyti uzsakyma");
                Console.WriteLine("3. Atlaisvinti staliuka");
                Console.WriteLine("4. Iseiti");

                string? input = Console.ReadLine();

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
                        Console.WriteLine("Netinkamas pasirinkimas, bandykite dar karta.");
                        break;
                }
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
                    Console.WriteLine($"Staliukas nr: {table.TableNumber}");
                    Console.WriteLine($"Vietu skaicius: {table.TableSeats}");
                    Console.WriteLine($"Būsena: {(table.IsOccupied ? "Užimtas" : "Laisvas")}");
                    Console.WriteLine(new string('-', 30));
                }
                Console.WriteLine("Noredami gristi atgal i menu spauskite 0");
                if (int.TryParse(Console.ReadLine(), out int input) && input == 0)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Neteisinga ivesits, bandykite dar karta.");
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
                    Console.WriteLine("Neteisingas staliuko numeris, bandykite dar karta.");
                    continue;
                }

                var table = Tables.Find(t => t.TableNumber == tableNumber);
                if (table == null)
                {
                    Console.WriteLine("Neteisingas staliuko numeris, bandykite dar karta.");
                    continue;
                }

                if (table.IsOccupied)
                {
                    Console.WriteLine("Staliukas uzimtas, bandykite kita staliuka.");
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
                        Console.WriteLine("Neteisingas pasirinkimas, bandykite dar karta.");
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
                        Console.WriteLine("Neteisingas pasirinkimas, bandykite dar karta.");
                    }
                }

                Orders.Add(order);
                PrintAndSaveReceipts(order, new EmailSender());
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }

        private static void PrintAndSaveReceipts(Order order, IEmailSender emailSender)
        {
            string restaurantReceipt = Receipt.GenerateRestaurantReceipt(order);
            Console.WriteLine(restaurantReceipt);
            string filePath = $"C:\\Users\\Boss\\Desktop\\c#\\Github\\Projects\\Restaurant app\\Restaurant app\\Cekiai\\receipt_{DateTime.Now:yyyyMMddHHmmss}.txt";
            File.WriteAllText(filePath, restaurantReceipt);

            Console.WriteLine("Ar klientas pageidauja cekio? (taip/ne)");
            string? customerResponse = Console.ReadLine()?.ToLower();
            if (customerResponse == "taip")
            {
                string customerReceipt = Receipt.GenerateCustomerReceipt(order);
                Console.WriteLine(customerReceipt);

                Console.WriteLine("Iveskite kliento el. pasto adresa:");
                string? email = Console.ReadLine();
                if(!string.IsNullOrEmpty(email))
                {
                    emailSender.SendEmail(email, "Jusu uzsakymo cekis", customerReceipt);
                    Console.WriteLine("Cekis issiustas el. pastu");
                }
            }
        }

        private static void DisplayMenu(Order order, List<MenuItems> items, string menuType)
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
                    Console.WriteLine("Neteisingas pasirinkimas, bandykite dar karta.");
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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Atlaisvinti staliuka ===");
                Console.WriteLine("Pasirinkite kuri staliuka norite atlaisvinti (0 - grizti i pagrindini meniu)");

                if (!int.TryParse(Console.ReadLine(), out int tableNumber))
                {
                    Console.WriteLine("Neteisingas staliuko numeris, bandykite dar karta.");
                    Thread.Sleep(2000);
                    continue;
                }

                if (tableNumber == 0)
                {
                    Console.Clear();
                    return;
                }

                var table = Tables?.FirstOrDefault(t => t.TableNumber == tableNumber);
                if (table == null)
                {
                    Console.WriteLine("Staliukas nerastas, bandykite dar karta.");
                    Thread.Sleep(2000);
                    continue;
                }

                if (!table.IsOccupied)
                {
                    Console.WriteLine("Staliukas jau yra laisvas.");
                    Thread.Sleep(2000);
                    continue;
                }

                table.Free();
                Console.WriteLine($"Staliukas {table.TableNumber} atlaisvintas");
                Thread.Sleep(2000);
                Console.Clear();
                return;
            }
        }
    }

}
