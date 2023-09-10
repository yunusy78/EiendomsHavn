using System.ComponentModel.DataAnnotations;

namespace EindomsHavnAPI.DTOs.ApplicationUserDto;

public class ResetPasswordDto
{
    [Microsoft.Build.Framework.Required]
    public string Email { get; set; }

    [Microsoft.Build.Framework.Required]
    public string ResetToken { get; set; }

    [Microsoft.Build.Framework.Required]
    [StringLength(100, ErrorMessage = "Şifre en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}