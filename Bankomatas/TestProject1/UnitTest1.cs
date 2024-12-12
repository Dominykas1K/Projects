using Bankomatas;
using NUnit.Framework.Legacy;
using NUnit.Framework;


namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void WithdrawMoneyTest()
        {
            var card = new Card(1234567890123456, "Test User", 1234, 1000);
            var allCards = new List<Card> { card };
            var cardReader = new CardReader();
            var menu = new Menu(card, allCards, cardReader);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var consoleInput = new StringReader("200");
            Console.SetIn(consoleInput);

            
            menu.WithdrawMoney();

            
            ClassicAssert.AreEqual(800, card.Balance);
            ClassicAssert.AreEqual(1, card.Transactions.Count);

        }

        [Test]
        public void DepositMoneyTest()
        {
            var card = new Card(1234567890123456, "Test User", 1234, 1000);
            var allCards = new List<Card> { card };
            var cardReader = new CardReader();
            var menu = new Menu(card, allCards, cardReader);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var consoleInput = new StringReader("200");
            Console.SetIn(consoleInput);


            menu.DepositMoney();


            ClassicAssert.AreEqual(1200, card.Balance);
            ClassicAssert.AreEqual(1, card.Transactions.Count);
        }
    }
}
