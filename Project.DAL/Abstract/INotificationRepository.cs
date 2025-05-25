using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification notification);
        Task<List<Notification>?> WhereAsync(Expression<Func<Notification, bool>> predicate);
    }
}
