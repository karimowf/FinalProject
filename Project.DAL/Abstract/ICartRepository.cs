using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface ICartRepository
    {
        Task<ShoppingCart?> GetCartByUserAndProductAsync(int userId, int productId);
        Task AddAsync(ShoppingCart shoppingCart);
        void UpdateAsync(ShoppingCart shoppingCart);
        void DeleteAsync(ShoppingCart shoppingCart);
        Task<IEnumerable<ShoppingCart>> GetByUserIdAsync(int userId);
    }
}
