using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Products.Abstract
{
    public interface IProductsQueryBuilder
    {
        IProductsQueryBuilder FilterWithProductId(int? productId);
        IProductsQueryBuilder FilterWithStockQuantity(int? minStockQuantity);
        IProductsQueryBuilder FilterWithName(string? name);
        public IQueryable<Product> Build();
    }
}
