using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.ProductDtos;

namespace EindomsHavnAPI.Repositories.ProductRepository;

public class ProductRepository: IProductRepository
{
    private readonly Context _context;
    
    public ProductRepository(Context context)
    {
        _context = context;
    }
    
    
    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        string sql = "SELECT * FROM Products";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductDto>(sql);
            return products.ToList();
        }
        
    }

    public async Task<List<ResultProductDtoWithCategoryAndAddress>> GetAllProductsWithCategoryAndAddressAsync()
    {
        string sql = "SELECT * FROM Products INNER JOIN Categories ON Products.CategoryId = Categories.Id INNER JOIN Addresses ON Products.AddressId = Addresses.Id";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductDtoWithCategoryAndAddress>(sql);
            return products.ToList();
        }
        
    }

    public void CreateProductAsync(CreateProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public void UpdateProductAsync(UpdateProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdProductDto> GetProductByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}