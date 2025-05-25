using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;
using Project.Domain.Patterns.BuilderPatterns.Directors.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MongoDbContext mongoDbContext;
        public CategoryRepository(MongoDbContext mongoDbContext, ICategoryQueryDirector categoryQueryDirector)
        {
            this.mongoDbContext = mongoDbContext;
        }
        public async Task AddAsync(Category category)
        {
                var collection = mongoDbContext.GetCollection<Category>("Categories");
                await collection.InsertOneAsync(category);
        }

        public async Task<bool> ExistsAsync(Expression<Func<Category, bool>> predicate)
        {
            return await mongoDbContext.GetCollection<Category>("Categories").Find(predicate).AnyAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var collection = mongoDbContext.GetCollection<Category>("Categories");
            return await collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public void UpdateAsync(Category category)
        {
            var collection = mongoDbContext.GetCollection<Category>("Categories");
            collection.ReplaceOne(c => c.Id == category.Id, category);
        }

        public void DeleteAsync(Category category)
        {
            var collection = mongoDbContext.GetCollection<Category>("Categories");
            collection.DeleteOne(c => c.Id == category.Id);
        }
    }
}
