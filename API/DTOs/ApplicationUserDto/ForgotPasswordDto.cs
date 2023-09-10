using Castle.Components.DictionaryAdapter;

namespace EindomsHavnAPI.DTOs.ApplicationUserDto;

public class ForgotPasswordDto
{
    public string Id { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; }

    // Şifre sıfırlama için kullanılan token
    public string ResetToken { get; set; }

    // Şifre sıfırlama token'ının geçerlilik süresi
    public DateTime? ResetTokenExpiry { get; set; }
}