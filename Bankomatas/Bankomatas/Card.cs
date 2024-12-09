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

        public Card(long cardNumber,string name, int pin, decimal balance)
        {
            CardNumber = cardNumber;
            Pin = pin;
            Name = name;
            Balance = balance;
        }
    }
}
