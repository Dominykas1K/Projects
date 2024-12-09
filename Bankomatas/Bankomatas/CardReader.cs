using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas
{
    public class CardReader
    {
        string file = "C:\\Users\\Boss\\Desktop\\Cards.txt";


        public List<Card> ReadCards()
        {
            List<Card> cards = new List<Card>();

            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                var card = new Card(Convert.ToInt64(parts[0]),parts[1], Convert.ToInt32(parts[2]), Convert.ToDecimal(parts[3]));
                cards.Add(card);
            }
            return cards;
        }
    }
}
