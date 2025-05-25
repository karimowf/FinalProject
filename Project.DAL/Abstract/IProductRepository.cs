using Project.Domain.Entities;
using Project.Domain.Models.DTOs.Product;
using Project.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        void UpdateAsync(Product product);
        void DeleteAsync(Product product);
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>?> GetProductsWithFilterAsync(ProductsFilterDto products);
        Task<List<ProductWithImages>?> GetRecommendedProductsAsync(int userId);

        Task<List<Category>?> GetProductsByIdsAsync(List<int> categoryIds);
    }
}
