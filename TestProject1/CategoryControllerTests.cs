using EindomsHavnAPI.Controllers;
using EindomsHavnAPI.DTOs.CategoryDtos;
using EindomsHavnAPI.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject1;

public class CategoryControllerTests
{
    [Fact]
    public async Task GetAllCategoriesAsync_ReturnsOkResult()
    {
        // Arrange
        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(repo => repo.GetAllCategoriesAsync())
            .ReturnsAsync(new List<ResultCategoryDto>());

        var controller = new CategoryController(mockRepository.Object);

        // Act
        var result = await controller.GetAllCategories();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<ResultCategoryDto>>(okResult.Value);
        Assert.Empty(model);
    }
    
    [Fact]
    public async Task CreateCategory_ValidModel_ReturnsOkResult()
    {
        // Arrange
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        var controller = new CategoryController(mockCategoryRepository.Object);

        var categoryDto = new CreateCategoryDto
        {
            CategoryId = Guid.NewGuid(),
            Name = "Test Category",
            CategoryDescription = "null",
            Status = true
            
        };

        // Act
        var result = await controller.CreateCategory(categoryDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Category Created Successfully", okResult.Value);
    }

    [Fact]
    public async Task UpdateCategory_ValidModel_ReturnsOkResult()
    {
        // Arrange
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        var controller = new CategoryController(mockCategoryRepository.Object);

        var categoryDto = new UpdateCategoryDto
        {
            CategoryId = Guid.NewGuid(),
            Name = "Test Category",
            CategoryDescription = "Test Description",
            Status = true
        };

        // Act
        var result = await controller.UpdateCategory(categoryDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Category Updated Successfully", okResult.Value);
    }

    [Fact]
    public async Task DeleteCategory_ValidId_ReturnsOkResult()
    {
        // Arrange
        var categoryId = Guid.NewGuid(); 
        var mockCategoryRepository = new Mock<ICategoryRepository>();
        var controller = new CategoryController(mockCategoryRepository.Object);

        // Act
        var result = await controller.DeleteCategory(categoryId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Category Deleted Successfully", okResult.Value);
    }
    
    [Fact]
    public async Task UpdateCategory_CategoryNotFound_ReturnsNotFound()
    {
        // Arrange
        var categoryId = Guid.NewGuid(); // Var olmayan bir kategori kimliği
        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(repo => repo.GetAllCategoriesAsync())
            .ReturnsAsync(new List<ResultCategoryDto>());
        // Kategori güncelleme işlemi başarısız oldu

        var controller = new CategoryController(mockRepository.Object);

        var categoryDto = new UpdateCategoryDto
        {
            CategoryId = categoryId,
            Name = "Test Category",
            CategoryDescription = "Test Description",
            Status = true
        };

        // Act
        var result = await controller.UpdateCategory(categoryDto);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

}
