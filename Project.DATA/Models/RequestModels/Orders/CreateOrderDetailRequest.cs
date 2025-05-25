using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.RequestModels.Orders
{
    public class CreateOrderDetailRequest(int productId, int count, decimal price)
    {
        public int Count { get; set; } = count;
        public decimal Price { get; set; } = price;
    }
}
