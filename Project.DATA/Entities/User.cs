using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public int? Age { get; set; }
        public ICollection<Favorites> Favorites { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<Comparison> Comparisons { get; set; }
        public ICollection<UserAccountType> UserAccountTypes { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
