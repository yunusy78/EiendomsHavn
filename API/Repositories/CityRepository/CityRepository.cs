using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.CityDtos;

namespace EindomsHavnAPI.Repositories.CityRepository;

public class CityRepository : ICityRepository
{
    private readonly Context _context;
    
    public CityRepository(Context context)
    {
        _context = context;
    }
    
    
    public async Task<List<ResultCityDto>> GetCitiesWithCount()
    {
        string sql ="Select * from Addresses";
        
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ResultCityDto>(sql);
            return result.ToList();
        }
        
        
    }
}