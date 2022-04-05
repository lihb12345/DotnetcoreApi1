using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo2
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly IConfiguration _configuration;
        public DbConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetDatabaseConnection()
        {
            var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return sqlConnection;
        }
    }
}
