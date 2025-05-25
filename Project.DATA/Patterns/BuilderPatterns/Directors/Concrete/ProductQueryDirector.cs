using Project.Domain.Entities;
using Project.Domain.Patterns.BuilderPatterns.Directors.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Directors.Concrete
{
    public class ProductQueryDirector : IProductQueryDirector
    {
        public IProductsQueryBuilder ProductsQueryBuilder { get; set; }
        public IQueryable<Product> BuildQuery(ProductsFilterDto categoriesFilterDto)
            => ProductsQueryBuilder.FilterWithName(categoriesFilterDto.Name)
                .FilterWithProductId(categoriesFilterDto.ProductId)
                .FilterWithStockQuantity(categoriesFilterDto.StockQuantity)
                .Build();
    }
}
