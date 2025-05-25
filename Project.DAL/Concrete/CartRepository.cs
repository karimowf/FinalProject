using Microsoft.EntityFrameworkCore;
using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;

namespace Project.DAL.Concrete
{
    public class CartRepository(SqlDbContext context) : ICartRepository
    {
        public async Task<ShoppingCart?> GetCartByUserAndProductAsync(int userId, int productId)
        {
            return await context.ShoppingCarts
                .FirstOrDefaultAsync(sc => sc.UserId == userId && sc.ProductId == productId);
        }

        public async Task AddAsync(ShoppingCart shoppingCart)
        {
            await context.ShoppingCarts.AddAsync(shoppingCart);
        }

        public void UpdateAsync(ShoppingCart shoppingCart)
        {
            context.Entry(shoppingCart).State = EntityState.Modified;
        }

        public void DeleteAsync(ShoppingCart cartItem)
        {
            context.ShoppingCarts.Remove(cartItem);
        }

        public async Task<IEnumerable<ShoppingCart>> GetByUserIdAsync(int userId)
        {
            return await context.ShoppingCarts
                .Where(sc => sc.UserId == userId)
                .ToListAsync();
        }
    }
}
