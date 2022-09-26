using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrder.API.DTOs
{
    public class GetProductDTO
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        [Required]
        public float Price { get; set; }
        public GetProductDTO(long id, string productName, string productBrand, float price)
        {
            this.Id = id;
            this.ProductName = productName;
            this.ProductBrand = productBrand;
            this.Price = price;


        }
    }
}
