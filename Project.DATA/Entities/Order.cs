using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
