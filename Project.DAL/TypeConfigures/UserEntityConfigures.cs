using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.TypeConfigures
{
    public class UserEntityConfigures : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.ShoppingCarts)
            .WithOne(sc => sc.User)
            .HasForeignKey(sc => sc.UserId);

            builder.HasMany(u => u.Favorites)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId);

            builder.HasMany(u => u.Comparisons)
           .WithOne(c => c.User)
           .HasForeignKey(c => c.UserId);

            builder.HasMany(u => u.UserAccountTypes)
           .WithOne(ums => ums.User)
           .HasForeignKey(ums => ums.UserId);
        }
    }
}
