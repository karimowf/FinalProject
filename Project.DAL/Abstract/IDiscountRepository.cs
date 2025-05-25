using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface IDiscountRepository
    {
        Task AddDiscountAsync(Discount discount);
        Task<List<Product>?> CheckActiveAndGetDiscountsAsync();
        Task<Discount?> FindDiscountByIdAsync(int discountId);
        void DeleteDiscount(Discount discount);
    }
}
