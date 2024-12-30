using NUnit.Framework.Legacy;
using Restaurant_app;

namespace TestProject1
{
    public class Tests
    {
        private RestaurantSystem _restaurantSystem;

        [SetUp]
        public void Setup()
        {
            _restaurantSystem = new RestaurantSystem();
        }

        [Test]
        public void Test1()
        {
            _restaurantSystem.InitializeSystem();

            // Assert
            ClassicAssert.AreEqual(5, _restaurantSystem.Tables.Count);
            

        }
    }
}
