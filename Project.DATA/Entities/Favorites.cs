using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Favorites : BaseEntity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
