using Amazon.Runtime.Internal.Util;
using Project.DAL.Abstract;
using Project.DAL.Concrete;
using Project.DAL.Contexts;
using Project.Domain.Patterns.BuilderPatterns.Directors.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UnitOfWorkModel
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICategoryRepository _categoryRepository;
        private ICartRepository _cartRepository; private IProductRepository _productRepository;
        private IComparisonRepository _comparisonRepository; private IOrderRepository _orderRepository;
        private IDiscountRepository _discountRepository; private IReviewRepository _reviewRepository;
        private INotificationRepository _notificationRepository; private readonly SqlDbContext _context;
        private readonly MongoDbContext _mongoContext; private readonly SqlDbContext _sqlDbContext;
        private readonly ICategoryQueryDirector _categoryQueryDirector; private readonly IProductQueryDirector _productQueryDirector;

        public UnitOfWork(SqlDbContext context, MongoDbContext mongoDbContext,
            ICategoryQueryDirector categoryQueryDirector, SqlDbContext sqlDbContext, IProductQueryDirector productQueryDirector)
        {
            _context = context;
            _mongoContext = mongoDbContext; _categoryQueryDirector = categoryQueryDirector;
            _sqlDbContext = sqlDbContext; _productQueryDirector = productQueryDirector;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_mongoContext, _categoryQueryDirector);
        public ICartRepository CartRepository =>
            _cartRepository ??= new CartRepository(_sqlDbContext);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_sqlDbContext, _productQueryDirector);
        public IComparisonRepository ComparisonRepository =>
            _comparisonRepository ??= new ComparisonRepository(_sqlDbContext);
        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_sqlDbContext);
        public IDiscountRepository DiscountRepository =>
            _discountRepository ??= new DiscountRepository(_sqlDbContext);
        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_sqlDbContext);
        public INotificationRepository NotificationRepository =>
            _notificationRepository ??= new NotificationRepository(_sqlDbContext);
        public int Commit() => _context.SaveChanges();
        public async Task<int> CommitAsync()
            => await _context.SaveChangesAsync();
    }
}
