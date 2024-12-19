namespace Restaurant_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var restaurantSystem = new RestaurantSystem();
            restaurantSystem.SystemMenu();
            restaurantSystem.InitializeSystem();
            
        }
    }
}
