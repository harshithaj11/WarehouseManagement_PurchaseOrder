using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrder.API.DTOs
{
    public class GetSupplierDTO
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int YearsOfExperience { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public GetSupplierDTO(long id,string name, int yearsOfExperience, bool isActive, string address, string email, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.YearsOfExperience = yearsOfExperience;
            this.IsActive = isActive;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNumber;




        }
    }
}
