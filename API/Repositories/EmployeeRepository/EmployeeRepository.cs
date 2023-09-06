using System.Data;
using API.DTOs.EmployeeDtos;
using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.AboutDtos;

namespace EindomsHavnAPI.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly Context _context;
    
    public EmployeeRepository(Context context)
    {
        _context = context;
    }
    
    
    
    
    public async Task<IEnumerable<ResultEmployeeDto>> GetAllEmployeeAsync()
    {
        var sql = "SELECT * FROM Employee";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultEmployeeDto>(sql);
            return result.ToList();
        }
        
    }

    public async Task<ResultEmployeeDto> GetEmployeeByIdAsync(Guid id)
    {
        var sql = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeId", id, DbType.Guid);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<ResultEmployeeDto>(sql, parameters);
            return result;
        }
    }

    public async void CreateAboutAsync(CreateEmployeeDto createAboutDto)
    {
        var sql = "INSERT INTO Employee (EmployeeName, EmployeeTitle, EmployeeEmail,EmployeePhoneNumber, EmployeeImageUrl,EmployeeStatus) " +
                  "VALUES (@EmployeeName, @EmployeeTitle, @EmployeeEmail, @EmployeePhoneNumber, @EmployeeImageUrl, @EmployeeStatus)";
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeName", createAboutDto.EmployeeName, DbType.String);
        parameters.Add("@EmployeeTitle", createAboutDto.EmployeeTitle, DbType.String);
        parameters.Add("@EmployeeEmail", createAboutDto.EmployeeEmail, DbType.String);
        parameters.Add("@EmployeePhoneNumber", createAboutDto.EmployeePhoneNumber, DbType.String);
        parameters.Add("@EmployeeImageUrl", createAboutDto.EmployeeImageUrl, DbType.String);
        parameters.Add("@EmployeeStatus",  true);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
    }

    public async void UpdateAboutAsync(UpdateEmployeeDto updateAboutDto)
    {
        var sql = "UPDATE Employee SET EmployeeName = @EmployeeName, EmployeeTitle = @EmployeeTitle, EmployeeEmail = @EmployeeEmail, " +
                  "EmployeePhoneNumber = @EmployeePhoneNumber, EmployeeImageUrl = @EmployeeImageUrl, EmployeeStatus = @EmployeeStatus " +
                  "WHERE EmployeeId = @EmployeeId";
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeId", updateAboutDto.EmployeeId, DbType.Guid);
        parameters.Add("@EmployeeName", updateAboutDto.EmployeeName, DbType.String);
        parameters.Add("@EmployeeTitle", updateAboutDto.EmployeeTitle, DbType.String);
        parameters.Add("@EmployeeEmail", updateAboutDto.EmployeeEmail, DbType.String);
        parameters.Add("@EmployeePhoneNumber", updateAboutDto.EmployeePhoneNumber, DbType.String);
        parameters.Add("@EmployeeImageUrl", updateAboutDto.EmployeeImageUrl, DbType.String);
        parameters.Add("@EmployeeStatus",  updateAboutDto.EmployeeStatus, DbType.Boolean);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
        
    }

    public async void DeleteCategoryAsync(Guid id)
    {
        var sql = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
        var parameters = new DynamicParameters();
        parameters.Add("@EmployeeId", id, DbType.Guid);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}