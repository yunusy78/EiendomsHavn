using System.Data;
using Microsoft.Data.SqlClient;

namespace EindomsHavnAPI.Data.Context;

public class Context
{
    private readonly IConfiguration _configuration;
    
    private readonly string _connectionString;
    
    public Context(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }
    
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    
}