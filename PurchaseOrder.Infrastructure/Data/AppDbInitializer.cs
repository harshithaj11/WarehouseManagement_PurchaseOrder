using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using PurchaseOrder.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseOrder.Infrastructure.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PurchaseOrdContext>();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new Product()
                    {

                        ProductName = "FaceWash",
                        ProductBrand = "Himalaya",
                        Price = 250
                    },
                    new Product()
                    {
                        ProductName = "Paste",
                        ProductBrand= "Colgate",
                        Price= 550

                    },
                    new Product
                    {
                        ProductName = "Handwash",
                        ProductBrand = "Lifeboy",
                        Price = 450


                    },
                    new Product()
                    {
                        ProductName = "Shampoo",
                        ProductBrand = "Loreal",
                        Price = 350

                    },
                    new Product()
                    {
                        ProductName = "Conditioner",
                        ProductBrand = "Loreal",
                        Price = 350
                    },
                    new Product()
                    {

                        ProductName = "Soap",
                        ProductBrand = "Hamam",
                        Price = 100

                    });
                    context.SaveChanges();

                }
                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(new Supplier()
                    {
                        Name = "Harshitha",
                        YearsOfExperience = 5,
                        IsActive = true,
                        Address = "Chennai",
                        Email = "j.harshitha111@gmail.com",
                        PhoneNumber = "9874561230"
                    },
                    new Supplier()
                    {
                        Name = "Charumithaa",
                        YearsOfExperience = 4,
                        IsActive = true,
                        Address = "Chennai",
                        Email = "Charumithaa@gmail.com",
                        PhoneNumber = "9784561230"

                    },
                    new Supplier()
                    {
                        Name = "Oviya",
                        YearsOfExperience = 3,
                        IsActive = true,
                        Address = "Chennai",
                        Email = "Oviya@gmail.com",
                        PhoneNumber = "9965412300"

                    },
                    new Supplier()
                    {
                        Name = "Kushindar",
                        YearsOfExperience = 3,
                        IsActive = true,
                        Address = "Banglore",
                        Email = "Kushindar@gmail.com",
                        PhoneNumber = "9486521170"

                    },
                    new Supplier()
                    {
                        Name = "Shajahan",
                        YearsOfExperience = 4,
                        IsActive = false,
                        Address = "Banglore",
                        Email = "Shajahan@gmail.com",
                        PhoneNumber = "9486527861"

                    },
                    new Supplier()
                    {
                        Name = "Sree HariMirnal",
                        YearsOfExperience = 6,
                        IsActive = true,
                        Address = "Kerala",
                        Email = "Sreehari@gmail.com",
                        PhoneNumber = "9789044561"

                    });
                    context.SaveChanges();
                }



            }
        }
    }
}
