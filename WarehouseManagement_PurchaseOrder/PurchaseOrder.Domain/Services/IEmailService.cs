using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Domain.Services
{
    public interface IEmailService
    {
        public void SendEmail(string toAddress, string subject, string message);
    }
}
