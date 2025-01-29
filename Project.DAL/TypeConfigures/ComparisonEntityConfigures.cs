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
    public class ComparisonEntityConfigures : IEntityTypeConfiguration<Comparison>
    {
        public void Configure(EntityTypeBuilder<Comparison> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Product)
            .WithMany(p => p.Comparisons)
            .HasForeignKey(c => c.ProductId);

            builder.HasOne(c => c.User)
            .WithMany(u => u.Comparisons)
            .HasForeignKey(c => c.UserId);
        }
    }
}
