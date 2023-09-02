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
}