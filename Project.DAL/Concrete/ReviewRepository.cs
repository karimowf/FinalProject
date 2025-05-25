using Microsoft.EntityFrameworkCore;
using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;
using System.Linq.Expressions;

namespace Project.DAL.Concrete
{
    public class ReviewRepository(SqlDbContext dbContext) : IReviewRepository
    {
        public async Task CreateReviewAsync(FeedBack feedBack)
        {
            await dbContext.FeedBacks.AddAsync(feedBack);
        }

        public async Task<List<FeedBack>?> GetUserFeedbacksWithProductAsync(int userId)
        {
            return await dbContext.FeedBacks
                .Where(f => f.UserId == userId)
                .Include(f => f.Product)
                .ToListAsync();
        }

        public async Task<bool> HasUserReviewedProductAsync(int userId, int productId)
        {
            var existReview = await dbContext.FeedBacks.AnyAsync(x => x.UserId == userId && x.ProductId == productId);
            return existReview;
        }

        public async Task<List<FeedBack>?> WhereAsync(Expression<Func<FeedBack, bool>> predicate)
        {
            var result = await dbContext.FeedBacks
                .Where(predicate)
                .OrderByDescending(f => f.CreatedDate)
                .ToListAsync();
            return result;
        }

        public void UpdateFeedbackAsync(FeedBack feedBack)
        {
            dbContext.Entry(feedBack).State = EntityState.Modified;
        }

        public async Task<FeedBack?> GetReviewByIdAsync(int id)
        {
            return await dbContext.FeedBacks.FindAsync(id);
        }

        public void DeleteFeedbackAsync(FeedBack feedBack)
        {
            dbContext.FeedBacks.Remove(feedBack);
        }
    }
}
