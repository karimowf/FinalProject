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
    public class OrderEntityConfigures : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

            builder.HasMany(o => o.OrderStatusHistories)
           .WithOne(osh => osh.Order)
           .HasForeignKey(osh => osh.OrderId);
        }
    }
}
