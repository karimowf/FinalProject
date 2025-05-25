using Microsoft.EntityFrameworkCore;
using Project.DAL.Abstract;
using Project.DAL.Contexts;
using Project.Domain.Entities;
using Project.Domain.Models.DTOs.Image;
using Project.Domain.Models.DTOs.Product;
using Project.Domain.Models.ResponseModels;
using Project.Domain.Patterns.BuilderPatterns.Directors.Abstract;

namespace Project.DAL.Concrete
{
    public class ProductRepository(SqlDbContext dbContext, IProductQueryDirector productQueryDirector) : IProductRepository
    {
        public async Task AddAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
        }

        public void UpdateAsync(Product product)
        {
            dbContext.Entry(product).State = EntityState.Modified;
        }

        public void DeleteAsync(Product product)
        {
            dbContext.Products.Remove(product);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<List<Product>?> GetProductsWithFilterAsync(ProductsFilterDto products)
        {
            var result = productQueryDirector.BuildQuery(products).ToList();
            return result;
        }

        public async Task<List<ProductWithImages>?> GetRecommendedProductsAsync(int userId)
        {
            var categoryIdsWithImages = await dbContext.Products
                .Where(x => x.UserId == userId && x.Images.Any())
                .Select(p => new ProductWithImages()
                {
                    CategoryId = p.CategoryId,
                    Images = p.Images.Select(img => new ImageDto
                    {
                        Id = img.Id,
                        Url = img.Url
                    }).ToList()
                })
                .ToListAsync();

            return categoryIdsWithImages;
        }

        public Task<List<Category>?> GetProductsByIdsAsync(List<int> categoryIds)
        {
            throw new NotImplementedException();
        }
    }

}
