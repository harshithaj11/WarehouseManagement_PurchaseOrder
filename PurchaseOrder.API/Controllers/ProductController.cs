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
    public class ProductController : ControllerBase
    {

        private readonly IRepository<Product> productRepository;
   
        public ProductController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
   

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(200, Type = typeof(List<ProductDTO>))]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetProduct()
        {
            var products = productRepository.Get();
            var dtos = from product in products
                       select new GetProductDTO(product.Id, product.ProductName, product.ProductBrand, product.Price);
            return Ok(dtos);
        }

   
    }
}
