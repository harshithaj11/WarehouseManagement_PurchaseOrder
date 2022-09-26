using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrder.API.DTOs
{
    public class GetByIdDTO
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public float Price { get; set; }
        public DateTime DateOfPurchase { get; set; } = DateTime.Now;
        [Required]
        public int Qty { get; set; }
        [Required]
        public string Name { get; set; }


        public GetByIdDTO(long id, string productName,string productBrand, float price , DateTime dateOfPurchase, int qty, string name)
        {
            Id = id;
            ProductName = productName;
            ProductBrand = productBrand;
            Price = price;
            DateOfPurchase = dateOfPurchase;
            Qty = qty;
            Name = name;

        }
    }
}
