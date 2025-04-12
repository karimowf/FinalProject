using Amazon.Runtime.Internal.Util;
using Project.DAL.Abstract;
using Project.DAL.Concrete;
using Project.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UnitOfWorkModel
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public UnitOfWork(SqlDbContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public int Commit()
            => _context.SaveChanges();

        public async Task<int> CommitAsync()
            => await _context.SaveChangesAsync();
    }

}
