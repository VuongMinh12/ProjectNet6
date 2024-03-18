using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication3.Models
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = configuration.GetConnectionString("KeyboardDbString");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connection);
    }
}
