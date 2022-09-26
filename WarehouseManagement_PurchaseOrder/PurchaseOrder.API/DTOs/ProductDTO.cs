using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrder.API.DTOs
{
    public class ProductDTO
    {

        public string ProductName { get; set; } 
        public string ProductBrand { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
