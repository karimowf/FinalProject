using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Category : BaseEntity
    {
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
