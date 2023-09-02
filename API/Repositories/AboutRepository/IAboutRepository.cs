using EindomsHavnAPI.DTOs.AboutDtos;

namespace EindomsHavnAPI.Repositories.AboutRepository;

public interface IAboutRepository
{
    Task<IEnumerable<ResultAboutDto>> GetAllAboutAsync();
    Task<ResultAboutDto> GetAboutByIdAsync(Guid id);
    //Task<ResultAboutDto> CreateAboutAsync(CreateAboutDto createAboutDto);
    //Task<ResultAboutDto> UpdateAboutAsync(Guid id, UpdateAboutDto updateAboutDto);
    Task<bool> DeleteAboutAsync(Guid id);
}