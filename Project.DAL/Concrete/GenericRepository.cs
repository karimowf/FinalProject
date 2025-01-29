using Microsoft.EntityFrameworkCore;
using Project.DAL.Abstract;
using Project.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SqlDbContext sqlDbContext;
        private readonly DbSet<T> table;

        public GenericRepository(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
            table = sqlDbContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            await table.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            table.Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            var allDataFromDataBase = await table.ToListAsync();
            return allDataFromDataBase;
        }

        public async Task<T> GetById(int id)
        {
            var anyDataFromDatabaseGetById = await table.FindAsync(id);
            return anyDataFromDatabaseGetById;
        }

        public async Task Update(T entity)
        {
            table.Update(entity);
        }
    }
}
