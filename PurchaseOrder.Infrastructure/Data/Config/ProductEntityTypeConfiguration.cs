using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Infrastructure.Data.Config
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).HasMaxLength(30).IsRequired(true);
            builder.Property(p => p.Price).IsRequired(true);
            builder.Property(p => p.ProductBrand).IsRequired(true);


        }
    }
}
