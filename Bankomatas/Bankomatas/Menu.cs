using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas
{
    public class Menu
    {
        Card _currentCard;

        public Menu(Card currentCard)
        {
            _currentCard = currentCard;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine();
            }
        }
    }
}
