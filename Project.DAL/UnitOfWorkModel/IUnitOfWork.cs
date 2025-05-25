using Project.DAL.Abstract;

namespace Project.DAL.UnitOfWorkModel
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICartRepository CartRepository { get; }
        IProductRepository ProductRepository { get; }
        IComparisonRepository ComparisonRepository { get; }
        IOrderRepository OrderRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IReviewRepository ReviewRepository { get; }
        INotificationRepository NotificationRepository { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
