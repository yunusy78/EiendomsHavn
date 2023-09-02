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

    public Task<ResultEmployeeDto> GetEmployeeByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteEmployeeAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}