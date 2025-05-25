using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public ProductCondition ProductCondition { get; set; }
        public ProductFeatures ProductFeatures { get; set; }
        public User User { get; set; }
        public ICollection<Favorites> Favorites { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<Comparison> Comparisons { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<ProductDiscount> ProductDiscounts { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
