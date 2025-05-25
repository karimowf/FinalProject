using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<Order?> GetByIdAsync(int orderId);
        Task<List<Order>?> GetAllByUserIdAsync(int userId, bool isShow = true);
        void DeleteAsync(Order order);
        Task<bool> ExistAsync(int orderId);
        void UpdateOrderAsync(Order order);
        Task<List<OrderStatusHistory>?> GetOrderStatusesHistoryAsync(int orderId, int userID);
    }
}
