using System.Data;
using Dapper;
using EindomsHavnAPI.Data.Context;
using EindomsHavnAPI.DTOs.ApplicationUserDto;
using Microsoft.AspNetCore.Identity;

namespace EindomsHavnAPI.Repositories.ApplicationUserRepository;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly Context _context;
    

    public ApplicationUserRepository(Context context)
    {
        _context = context;
        
    }

    public async Task<IEnumerable<ApplicationUserDto>> GetAllUserAsync()
    {
        var sql = "SELECT * FROM Users";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<ApplicationUserDto>(sql);
            return result.ToList();
        }
    }

    public async Task<bool> RegisterUser(ApplicationUserDto applicationUserDto)
    {
        try
        {
            // Yeni kullanıcıyı veritabanına eklemek için Dapper kullanımı
            var sql = "INSERT INTO Users (Email, PasswordHash) VALUES (@Email, @PasswordHash)";
        
            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(sql, applicationUserDto);
            
                // Etkilenen satır sayısını kontrol edin
                return affectedRows > 0;
            }
        }
        catch (Exception ex)
        {
            // Hata işleme burada
            // Loglama veya hata mesajı döndürme
            return false;
        }
    }

    
    
    public async Task<ApplicationUserDto> AuthenticateUser(string email, string password)
    {
        try
        {
            // Kullanıcıyı kullanıcı adına göre veritabanından bulun
            var query = "SELECT * FROM Users WHERE Email = @Email";
        
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<ApplicationUserDto>(query, new { Email = email });

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    // Şifre doğrulandı, kullanıcıyı döndürün
                    return user;
                }
                else
                {
                    // Kullanıcı bulunamadı veya şifre doğrulanamadı
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            // Hata işleme burada
            // Loglama veya hata mesajı döndürme
            return null;
        }
    }

    public async Task<string> GetRolesForUser(ApplicationUserDto userDto)
    {
        try
        {
            var query = "SELECT Roles.RoleName FROM Roles INNER JOIN UserRoles ON Roles.RoleId = UserRoles.RoleId  " +
                        "INNER JOIN Users ON Users.Id = UserRoles.UserId WHERE Users.Email = @Email;";

            using (var connection = _context.CreateConnection())
            {
                var roles = await connection.QueryAsync<string>(query, new { Email = userDto.Email });

                return roles.FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            // Hata işleme burada
            // Loglama veya hata mesajı döndürme
            return null;
        }
    }




}