using EindomsHavnAPI.DTOs.ApplicationUserDto;
using EindomsHavnAPI.Model;

namespace EindomsHavnAPI.Repositories.ApplicationUserRepository;

public interface IApplicationUserRepository
{
    
    Task<IEnumerable<ApplicationUserDto>> GetAllUserAsync();
    Task<bool> RegisterUser(ApplicationUserDto applicationUserDto);
    Task<ApplicationUserDto> AuthenticateUser(string userName, string password);
    Task<string> GetRolesForUser(ApplicationUserDto dto);


}