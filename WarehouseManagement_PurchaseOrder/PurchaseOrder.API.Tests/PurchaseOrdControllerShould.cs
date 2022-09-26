using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using PurchaseOrder.API;
using PurchaseOrder.API.Controllers;
using PurchaseOrder.Domain.Entities;
using PurchaseOrder.Domain.Interfaces;
using PurchaseOrder.API.DTOs;
using Moq;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace PurchaseOrder.API.Tests
{
    [TestFixture]
    public class PurchaseOrdControllerShould
    {
        [Test]
        public async Task Return_201StatusCode()
        {
            var dto = new PurchaseOrdDTO()
            {
                DateOfPurchase = DateTime.Today,
                Qty = 5,
                P_Id = 2,
                S_Id = 2
            };
            

            var repo = new Mock<IRepository<PurchaseOrd>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var controller = new PurchaseOrdController(repoObj);

            var result = (StatusCodeResult)await controller.AddPurchase(dto).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(201));
        }

        [Test]
        public void Return_200StatusCode_WithDTO_for_Get()
        {
            var repo = new Mock<IRepository<PurchaseOrd>>();

           
            repo.Setup(m => m.GetBySpec(It.IsAny < GetAllPurchaseWithProdAndSupplierName> ())).Returns(() =>
            {
                DateTime dateOfPurchase = DateTime.Today;
                int qty = 5;
                int p_Id = 2;
                int s_Id = 2;

                var purchaseOrder = new PurchaseOrd(dateOfPurchase, qty, p_Id, s_Id);
                return new List<PurchaseOrd>() { purchaseOrder };
            });
            var repoObj = repo.Object;
            var controller = new PurchaseOrdController(repoObj);
            OkObjectResult result = (OkObjectResult)controller.GetPurchaseOrder();
            Assert.That(result.StatusCode, Is.EqualTo(200));
           

           
        }

    }
}
