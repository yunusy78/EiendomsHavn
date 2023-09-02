using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.ProductDtos;

namespace EindomsHavnAPI.Repositories.ProductRepository;

public class ProductDetailsRepository: IProductDetailsRepository
{
    private readonly Context _context;
    
    public ProductDetailsRepository(Context context)
    {
        _context = context;
    }
    
    
    public async Task<List<ResultProductDetailsDto>> GetAllProductsAsync()
    {
        string sql = "SELECT * FROM ProductDetails";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductDetailsDto>(sql);
            return products.ToList();
        }
        
    }

    public async Task<List<ResultProductDetailsDtoWithProduct>> GetAllProductDetailsWithProductAsync()
    {
        string sql = "SELECT * FROM ProductDetails INNER JOIN Products ON ProductDetails.ProductId = Products.ProductId INNER JOIN Employee ON Products.EmployeeId = employee.EmployeeId INNER JOIN Categories ON Products.CategoryId = Categories.CategoryId";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductDetailsDtoWithProduct>(sql);
            return products.ToList();
        }
        
    }

    public void CreateProductAsync(CreateProductDetailsDto productDto)
    {
        throw new NotImplementedException();
    }

    public void UpdateProductAsync(UpdateProductDetailsDto productDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdProductDetailsDto> GetProductByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultProductDetailsDtoWithProduct>> GetAllProductDetailsWithProductAsync(Guid id)
    {
        string sql = "SELECT * FROM ProductDetails INNER JOIN Products ON ProductDetails.ProductId = Products.ProductId INNER JOIN Employee ON Products.EmployeeId = employee.EmployeeId INNER JOIN Categories ON Products.CategoryId = Categories.CategoryId WHERE ProductDetails.Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductDetailsDtoWithProduct>(sql, new {Id = id});
            return products.ToList();
        }
        {
            
        }
    }
}