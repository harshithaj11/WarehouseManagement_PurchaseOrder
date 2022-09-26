using PurchaseOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate
{
    public class Supplier : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual int YearsOfExperience { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Address { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }

        public Supplier(string name, int yearsOfExperience, bool isActive, string address,string email, string phoneNumber)
        {
            this.Name = name;
            this.YearsOfExperience = yearsOfExperience;
            this.IsActive = isActive;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNumber;


            

        }
        public Supplier() { }
    }
}
