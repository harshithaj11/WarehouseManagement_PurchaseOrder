using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Domain.DomainEvents
{
    public class PurchaseCreatedEvent: EventBase
    {
        public long Id { get; set; }
        public int Qty { get; set; }
    }
}
