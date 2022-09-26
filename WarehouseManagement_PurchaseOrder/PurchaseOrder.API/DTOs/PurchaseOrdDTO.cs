using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrder.API.DTOs
{
    public class PurchaseOrdDTO
    {
        public long Id { get; set; }
        [Required]
        public DateTime DateOfPurchase { get; set; }
        [Required]
        public int Qty
        {
            get;
            set;
        }
        [ForeignKey("Product")]
        public long P_Id { get; set; }

       
        public ProductDTO ProductDTO { get; set; }

        [ForeignKey("Supplier")]
        public long S_Id { get; set; }
      
        public SupplierDTO SupplierDTO { get; set; }
    }
}
