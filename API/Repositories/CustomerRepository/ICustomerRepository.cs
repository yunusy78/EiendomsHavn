using API.DTOs.EmployeeDtos;
using EindomsHavnAPI.DTOs.AboutDtos;
using EindomsHavnAPI.DTOs.Customer;

namespace EindomsHavnAPI.Repositories.EmployeeRepository;

public interface ICustomerRepository
{
    Task<IEnumerable<ResultCustomerDto>> GetAllEmployeeAsync();
    Task<ResultCustomerDto> GetEmployeeByIdAsync(Guid id);
    void  CreateAboutAsync(CreateCustomerDto createAboutDto);
    void  UpdateAboutAsync(ResultCustomerDto updateAboutDto);
    void DeleteCategoryAsync(Guid id);
}