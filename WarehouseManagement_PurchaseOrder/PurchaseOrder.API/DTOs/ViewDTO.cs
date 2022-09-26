using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrder.API.DTOs
{
   public class ViewDTO
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public DateTime DateOfPurchase { get; set; } = DateTime.Now;
        [Required]
        public int Qty { get; set; }
        [Required]
        public string Name { get; set; }
        
        public ViewDTO(long id, string productName, DateTime dateOfPurchase, int qty, string name)
        {
            Id = id;
            ProductName = productName;
            DateOfPurchase = dateOfPurchase;
            Qty = qty;
            Name = name;
           
        }
      

    }
    
}
