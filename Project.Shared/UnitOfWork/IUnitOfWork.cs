using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.UnitOfWork
{
    public interface IUnitOfWork
    {
        IFavoritesRepository FavoritesRepository { get; }
        IProductRepository ProductRepository { get; }

        Task CommitAsync(); 
        Task RollbackAsync(); 
    }
}
