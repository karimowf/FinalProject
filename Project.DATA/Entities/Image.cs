using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Image : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
