using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.RequestModels.Orders
{
    public class CreateOrderStatusHistory(DateTime modifiedDate, OrderStatus orderStatus)
    {
        public DateTime ModifiedDate { get; set; } = modifiedDate;
        public OrderStatus OrderStatus { get; set; } = orderStatus;
    }
}
