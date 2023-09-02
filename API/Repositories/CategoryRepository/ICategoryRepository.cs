using EindomsHavnAPI.DTOs.CategoryDtos;

namespace EindomsHavnAPI.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    
    void CreateCategoryAsync(CreateCategoryDto categoryDto);
    
    void UpdateCategoryAsync(UpdateCategoryDto categoryDto);
    
    void DeleteCategoryAsync(Guid id);
    
    
    
    Task<GetByIdCategoryDto> GetCategoryByIdAsync(Guid id);
    
    
    
    
    
    
    
    
}