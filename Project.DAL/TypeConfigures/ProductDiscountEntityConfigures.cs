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
    public class ProductDiscountEntityConfigures : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.HasKey(pd => pd.Id);

            builder.HasOne(pd => pd.Product)
            .WithMany(p => p.ProductDiscounts)
            .HasForeignKey(pd => pd.ProductId);

            builder.HasOne(pd => pd.Discount)
            .WithMany(d => d.ProductDiscounts)
            .HasForeignKey(pd => pd.DiscountId);
        }
    }
}
