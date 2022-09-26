using PurchaseOrder.Domain.DomainEvents;
using PurchaseOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate
{
    public class PurchaseOrd : EntityBase, IAggregateRoot
    {
        public virtual DateTime DateOfPurchase { get; set; } = DateTime.Today;
        public virtual int Qty { get; set; }


        [ForeignKey("Product")]
        public virtual long P_Id { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Supplier")]

        public virtual long S_Id { get; set; }
        public virtual Supplier Supplier { get; set; }
        public PurchaseOrd(DateTime dateOfPurchase, int qty, long p_Id, long s_Id)
        {
            this.DateOfPurchase = dateOfPurchase;
            this.Qty = qty;
            this.P_Id = p_Id;
            this.S_Id = s_Id;
            var purchaseAdded = new PurchaseCreatedEvent()
            {
                Qty = this.Qty
               
            };
            base.DomainEvents.Add(purchaseAdded);

        }
       
        public int ChangeQty(int newQty)
        {
            if (newQty == 0)
                
                throw new ArgumentException("Invalid Qty");

            else if (newQty != Qty)
            {
                Qty = newQty;

            }

            return Qty;

        }
        protected PurchaseOrd() { } 


    }
}
