using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class OrderStatusHistory : BaseEntity
    {
        public int OrderId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Order Order { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
