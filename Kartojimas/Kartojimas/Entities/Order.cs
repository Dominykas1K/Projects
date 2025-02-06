using Kartojimas.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartojimas.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public Guid Number { get; set; }
        public string ShippingAdress { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        List<OrderItem> OrderItems { get; set; }
        
    }
}
