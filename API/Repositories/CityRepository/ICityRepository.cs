using EindomsHavnAPI.DTOs.CityDtos;

namespace EindomsHavnAPI.Repositories.CityRepository;

public interface ICityRepository
{
    
    public Task<List<ResultCityDto>> GetCitiesWithCount();
    
}