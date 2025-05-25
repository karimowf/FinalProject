using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface IReviewRepository
    {
        Task CreateReviewAsync(FeedBack feedBack);
        Task<List<FeedBack>?> GetUserFeedbacksWithProductAsync(int userId);
        Task<bool> HasUserReviewedProductAsync(int userId, int productId);
        Task<List<FeedBack>?> WhereAsync(Expression<Func<FeedBack, bool>> predicate);
        void UpdateFeedbackAsync(FeedBack feedBack);
        Task<FeedBack?> GetReviewByIdAsync(int id);
        void DeleteFeedbackAsync(FeedBack feedBack);
    }
}
