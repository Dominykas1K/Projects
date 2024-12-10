using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas
{
    public class CardReader
    {
        string _file = "C:\\Users\\Boss\\Desktop\\Cards.txt";

        public List<Card> ReadCards()
        {
            List<Card> cards = new List<Card>();

            string[] lines = File.ReadAllLines(_file);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                var card = new Card(Convert.ToInt64(parts[0]),parts[1], Convert.ToInt32(parts[2]), Convert.ToDecimal(parts[3]));
                cards.Add(card);
            }
            return cards;
        }

        public void SaveCards(List<Card> cards)
        {
            var lines = new List<string>();
            foreach (var card in cards)
            {
                string line = $"{card.CardNumber},{card.Name},{card.Pin},{card.Balance}";
                lines.Add(line);
            }
            File.WriteAllLines(_file, lines);
        }
    }
}
