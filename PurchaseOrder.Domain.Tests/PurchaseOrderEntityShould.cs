using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using PurchaseOrder.Domain;
using PurchaseOrder.Domain.Entities;
using PurchaseOrder.Domain.Aggregates;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
namespace PurchaseOrder.Domain.Tests
{
    [TestFixture]
    public class PurchaseOrderEntityShould
    {
        [Test]
        public void Create_NewPurchaseOrder_ViaConstructor()
        {
            DateTime dateOfPurchase = DateTime.Today;
            int qty = 5;
            int p_Id = 2;
            int s_Id = 2;
            var purchaseOrder = new PurchaseOrd(dateOfPurchase, qty, p_Id, s_Id);

            Assert.That(purchaseOrder, Is.Not.Null);
            Assert.That(purchaseOrder, Is.InstanceOf<PurchaseOrd>());
            Assert.That(purchaseOrder.Qty, Is.EqualTo(qty));
            Assert.That(purchaseOrder.DateOfPurchase, Is.EqualTo(dateOfPurchase));


        }
        [Test]
        public void Update_Qty()
        {

            DateTime dateOfPurchase = DateTime.Today;
            int qty = 5;
            int p_Id = 2;
            int s_Id = 2;
            var purchaseOrder = new PurchaseOrd(dateOfPurchase, qty, p_Id, s_Id);

            purchaseOrder.ChangeQty(10);
            Assert.That(purchaseOrder.Qty, Is.EqualTo(10));
        }
        [Test]
        
        [TestCase(0)]
        
        public void Throws_ArgumentException_For_InvalidQty(int input)
        {
            //Arrange

            DateTime dateOfPurchase = DateTime.Today;
            int qty = 5;
            int p_Id = 2;
            int s_Id = 2;
            var purchaseOrder = new PurchaseOrd(dateOfPurchase, qty, p_Id, s_Id);
            Assert.Throws<ArgumentException>(() => purchaseOrder.ChangeQty(input));
        }


    }
}
