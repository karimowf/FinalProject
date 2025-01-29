using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
    public class SqlDbContext : IdentityDbContext<User, Role, string>
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        public DbSet<Comparison> Comparisons { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<UserAccountType> UserMemberShips { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
    }
}
