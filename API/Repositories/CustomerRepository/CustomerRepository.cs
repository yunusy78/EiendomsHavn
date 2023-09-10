using System.Data;
using API.DTOs.EmployeeDtos;
using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.AboutDtos;
using EindomsHavnAPI.DTOs.Customer;

namespace EindomsHavnAPI.Repositories.EmployeeRepository;

public class CustomerRepository : ICustomerRepository
{
    private readonly Context _context;
    
    public CustomerRepository(Context context)
    {
        _context = context;
    }
    
    
    
    
    public async Task<IEnumerable<ResultCustomerDto>> GetAllEmployeeAsync()
    {
        var sql = "SELECT * FROM Customer";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultCustomerDto>(sql);
            return result.ToList();
        }
        
    }

    public async Task<ResultCustomerDto> GetEmployeeByIdAsync(Guid id)
    {
        var sql = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", id, DbType.Guid);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<ResultCustomerDto>(sql, parameters);
            return result;
        }
    }

    public async void CreateAboutAsync(CreateCustomerDto createAboutDto)
    {
        var sql = "INSERT INTO Customer (CustomerName, CustomerEmail, CustomerPhoneNumber," +
                  " CustomerImageUrl, CustomerTitle, CustomerComment, CreatedAt, CustomerStatus) " +
                  "VALUES (@CustomerName, @CustomerEmail, @CustomerPhoneNumber," +
                  " @CustomerImageUrl, @CustomerTitle, @CustomerComment, @CreatedAt, @CustomerStatus)";
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerName", createAboutDto.CustomerName, DbType.String);
        parameters.Add("@CustomerEmail", createAboutDto.CustomerEmail, DbType.String);
        parameters.Add("@CustomerPhoneNumber", createAboutDto.CustomerPhoneNumber, DbType.String);
        parameters.Add("@CustomerImageUrl", createAboutDto.CustomerImageUrl, DbType.String);
        parameters.Add("@CustomerTitle", createAboutDto.CustomerTitle, DbType.String);
        parameters.Add("@CustomerComment", createAboutDto.CustomerComment, DbType.String);
        parameters.Add("@CreatedAt", createAboutDto.CreatedAt, DbType.DateTime);
        parameters.Add("@CustomerStatus", createAboutDto.CustomerStatus, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
    }

    public async void UpdateAboutAsync(ResultCustomerDto updateAboutDto)
    {
        var sql = "UPDATE Customer SET CustomerName = @CustomerName, CustomerEmail = @CustomerEmail," +
                  " CustomerPhoneNumber = @CustomerPhoneNumber, CustomerImageUrl = @CustomerImageUrl," +
                  " CustomerTitle = @CustomerTitle, CustomerComment = @CustomerComment, CreatedAt = @CreatedAt," +
                  " CustomerStatus = @CustomerStatus WHERE CustomerId = @CustomerId";
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", updateAboutDto.CustomerId, DbType.Guid);
        parameters.Add("@CustomerName", updateAboutDto.CustomerName, DbType.String);
        parameters.Add("@CustomerEmail", updateAboutDto.CustomerEmail, DbType.String);
        parameters.Add("@CustomerPhoneNumber", updateAboutDto.CustomerPhoneNumber, DbType.String);
        parameters.Add("@CustomerImageUrl", updateAboutDto.CustomerImageUrl, DbType.String);
        parameters.Add("@CustomerTitle", updateAboutDto.CustomerTitle, DbType.String);
        parameters.Add("@CustomerComment", updateAboutDto.CustomerComment, DbType.String);
        parameters.Add("@CreatedAt", updateAboutDto.CreatedAt, DbType.DateTime);
        parameters.Add("@CustomerStatus", updateAboutDto.CustomerStatus, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
    }

    public async void DeleteCategoryAsync(Guid id)
    {
        var sql = "DELETE FROM Customer WHERE CustomerId = @CustomerId";
        var parameters = new DynamicParameters();
        parameters.Add("@CustomerId", id, DbType.Guid);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}