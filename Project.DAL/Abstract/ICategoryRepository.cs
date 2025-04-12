using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<bool> ExistsAsync(Expression<Func<Category, bool>> predicate);
        Task<Category> GetCategoryByIdAsync(int id);
        void UpdateAsync(Category category);
        void DeleteAsync(Category category);
    }
}
