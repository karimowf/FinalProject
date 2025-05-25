using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Categories.Abstract
{
    public interface ICategoriesQueryBuilder
    {
        ICategoriesQueryBuilder FilterWithParentCategoryId(int? parentCategoryId);
        ICategoriesQueryBuilder FilterWithName(string? name);
        public IQueryable<Category> Build();
    }
}
