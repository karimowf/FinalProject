using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Directors.Abstract
{
    public interface IProductQueryDirector
    {
        IProductsQueryBuilder ProductsQueryBuilder { get; set; }

        IQueryable<Product> BuildQuery(ProductsFilterDto productsFilterDto);
    }
}
