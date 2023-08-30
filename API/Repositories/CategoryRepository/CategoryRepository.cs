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
        string sql = "INSERT INTO Categories (Name, Description, ImageUrl, CreatedAt , Status  ) VALUES (@Name, @Description, @ImageUrl, @CreatedAt, @Status)";
        var parameters = new DynamicParameters();
        parameters.Add("@Name", categoryDto.Name, DbType.String);
        parameters.Add("@Description", categoryDto.Description, DbType.String);
        parameters.Add("@ImageUrl", categoryDto.ImageUrl, DbType.String);
        parameters.Add("@CreatedAt", categoryDto.CreatedAt, DbType.DateTime);
        parameters.Add("@Status",  true);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(sql, parameters);
        }
    }
    
public async void UpdateCategoryAsync(UpdateCategoryDto categoryDto)
    {
        string sql = "UPDATE Categories SET Name = @Name, Description = @Description, ImageUrl = @ImageUrl, Status = @Status WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", categoryDto.Id, DbType.Guid);
        parameters.Add("@Name", categoryDto.Name, DbType.String);
        parameters.Add("@Description", categoryDto.Description, DbType.String);
        parameters.Add("@ImageUrl", categoryDto.ImageUrl, DbType.String);
        parameters.Add("@Status",  categoryDto.Status, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }

public async void DeleteCategoryAsync(Guid id)
{
    string sql = "DELETE FROM Categories WHERE Id = @Id";
    var parameters = new DynamicParameters();
    parameters.Add("@Id", id, DbType.Guid);
    using (var connection = _context.CreateConnection())
    {
        await connection.ExecuteAsync(sql, parameters);
    }
}

public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(Guid id)
{
   string sql = "SELECT * FROM Categories WHERE Id = @Id";
   
   var parameters = new DynamicParameters();
   
   parameters.Add("@Id", id, DbType.Guid);

   using (var connection = _context.CreateConnection())
   {
       var result = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(sql, parameters);
       return result;
   }
    
}
}