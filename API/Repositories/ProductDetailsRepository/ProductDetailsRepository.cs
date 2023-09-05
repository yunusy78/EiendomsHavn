using System.Data;
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

    public async void CreateProductAsync(CreateProductDetailsDto productDto)
    {
        var sql = "UPDATE ProductDetails SET ProductId=@ProductId, Size = @Size, BadromCount = @BadromCount, BathCount = @BathCount, " +
                  "RomCount = @RomCount, GarageSize = @GarageSize, BuildYear = @BuildYear, Location = @Location, VideoUrl = @VideoUrl WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@ProductId", productDto.ProductId, DbType.Guid);
        parameters.Add("@Id", productDto.Id, DbType.Guid);
        parameters.Add("@Size", productDto.Size, DbType.Int32);
        parameters.Add("@BadromCount", productDto.BadromCount, DbType.Byte);
        parameters.Add("@BathCount", productDto.BathCount, DbType.Byte);
        parameters.Add("@RomCount", productDto.RomCount, DbType.Byte);
        parameters.Add("@GarageSize", productDto.GarageSize, DbType.Byte);
        parameters.Add("@BuildYear", productDto.BuildYear, DbType.String);
        parameters.Add("@Location", productDto.Location, DbType.String);
        parameters.Add("@VideoUrl", productDto.VideoUrl, DbType.String);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }

    public void UpdateProductAsync(UpdateProductDetailsDto productDto)
    {
        
        
        
        
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

    public async Task<List<GetByIdProductDetailsDto>> GetByIdProductDetailsAsync(Guid id)
    {
        var sql = "SELECT * FROM ProductDetails WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var products = await connection.QueryAsync<GetByIdProductDetailsDto>(sql, new {Id = id});
            return products.ToList();
        }
    }
}