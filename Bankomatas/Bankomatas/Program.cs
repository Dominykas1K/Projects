namespace Bankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cardReader = new CardReader();
            List<Card> cards = cardReader.ReadCards();

            Console.WriteLine("Iveskite korteles numeri");

            string cardNumber = Console.ReadLine();

            Card foundCard = cards.Find(card => card.CardNumber.ToString() == cardNumber);

            if (foundCard == null)
            {
                Console.WriteLine("Kortele nerasta");
            }

            int attempts = 0;
            while (attempts < 3)
            {
                Console.WriteLine("Ivesktie korteles PIN koda");

                int pin = Convert.ToInt32(Console.ReadLine());

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
                    Console.WriteLine($"Liko bandymu: {3- attempts}");
                }               
            }
            Console.Clear();
            Console.WriteLine("Kortele uzblokuota!");
            

        }
    }
}
