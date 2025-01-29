using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class UserAccountType : BaseEntity
    {
        public int UserId { get; set; }
        public int DiscountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public AccountType AccountType { get; set; }
        public User User { get; set; }
        public Discount Discount { get; set; }
    }
}
