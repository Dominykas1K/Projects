using NUnit.Framework.Legacy;
using Restaurant_app;

namespace TestProject1
{
    public class TableTests
    {
        [SetUp]
        public void Setup()
        {
        }
      
        [Test]
        public void Occupy_ShouldSetIsOccupiedToTrue()
        {
            Table table = new Table(1, 4);

            table.Occupy();

            ClassicAssert.IsTrue(table.IsOccupied);
        }

        [Test]
        public void Free_ShouldSetIsOccupiedToFalse()
        {
            Table table = new Table(1, 4);

            table.Free();

            ClassicAssert.IsFalse(table.IsOccupied);
        }
    }
}
