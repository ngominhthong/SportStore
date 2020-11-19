using Moq;
using NUnit.Framework;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {        
        [Fact]
        public void Can_Paginate()
        {
            
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();           
            mock.Setup(m => m.Product).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            // Act
            ProductsListViewModel result =
            controller.List(2).ViewData.Model as ProductsListViewModel;
            // Assert
            Product[] prodArray = result.Product.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equals("P4", prodArray[0].Name);
            Assert.Equals("P5", prodArray[1].Name);
        }
    }
}