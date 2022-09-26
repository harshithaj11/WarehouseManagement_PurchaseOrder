using MediatR;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using PurchaseOrder.Domain.DomainEvents;
using PurchaseOrder.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PurchaseOrder.Domain.EventHandlers
{
    public class PurchaseCreatedEventHandler : INotificationHandler<PurchaseCreatedEvent>
    {
        private readonly IEmailService emailService;
        public PurchaseCreatedEventHandler(IEmailService email)
        {
            this.emailService = email;
        }
        public Task Handle(PurchaseCreatedEvent notification, CancellationToken cancellationToken)
        {
            var body = $"<h1>Welcome</h1><br/>" +
                $"<p>You got a new Order.</p>";
            emailService.SendEmail("j.harshitha111@gmailcom", "Welcome", body);
            return Task.CompletedTask;
        }
    }
}
