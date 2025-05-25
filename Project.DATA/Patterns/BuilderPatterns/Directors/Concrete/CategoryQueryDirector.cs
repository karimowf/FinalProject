using Project.Domain.Entities;
using Project.Domain.Patterns.BuilderPatterns.Categories.Abstract;
using Project.Domain.Patterns.BuilderPatterns.Directors.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Directors.Concrete
{
    public class CategoryQueryDirector : ICategoryQueryDirector
    {
        public ICategoriesQueryBuilder CategoriesQueryBuilder { get; set; }

        public IQueryable<Category> BuildQuery(CategoriesFilterDto categoriesFilterDto)
            => CategoriesQueryBuilder.FilterWithParentCategoryId(categoriesFilterDto.ParentCategoryId)
                .FilterWithName(categoriesFilterDto.Name)
                .Build();
    }
}
