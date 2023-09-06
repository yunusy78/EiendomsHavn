using API.DTOs.EmployeeDtos;
using EindomsHavnAPI.DTOs.AboutDtos;

namespace EindomsHavnAPI.Repositories.EmployeeRepository;

public interface IEmployeeRepository
{
    Task<IEnumerable<ResultEmployeeDto>> GetAllEmployeeAsync();
    Task<ResultEmployeeDto> GetEmployeeByIdAsync(Guid id);
    void  CreateAboutAsync(CreateEmployeeDto createAboutDto);
    void  UpdateAboutAsync(UpdateEmployeeDto updateAboutDto);
    void DeleteCategoryAsync(Guid id);
}