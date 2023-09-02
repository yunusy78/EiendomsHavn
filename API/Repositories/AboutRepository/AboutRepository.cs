using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.AboutDtos;

namespace EindomsHavnAPI.Repositories.AboutRepository;

public class AboutRepository : IAboutRepository
{
    private readonly Context _context;
    
    public AboutRepository(Context context)
    {
        _context = context;
    }
    
    
    
    
    public async Task<IEnumerable<ResultAboutDto>> GetAllAboutAsync()
    {
        var sql = "SELECT * FROM Abouts";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultAboutDto>(sql);
            return result.ToList();
        }
        
    }

    public Task<ResultAboutDto> GetAboutByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAboutAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}