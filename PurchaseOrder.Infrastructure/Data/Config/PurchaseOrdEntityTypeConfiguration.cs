using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Infrastructure.Data.Config
{
    public class PurchaseOrdEntityTypeConfiguration: IEntityTypeConfiguration<PurchaseOrd>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrd> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DateOfPurchase).IsRequired(true);
            builder.Property(p => p.Qty).IsRequired(true);

        }
    }
}
