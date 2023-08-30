using EindomsHavnAPI.DTOs.ProductDtos;

namespace EindomsHavnAPI.Repositories.ProductRepository;

public interface IProductRepository
{
        
        Task<List<ResultProductDto>> GetAllProductsAsync();
        
        Task<List<ResultProductDtoWithCategoryAndAddress>> GetAllProductsWithCategoryAndAddressAsync();
        
        void CreateProductAsync(CreateProductDto productDto);
        
        void UpdateProductAsync(UpdateProductDto productDto);
        
        void DeleteProductAsync(Guid id);
        
        Task<GetByIdProductDto> GetProductByIdAsync(Guid id);
    
    
    
}