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
    public class DiscountEntityConfigures : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasMany(p => p.ProductDiscounts)
           .WithOne(pd => pd.Discount)
           .HasForeignKey(pd => pd.DiscountId);
        }
    }
}
