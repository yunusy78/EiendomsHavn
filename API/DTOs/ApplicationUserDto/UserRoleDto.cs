namespace EindomsHavnAPI.DTOs.ApplicationUserDto;

public class UserRoleDto
{
    public string RoleName { get; set; }
    public string RoleId { get; set; }
    public string UserId { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    
}