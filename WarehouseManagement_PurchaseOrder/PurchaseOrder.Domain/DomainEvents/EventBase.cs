using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Domain.DomainEvents
{
    public abstract class EventBase : INotification
    {
        public DateTimeOffset CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
