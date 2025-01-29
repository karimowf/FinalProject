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
    public class FavoritesEntityConfigures : IEntityTypeConfiguration<Favorites>
    {

        public void Configure(EntityTypeBuilder<Favorites> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Product)
            .WithMany(p => p.Favorites)
            .HasForeignKey(f => f.ProductId);

            builder.HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f =>f.UserId);
        }
    }
}
