using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;

namespace Project.DAL.Concrete
{
    public class DiscountRepository(SqlDbContext dbContext) : IDiscountRepository
    {
        public async Task AddDiscountAsync(Discount discount)
        {
            await dbContext.AddAsync(discount);
        }

        public async Task<List<Product>?> CheckActiveAndGetDiscountsAsync()
        {
            var activeProducts = await dbContext.Discounts.Where(x => x.EndDate > DateTime.UtcNow).Select(x => x.ProductId)
                .ToListAsync();
            var products = await dbContext.Products.Where(x => activeProducts.Contains(x.Id)).ToListAsync();
            return products;
        }

        public async Task<Discount?> FindDiscountByIdAsync(int discountId)
        {
            var discount = await dbContext.Discounts.FindAsync(discountId);
            return discount;
        }

        public void DeleteDiscount(Discount discount)
        {
            dbContext.Discounts.Remove(discount);
        }
    }
}
