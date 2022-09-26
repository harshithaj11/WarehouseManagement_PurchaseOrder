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
    public class SupplierController : ControllerBase
    {

        private readonly IRepository<Supplier> supplierRepository;

        public SupplierController(IRepository<Supplier> supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }
        [HttpGet("GetAllSuppliers")]
        [ProducesResponseType(200, Type = typeof(List<SupplierDTO>))]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetSupplier()
        {
            var suppliers = supplierRepository.Get();
            var dtos = from s in suppliers
                       select new GetSupplierDTO(s.Id,s.Name, s.YearsOfExperience, s.IsActive, s.Address, s.Email, s.PhoneNumber);
            return Ok(dtos);
        }
    }
}
