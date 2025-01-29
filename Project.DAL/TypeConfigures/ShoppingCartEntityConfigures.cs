using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.DAL.TypeConfigures
{
    public class ShoppingCartEntityConfigures : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasOne(sc => sc.Product)
            .WithMany(p => p.ShoppingCarts)
            .HasForeignKey(sc => sc.ProductId);

            builder.HasOne(sc => sc.User)
            .WithMany(u => u.ShoppingCarts)
            .HasForeignKey(sc => sc.UserId);

        }
    }
}
