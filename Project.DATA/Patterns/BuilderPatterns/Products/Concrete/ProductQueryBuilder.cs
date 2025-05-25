using Project.Domain.Entities;
using Project.Domain.Patterns.BuilderPatterns.Products.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Products.Concrete
{
    public class ProductQueryBuilder : IProductsQueryBuilder
    {
        private IQueryable<Product> _query;

        public ProductQueryBuilder(IQueryable<Product> query)
        {
            _query = query;
        }

        public IProductsQueryBuilder FilterWithProductId(int? productId)
        {
            if (productId.HasValue)
            {
                _query = _query.Where(c => c.Id == productId);
            }
            return this;
        }

        public IProductsQueryBuilder FilterWithStockQuantity(int? stockQuantity)
        {
            if (stockQuantity.HasValue)
            {
                _query = _query.Where(c => c.StockQuantity == stockQuantity);
            }
            return this;
        }

        public IProductsQueryBuilder FilterWithName(string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                _query = _query.Where(c => c.Name.Contains(name));
            }
            return this;
        }

        public IQueryable<Product> Build()
        {
            return _query;
        }
    }
}
