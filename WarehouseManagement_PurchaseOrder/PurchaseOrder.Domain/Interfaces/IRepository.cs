using PurchaseOrder.Domain.Aggregates;
using PurchaseOrder.Domain.Entities;
using PurchaseOrder.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrder.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase, IAggregateRoot
    {
        T Add(T item);
        T Remove(T item);
        T Update(T item);
        IReadOnlyCollection<T> Get();
        T GetById(long Id);
        IReadOnlyCollection<T> GetBySpec(SpecificationBase<T> spec);
        Task<int> SaveAsync();
    }
}
