using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.TypeConfigures
{
    public class ProductEntityConfigures : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.FeedBacks)
            .WithOne(f => f.Product)
            .HasForeignKey(f => f.ProductId);

            builder.HasMany(p => p.ShoppingCarts)
            .WithOne(sc => sc.Product)
            .HasForeignKey(sc => sc.ProductId);

            builder.HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.Favorites)
            .WithOne(f => f.Product)
            .HasForeignKey(f => f.ProductId);

            builder.HasMany(p => p.Images)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

            builder.HasMany(p => p.Comparisons)
            .WithOne(c => c.Product)
            .HasForeignKey(c => c.ProductId);

            builder.HasOne(p => p.ProductFeatures)
            .WithOne(pf => pf.Product)
            .HasForeignKey<ProductFeatures>(pf => pf.ProductId);

            builder.HasMany(p => p.ProductDiscounts)
           .WithOne(pd => pd.Product)
           .HasForeignKey(pd => pd.ProductId);

            builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

            builder.HasMany(p => p.OrderDetails)
            .WithOne(od => od.Product)
            .HasForeignKey(od => od.ProductId);
        }
    }
}
