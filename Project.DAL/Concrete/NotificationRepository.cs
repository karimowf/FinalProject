using Microsoft.EntityFrameworkCore;
using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;
using System.Linq.Expressions;

namespace Project.DAL.Concrete
{
    public class NotificationRepository(SqlDbContext dbContext) : INotificationRepository
    {
        public async Task AddAsync(Notification notification)
        {
            await dbContext.Notifications.AddAsync(notification);
        }

        public async Task<List<Notification>?> WhereAsync(Expression<Func<Notification, bool>> predicate)
        {
            var responses = await dbContext.Notifications.Where(predicate).ToListAsync();
            return responses;
        }
    }
}
