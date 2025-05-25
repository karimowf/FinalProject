using Project.Domain.Entities;
using Project.Domain.Patterns.BuilderPatterns.Categories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Directors.Abstract
{
    public interface ICategoryQueryDirector
    {
        ICategoriesQueryBuilder CategoriesQueryBuilder { get; set; }

        IQueryable<Category> BuildQuery(CategoriesFilterDto categoriesFilterDto);
    }
}
