using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class FeedBack : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
