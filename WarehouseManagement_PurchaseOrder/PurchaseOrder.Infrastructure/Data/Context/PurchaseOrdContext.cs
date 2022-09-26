using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using PurchaseOrder.Domain.Entities;

namespace PurchaseOrder.Infrastructure.Data.Context
{
    public class PurchaseOrdContext : DbContext
    {
        private readonly IMediator mediator;
        public PurchaseOrdContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            this.mediator = mediator;
        }

        public PurchaseOrdContext(DbContextOptions options) : base(options)
        { }
        public DbSet<PurchaseOrd> PurchaseOrds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PurchaseOrdContext).Assembly);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int rows = await base.SaveChangesAsync(cancellationToken);
            var Entities = ChangeTracker.Entries().Select(e => e.Entity as EntityBase).ToArray();
            foreach (var entity in Entities)
            {

                var events = entity?.DomainEvents;
                if (events != null)
                {
                    foreach (var ev in events)
                    {
                        await mediator.Publish(ev).ConfigureAwait(false);
                    }
                    entity.DomainEvents.Clear();
                }

            }
            return rows;
        }

    }
}
