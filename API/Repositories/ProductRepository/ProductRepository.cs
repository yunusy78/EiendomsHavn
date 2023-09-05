using System.Data;
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

    public async Task<List<ResultProductDtoWithCategory>> GetAllProductsWithCategoryAsync()
    {
        string sql = "SELECT * FROM Products INNER JOIN Categories ON Products.CategoryId = Categories.CategoryId ";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<ResultProductDtoWithCategory>(sql);
            return products.ToList();
        }
        
    }

    public async void CreateProductAsync(CreateProductDto productDto)
    {
        var sql = "INSERT INTO Products (Title, Description, Type, Price, ImageUrl, Street, City," +
                  " PostalCode, Country, CreatedAt, CoverImageUrl, CategoryId, EmployeeId, Status) " +
                  "VALUES (@Title, @Description, @Type, @Price, @ImageUrl," +
                  " @Street, @City, @PostalCode, @Country, @CreatedAt, @CoverImageUrl, @CategoryId, @EmployeeId, @Status)";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", productDto.Title, DbType.String);
        parameters.Add("@Description", productDto.Description, DbType.String);
        parameters.Add("@Type", productDto.Type, DbType.String);
        parameters.Add("@Price", productDto.Price, DbType.Decimal);
        parameters.Add("@ImageUrl", productDto.ImageUrl, DbType.String);
        parameters.Add("@Street", productDto.Street, DbType.String);
        parameters.Add("@City", productDto.City, DbType.String);
        parameters.Add("@PostalCode", productDto.PostalCode, DbType.String);
        parameters.Add("@Country", productDto.Country, DbType.String);
        parameters.Add("@CreatedAt", productDto.CreatedAt, DbType.DateTime);
        parameters.Add("@CoverImageUrl", productDto.CoverImageUrl, DbType.String);
        parameters.Add("@CategoryId", productDto.CategoryId, DbType.Guid);
        parameters.Add("@EmployeeId", productDto.EmployeeId, DbType.Guid);
        parameters.Add("@Status", productDto.Status, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
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