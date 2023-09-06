using System.Data;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.CategoryDtos;
using Dapper;

namespace EindomsHavnAPI.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly Context _context;
    
    public CategoryRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        string sql = "SELECT * FROM Categories";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultCategoryDto>(sql);
            return result.ToList();
        }
        
    }

    public async void CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        string sql = "INSERT INTO Categories (Name, CategoryDescription, CreatedAt , Status  ) VALUES (@Name, @CategoryDescription, @CreatedAt, @Status)";
        var parameters = new DynamicParameters();
        parameters.Add("@Name", categoryDto.Name, DbType.String);
        parameters.Add("@CategoryDescription", categoryDto.CategoryDescription, DbType.String);
        parameters.Add("@CreatedAt", categoryDto.CreatedAt, DbType.DateTime);
        parameters.Add("@Status",  true);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(sql, parameters);
        }
    }
    
public async void UpdateCategoryAsync(UpdateCategoryDto categoryDto)
    {
        string sql = "UPDATE Categories SET Name = @Name, CategoryDescription = @CategoryDescription, Status = @Status WHERE CategoryId = @CategoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@CategoryId", categoryDto.CategoryId, DbType.Guid);
        parameters.Add("@Name", categoryDto.Name, DbType.String);
        parameters.Add("@CategoryDescription", categoryDto.CategoryDescription, DbType.String);
        parameters.Add("@Status",  categoryDto.Status, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }

public async void DeleteCategoryAsync(Guid id)
{
    string sql = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
    var parameters = new DynamicParameters();
    parameters.Add("@CategoryId", id, DbType.Guid);
    using (var connection = _context.CreateConnection())
    {
        await connection.ExecuteAsync(sql, parameters);
    }
}

public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(Guid id)
{
   string sql = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
   
   var parameters = new DynamicParameters();
   
   parameters.Add("@CategoryId", id, DbType.Guid);

   using (var connection = _context.CreateConnection())
   {
       var result = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(sql, parameters);
       return result;
   }
    
}
}