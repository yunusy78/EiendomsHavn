using EindomsHavnAPI.DTOs.ProductDtos;

namespace EindomsHavnAPI.Repositories.ProductRepository;

public interface IProductDetailsRepository
{
        
        Task<List<ResultProductDetailsDto>> GetAllProductsAsync();
        
        Task<List<ResultProductDetailsDtoWithProduct>> GetAllProductDetailsWithProductAsync();
        
        void CreateProductAsync(CreateProductDetailsDto productDto);
        
        void UpdateProductAsync(UpdateProductDetailsDto productDto);
        
        void DeleteProductAsync(Guid id);
        
        Task<GetByIdProductDetailsDto> GetProductByIdAsync(Guid id);
        
        Task<List<ResultProductDetailsDtoWithProduct>> GetAllProductDetailsWithProductAsync(Guid id);
    
    
    
}