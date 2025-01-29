using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class ProductFeatures : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
