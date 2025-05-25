using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Comparison(int productId, int userId) : BaseEntity
    { 
        public Comparison(): this(0, 0)
        {
           
        }

        public int ProductId { get; set; } = productId;
        public int UserId { get; set; } = userId;
        public DateTime CreatedDate { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
