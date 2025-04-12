using Project.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UnitOfWorkModel
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        int Commit();
        Task<int> CommitAsync(); 
    }
}
