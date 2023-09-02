using System.Data;
using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.ContactDtos;
using EindomsHavnAPI.DTOs.NewsletterDtos;

namespace EindomsHavnAPI.Repositories.ContactRepository;

public class ContactRepository : IContactRepository
{
    private readonly Context _context;
    
    public ContactRepository(Context context)
    {
        _context = context;
    }
    
    
    public async Task<List<ResultContactDto>> GetAllAsync()
    {
        string sql = "SELECT * FROM Contacts";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultContactDto>(sql);
            return result.ToList();
        }
    }

    public async void CreateAsync(CreateContactDto contactDto)
    {
        string sql = "INSERT INTO Contacts (ContactName, Email, CreatedAt , Status , Message ) VALUES (@ContactName, @Email, @CreatedAt, @Status, @Message)";
        var parameters = new DynamicParameters();
        parameters.Add("@ContactName", contactDto.ContactName, DbType.String);
        parameters.Add("@Email", contactDto.Email, DbType.String);
        parameters.Add("@CreatedAt", contactDto.CreatedAt, DbType.DateTime);
        parameters.Add("@Message", contactDto.Message, DbType.String);
        parameters.Add("@Status",  true);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
        
    }

    public async void UpdateAsync(UpdateContactDto contactDto)
    {
        string sql = "UPDATE Contacts SET ContactName=@ContactName, Message=@Message, Email = @Email, Status = @Status WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", contactDto.Id, DbType.Guid);
        parameters.Add("@ContactName", contactDto.ContactName, DbType.String);
        parameters.Add("@Message", contactDto.Message, DbType.String);
        parameters.Add("@Email", contactDto.Email, DbType.String);
        parameters.Add("@CreatedAt", contactDto.CreatedAt, DbType.DateTime);
        parameters.Add("@Status"  ,  contactDto.Status, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }

    public async void DeleteAsync(Guid id)
    {
        string sql = "DELETE FROM Contacts WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id, DbType.Guid);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }
    
    public async Task<GetByIdContactDto> GetByIdAsync(Guid id)
         {
             string sql = "SELECT * FROM Contacts WHERE Id = @Id";
        
             var parameters = new DynamicParameters();
        
             parameters.Add("@Id", id, DbType.Guid);
     
             using (var connection = _context.CreateConnection())
             {
                 var result = await connection.QueryFirstOrDefaultAsync<GetByIdContactDto>(sql, parameters);
                 return result;
             }
         }
    
}