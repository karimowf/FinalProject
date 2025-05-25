using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.DTOs.Category
{
    public class CategoriesFilterDto(int? parentCategoryId, string? name)
    {
        public CategoriesFilterDto() : this(0, string.Empty)
        {
        }

        public int? ParentCategoryId { get; set; } = parentCategoryId;
        public string? Name { get; set; } = name;
    }
}
