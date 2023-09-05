using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EindomsHavnAPI.Controllers;
using EindomsHavnAPI.DTOs.ProductDtos;
using EindomsHavnAPI.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class ProductControllerTests
{
    [Fact]
    public async Task GetAllProductsAsync_ReturnsOkResult()
    {
        // Arrange
        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetAllProductsAsync())
            .ReturnsAsync(new List<ResultProductDto>()); 

        var controller = new ProductController(mockRepository.Object);

        // Act
        var result = await controller.GetAllProductsAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<ResultProductDto>>(okResult.Value);
        Assert.Empty(model);
    }
    
    
    [Fact]
    public async Task GetAllProductsWithCategoryAndAddressAsync_ReturnsOkResult()
    {
        // Arrange
        var mockProductRepository = new Mock<IProductRepository>();
        // Mock'tan dönecek olan verileri hazırlayın (örneğin, bir liste).
        var fakeProducts = new List<ResultProductDtoWithCategory>();
        mockProductRepository.Setup(repo => repo.GetAllProductsWithCategoryAsync())
            .ReturnsAsync(fakeProducts);
            
        var controller = new ProductController(mockProductRepository.Object);

        // Act
        var result = await controller.GetAllProductsWithCategoryAndAddressAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<ResultProductDtoWithCategory>>(okResult.Value);
        Assert.NotNull(model);

        // İşlem sonunda beklediğiniz verileri ve durum kodunu kontrol edebilirsiniz.
        // Örneğin, modeldeki ürün sayısı veya dönen HTTP durum kodu (200 OK) gibi.
    }
    
    
    [Fact]
    public async Task GetAllProductsAsync_ReturnsOkResultWithProducts()
    {
        // Arrange
        // Mock veri oluşturun
        var expectedData = new List<ResultProductDto>
        {
            new ResultProductDto { City = "Arendal", Title= "Product 1" },
            new ResultProductDto { City = "Oslo", Title = "Product 2" },
        };

        var mockRepository = new Mock<IProductRepository>();
        mockRepository.Setup(repo => repo.GetAllProductsAsync())
            .ReturnsAsync(expectedData);

        var controller = new ProductController(mockRepository.Object);

        // Act
        var result = await controller.GetAllProductsAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<ResultProductDto>>(okResult.Value);
        Assert.Equal(expectedData.Count, model.Count());
    }
}