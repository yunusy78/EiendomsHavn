using System.Data;
using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.NewsletterDtos;

namespace EindomsHavnAPI.Repositories.NewsletterRepository;

public class NewsletterRepository : INewsletterRepository
{
    private readonly Context _context;
    
    public NewsletterRepository(Context context)
    {
        _context = context;
    }
    
    
    public async Task<List<ResultNewsletterDto>> GetAllNewslettersAsync()
    {
        string sql = "SELECT * FROM Newsletters";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultNewsletterDto>(sql);
            return result.ToList();
        }
    }

    public async void CreateNewsletterAsync(CreateNewsletterDto productDto)
    {
        string sql = "INSERT INTO Newsletters (Email, CreatedAt , Status  ) VALUES (@Email, @CreatedAt, @Status)";
        var parameters = new DynamicParameters();
        parameters.Add("@Email", productDto.Email, DbType.String);
        parameters.Add("@CreatedAt", productDto.CreatedAt, DbType.DateTime);
        parameters.Add("@Status",  true);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
        
    }

    public async void UpdateNewsletterAsync(UpdateNewsletterDto productDto)
    {
        string sql = "UPDATE Newsletters SET Email = @Email, Status = @Status WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", productDto.Id, DbType.Guid);
        parameters.Add("@Email", productDto.Email, DbType.String);
        parameters.Add("@CreatedAt", productDto.CreatedAt, DbType.DateTime);
        parameters.Add("@Status"  ,  productDto.Status, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }

    public async void DeleteNewsletterAsync(Guid id)
    {
        string sql = "DELETE FROM Newsletters WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Guid);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }
    
    public async Task<GetByIdNewsletterDto> GetNewsletterByIdAsync(Guid id)
         {
             string sql = "SELECT * FROM Newsletters WHERE Id = @Id";
        
             var parameters = new DynamicParameters();
        
             parameters.Add("@Id", id, DbType.Guid);
     
             using (var connection = _context.CreateConnection())
             {
                 var result = await connection.QueryFirstOrDefaultAsync<GetByIdNewsletterDto>(sql, parameters);
                 return result;
             }
         }
    
}