using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public Product Product { get; set; }
        public ICollection<UserAccountType> UserMemberShips { get; set; }
        public ICollection<ProductDiscount> ProductDiscounts { get; set; }
    }
}
