using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas
{
    public class Card
    {
        public long CardNumber { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
        public decimal Balance { get; set; }
        public List<string> Transactions { get; set; }
        public int DailyTransactionCount { get; set; }

        public Card(long cardNumber,string name, int pin, decimal balance)
        {
            CardNumber = cardNumber;
            Pin = pin;
            Name = name;
            Balance = balance;
            Transactions = new List<string>();
        }

        public void AddTransaction(string transaction)
        {
            Transactions.Add(transaction);
            if (Transactions.Count > 5)
            {
                Transactions.RemoveAt(0);
            }
            if (DailyTransactionCount >= 10)
            {
                throw new Exception();
            }
            DailyTransactionCount++;
        }
        
    }
}
