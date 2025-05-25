using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.DTOs.Product
{
    public class ProductsFilterDto(
    int? productId,
    int? stockQuantity,
    string? name)
    {
        public ProductsFilterDto() : this(null, null, null)
        {
        }

        public int? ProductId { get; set; } = productId;
        public int? StockQuantity { get; set; } = stockQuantity;
        public string? Name { get; set; } = name;
    }
}
