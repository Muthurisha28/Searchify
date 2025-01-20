using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Searchify.Controllers;
using Searchify.Core.Model;
using Searchify.Mediators.Commands;
using Xunit;

namespace Searchify.Tests.ControllerTests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new ProductsController(_mockMediator.Object);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnOk_WhenProductsExist()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Product1" },
                new Product { ProductId = 2, Name = "Product2" }
            };

            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllProductsCommand>(), default))
                         .ReturnsAsync(products);

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(products, okResult.Value);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnNotFound_WhenNoProductsExist()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllProductsCommand>(), default))
                         .ReturnsAsync(new List<Product>());

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Equal(new { Message = "No Products found" }, notFoundResult.Value);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllProductsCommand>(), default))
                         .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal(new { Message = "An unexpected error occurred.", Detail = "Unexpected error" }, objectResult.Value);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnOk_WhenProductExists()
        {
            // Arrange
            var product = new Product { ProductId = 1, Name = "Product1" };

            _mockMediator.Setup(m => m.Send(It.IsAny<GetProductByIdCommand>(), default))
                         .ReturnsAsync(product);

            // Act
            var result = await _controller.GetProductById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(product, okResult.Value);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetProductByIdCommand>(), default))
                         .ReturnsAsync((Product)null);

            // Act
            var result = await _controller.GetProductById(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Equal(new { Message = "Product with id 1 not found" }, notFoundResult.Value);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetProductByIdCommand>(), default))
                         .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.GetProductById(1);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal(new { Message = "An unexpected error occurred.", Detail = "Unexpected error" }, objectResult.Value);
        }
    }

}


