using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;
namespace Project.DAL.Concrete
{
    public class ComparisonRepository(SqlDbContext context) : IComparisonRepository
    {
        public async Task AddToComparisonAsync(Comparison comparison)
        {
            await context.Comparisons.AddAsync(comparison);
        }

        public Task<List<Comparison>> GetComparisonsByUserIdAsync(int userId)
        {
            var comparisons = context.Comparisons
                .Include(c => c.Product)
                .ThenInclude(p => p.Category)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return comparisons;
        }

        public void RemoveFromComparisonAsync(Comparison comparison)
        {
            context.Comparisons.Remove(comparison);
        }

        public async Task<Comparison?> GetComparisonByIdAsync(int id)
        {
            var comparison = await context.Comparisons.FindAsync(id);
            return comparison;
        }
    }
}
