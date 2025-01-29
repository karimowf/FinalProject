using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
