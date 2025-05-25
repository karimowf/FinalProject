using Project.Domain.Entities;
using Project.Domain.Patterns.BuilderPatterns.Categories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Patterns.BuilderPatterns.Categories.Concrete
{
    public class CategoriesQueryBuilder : ICategoriesQueryBuilder
    {
        private IQueryable<Category> _query;

        public CategoriesQueryBuilder(IQueryable<Category> query)
        {
            _query = query;
        }

        public ICategoriesQueryBuilder FilterWithParentCategoryId(int? parentCategoryId)
        {
            if (parentCategoryId.HasValue)
            {
                _query = _query.Where(c => c.ParentCategoryId == parentCategoryId);
            }
            return this;
        }

        public ICategoriesQueryBuilder FilterWithName(string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                _query = _query.Where(c => c.Name.Contains(name));
            }
            return this;
        }

        public IQueryable<Category> Build()
        {
            return _query;
        }
    }

}
