namespace Bankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cardReader = new CardReader();
            List<Card> cards = cardReader.ReadCards();

            Card foundCard = null;

            while (foundCard == null)
            {
                Console.WriteLine("Iveskite korteles numeri");

                string cardNumber = Console.ReadLine();

                Console.Clear();

                foundCard = cards.Find(card => card.CardNumber.ToString() == cardNumber);

                if (foundCard == null)
                {
                    Console.WriteLine("Kortele nerasta");
                }
            }

            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    Console.WriteLine("Ivesktie korteles PIN koda");

                    int pin = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    if (pin == foundCard.Pin)
                    {
                        Console.WriteLine("Patvirtinta");
                        var menu = new Menu(foundCard, cards, cardReader);
                        menu.ShowMenu();

                    }
                    else
                    {
                        attempts++;
                        Console.WriteLine("Neteisingas PIN kodas, bandykite dar karta");
                        Console.WriteLine($"Liko bandymu: {3 - attempts}");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Netinkamas formatas ivesktie skaiciu");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Per ilgas Pin kodas");
                }
            }
            Console.Clear();
            Console.WriteLine("Kortele uzblokuota!");
            

        }
    }
}
