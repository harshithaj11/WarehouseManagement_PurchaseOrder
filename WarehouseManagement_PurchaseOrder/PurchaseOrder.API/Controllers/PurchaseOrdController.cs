using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.API.DTOs;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using PurchaseOrder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdController : ControllerBase
    {

        private readonly IRepository<PurchaseOrd> purchaseOrdRepository;

        public PurchaseOrdController(IRepository<PurchaseOrd> purchaseOrdRepository)
        {
            this.purchaseOrdRepository = purchaseOrdRepository;
        }
        [HttpPost("/AddPurchaseOrder")]
        [ProducesResponseType(201)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPurchase(PurchaseOrdDTO purchaseorddto)
        {

            var purchase = new PurchaseOrd(purchaseorddto.DateOfPurchase, purchaseorddto.Qty, purchaseorddto.P_Id,purchaseorddto.S_Id);
            purchaseOrdRepository.Add(purchase);
            await purchaseOrdRepository.SaveAsync();
            return StatusCode(201);
           
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PurchaseOrdDTO>))]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPurchaseOrder()
        {
            var purchases = purchaseOrdRepository.GetBySpec(new GetAllPurchaseWithProdAndSupplierName());
            var dtos = from purchase in purchases
                       select new ViewDTO(purchase.Id, purchase.Product.ProductName, purchase.DateOfPurchase, purchase.Qty, purchase.Supplier.Name);
                   
            return Ok(dtos);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(PurchaseOrdDTO))]
        [Authorize(Roles = "Admin")]
        public IActionResult Get(long Id)
        {
            var spec = new SearchByIdSpecification(Id);
            var purchases = purchaseOrdRepository.GetBySpec(spec);
            if (purchases.Count == 0)
                return NotFound();
            var dtos = from purchase in purchases
                       select new ViewDTO(purchase.Id, purchase.Product.ProductName, purchase.DateOfPurchase, purchase.Qty, purchase.Supplier.Name);
                        
            return Ok(dtos);
        }
        [HttpPut("{id}/updateQty")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = (typeof(PurchaseOrdDTO)))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateQty(long id, [FromBody] int qty)
        {
            var purchase = purchaseOrdRepository.GetById(id);
            purchase.ChangeQty(qty);
            purchaseOrdRepository.Update(purchase);
            await purchaseOrdRepository.SaveAsync();

           
            return Ok(purchase);
        }


        [HttpDelete("DeletePurchaseOrder/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePurchaseOrder(long id)
        {
            var Purchase = purchaseOrdRepository.GetBySpec(new DeletePurchaseWithProdAndSupplierName(id));
            if (Purchase == null)
                return NotFound();
            var purchase = Purchase.First();

            purchaseOrdRepository.Remove(purchase);

            purchaseOrdRepository.SaveAsync();
            return Ok(purchase);
        }


    }
}
