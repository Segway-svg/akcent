using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace akcent.Db
{
    public class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection(IOptions<DbSettings> dbSettings)
        {
            _connectionString = dbSettings.Value.ConnectionString;
        }

        public SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
