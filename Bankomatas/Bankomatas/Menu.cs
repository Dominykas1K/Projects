using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bankomatas
{
    public class Menu
    {
        public Card _currentCard;
        public List<Card> _allCards;
        public CardReader _cardReader;


        public Menu(Card currentCard, List<Card> allCards, CardReader cardReader)
        {
            _currentCard = currentCard;
            _allCards = allCards;
            _cardReader = cardReader;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Ivesktie pasirinkima");
                Console.WriteLine("1. Balansas ");
                Console.WriteLine("2. Pinigu isemimas");
                Console.WriteLine("3. Pinigu idejimas");
                Console.WriteLine("4. Praitos transakcijos");

                string input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        ShowBalance();
                        break;
                    case "2":
                        WithdrawMoney();
                        break;
                    case "3":
                        DepositMoney(); 
                        break;
                    case "4":
                        ShowLastTransactions();
                        break;
                    default:
                        Console.WriteLine("Neteisinga ivestis");
                        break;


                }
            }
        }

        public void ShowBalance()
        {
            Console.Clear();
            Console.WriteLine($"Jusu balansas: {_currentCard.Balance}");
            Console.WriteLine("Paspauskite bet kuri mygtuka noredami gristi atgal i meniu");
            Console.ReadKey();
            Console.Clear();

        }
        public void WithdrawMoney()
        {
            Console.WriteLine("Iveskite suma kuria norite issiimti");

            string input = Console.ReadLine();

            //Console.Clear();

            if (decimal.TryParse(input, out decimal amount))
            {
                if (amount > 1000)
                {
                    Console.WriteLine("Maksimali isemimmo suma negali but daugiau nei 1000 e");
                }
                else if (amount > _currentCard.Balance)
                {
                    Console.WriteLine("Neturite pakankamai lesu");
                }
                else
                {
                    _currentCard.Balance -= amount;
                    _currentCard.AddTransaction($"Issimta: {amount} e");
                    Console.WriteLine($"Sekmingai issiemet: {amount} e , likutis: {_currentCard.Balance} ");
                    _cardReader.SaveCards(_allCards);
                }
            }
            else
            {
                Console.WriteLine("Netinkamas formatas iveskite skaiciu");
            }
        }
        public void DepositMoney()
        {
            Console.WriteLine("Ivesktie suma kuria norite ideti");

            string input = Console.ReadLine();

            //Console.Clear();

            if (decimal.TryParse(input, out decimal amount))
            {
                _currentCard.Balance += amount;
                _currentCard.AddTransaction($"Ideta: {amount} e");
                Console.WriteLine($"Sekmingai idejote: {amount} e , likutis: {_currentCard.Balance}");
                _cardReader.SaveCards(_allCards);
            }
            else
            {
                Console.WriteLine("Netinkamas formatas iveskite skaiciu");
            }
        }
        public void ShowLastTransactions()
        {
            Console.Clear();

            if (_currentCard.Transactions.Count == 0)
            {
                Console.WriteLine("Nebuvo jokiu transakciju");
            }
            else
            {
                foreach (var transaction in _currentCard.Transactions)
                {
                    Console.WriteLine(transaction);
                }
            }

            Console.WriteLine("Paspauskite bet kuri mygtuka noredami gristi atgal i meniu");
            Console.ReadKey();
            Console.Clear();


        }
        
    }
}
