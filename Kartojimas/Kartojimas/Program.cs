using Kartojimas.Entities;
using Kartojimas.Repositories;

namespace Kartojimas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new GenericDbContext();
            var orderRepository = new OrderRepository(dbContext);
            var orderItemReository = new OrderItemRepository(dbContext);

            orderRepository.Save(new Order());
            orderRepository.Find(x => x.DateCreated == new DateTime());
            orderItemReository.GetAll();
            orderItemReository.GetById(1);

        }
    }
}
