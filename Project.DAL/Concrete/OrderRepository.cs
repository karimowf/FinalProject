using Microsoft.EntityFrameworkCore;
using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;

namespace Project.DAL.Concrete
{
    public class OrderRepository(SqlDbContext context) : IOrderRepository
    {
        public async Task CreateAsync(Order order)
        {
            await context.Orders.AddAsync(order);
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            var order = await context.Orders.FindAsync(orderId);
            return order;
        }

        public async Task<List<Order>?> GetAllByUserIdAsync(int userId, bool isShow = true)
        {
            var allOrders = context.Orders.Where(x => x.UserId == userId && x.IsShow == isShow);
            return await allOrders.ToListAsync();
        }


        public void DeleteAsync(Order order)
        {
            context.Orders.Remove(order);
        }

        public async Task<bool> ExistAsync(int orderId)
        {
            var existOrder = await context.Orders.AnyAsync();
            return existOrder;
        }

        public void UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException(); //TODO: bu hisseni tamamla
        }

        public async Task<List<OrderStatusHistory>?> GetOrderStatusesHistoryAsync(int orderId, int userId)
        {
            var order = await context.Orders.Include(o => o.OrderStatusHistories)
                .FirstOrDefaultAsync(x => x.Id == orderId && x.UserId == userId);
            return order?.OrderStatusHistories?.ToList();
        }

        public void UpdateOrderAddressAsync(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }
    }

}
