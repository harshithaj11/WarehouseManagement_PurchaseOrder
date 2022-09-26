using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Infrastructure.Data.Config
{
    public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(30).IsRequired(true);  
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.PhoneNumber).HasMaxLength(10).IsFixedLength(true).IsRequired(true);
            builder.Property(p => p.Address).HasMaxLength(30).IsRequired(true);
            builder.Property(p => p.IsActive).IsRequired(true);
            builder.Property(p => p.YearsOfExperience).IsRequired(true);

        }
    }
}
