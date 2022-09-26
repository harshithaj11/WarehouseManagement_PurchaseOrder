using PurchaseOrder.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate
{
    public class GetAllPurchaseWithProdAndSupplierName : SpecificationBase<PurchaseOrd>
    {
        public GetAllPurchaseWithProdAndSupplierName()
        {
            base.Includes.Add("Product");
            base.Includes.Add("Supplier");

        }
        public override Expression<Func<PurchaseOrd, bool>> ToExpression() 
        {
            return obj => true;
        }

    }
}
