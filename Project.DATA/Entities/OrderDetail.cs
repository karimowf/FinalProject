using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
