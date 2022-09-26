using PurchaseOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate
{
    public class Product: EntityBase
    {
        public virtual string ProductName
        {
            get;
            set;
        }
        public virtual string ProductBrand
        {
            get;
            set;
        }
        public virtual float Price
        {
            get;
            set;
        }
        public Product(string productName, string productBrand, float price)
        {
            this.ProductName = productName;
            this.ProductBrand = productBrand;
            this.Price = price;


        }
       public Product() { }
    }
}
