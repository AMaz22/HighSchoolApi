using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DapperORM
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration _configuration;

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void QueryStoredProcedure(string storedProcedureName, Action<SqlMapper.GridReader> callbackReader, object parameters = null)
        {
            using (var connection = Open())
            {
                var procedure = connection.QueryMultiple(storedProcedureName, param: parameters, commandTimeout: 60, commandType: System.Data.CommandType.StoredProcedure);
                callbackReader(procedure);
            }
        }
        public async Task QueryStoredProcedureAsync(string storedProcedureName, Action<SqlMapper.GridReader> callbackReader, object parameters = null)
        {
            using (var connection = Open())
            {
                var procedure = await connection.QueryMultipleAsync(storedProcedureName, param: parameters, commandTimeout: 60, commandType: System.Data.CommandType.StoredProcedure);
                callbackReader(procedure);
            }
        }

        private SqlConnection Open()
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DbConnection"));

            sqlConnection.Open();

            return sqlConnection;
        }
    }
}