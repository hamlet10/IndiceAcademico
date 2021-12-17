using System;
using IndiceAcademico.Models;
using Xunit;

namespace IndiceAcademico.Test
{
    public class ProductTest
    {
        [Fact]
        public void CanChangeProduct()
        {
            var p = new Product {Name = "Test", Price = 100M};
        }
    }
}
