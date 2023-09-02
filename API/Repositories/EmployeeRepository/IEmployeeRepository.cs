using API.DTOs.EmployeeDtos;
using EindomsHavnAPI.DTOs.AboutDtos;

namespace EindomsHavnAPI.Repositories.EmployeeRepository;

public interface IEmployeeRepository
{
    Task<IEnumerable<ResultEmployeeDto>> GetAllEmployeeAsync();
    Task<ResultEmployeeDto> GetEmployeeByIdAsync(Guid id);
    //Task<ResultAboutDto> CreateAboutAsync(CreateAboutDto createAboutDto);
    //Task<ResultAboutDto> UpdateAboutAsync(Guid id, UpdateAboutDto updateAboutDto);
    Task<bool> DeleteEmployeeAsync(Guid id);
}