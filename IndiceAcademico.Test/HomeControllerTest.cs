using System;
using System.Collections.Generic;
using IndiceAcademico.Controllers;
using IndiceAcademico.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace IndiceAcademico.Test
{
    public class HomeControllerTest
    {
        class FakeDataSource : IDataSource
        {
            public FakeDataSource(Product[] data) => Products = data;
            public IEnumerable<Product> Products { get; set; }
        }


        [Fact]
        public void IndexActionModelisComplete()
        {
            Product[] testData = new Product[]{
                new Product {Name = "p1", Price = 75.10M},
                new Product {Name = "p2", Price = 120M},
                new Product {Name = "p3", Price = 110M},
            };
            IDataSource data = new FakeDataSource(testData);
            var controller = new HomeController();
            controller.dataSource = data;
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Assert
            Assert.Equal(data.Products, model,
            Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
            && p1.Price == p2.Price));
        }

    }
}
