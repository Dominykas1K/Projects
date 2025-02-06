using Kartojimas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartojimas.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>
    {
        public OrderItemRepository(GenericDbContext dbContext) : base(dbContext){ }
    }
}
