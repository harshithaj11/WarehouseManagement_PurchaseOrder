using PurchaseOrder.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate
{
    public class SearchByIdSpecification: SpecificationBase<PurchaseOrd>
    {
        private readonly long Id;
            public SearchByIdSpecification(long Id)
            {
                this.Id = Id;
                base.Includes.Add("Supplier");
                base.Includes.Add("Product");
            }
            public override Expression<Func<PurchaseOrd, bool>> ToExpression() 
            {
                return obj => obj.Id.Equals(Id);
            }
        
    }
}
