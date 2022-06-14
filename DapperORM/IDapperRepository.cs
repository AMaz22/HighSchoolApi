using Dapper;

namespace DapperORM
{
    public interface IDapperRepository
    {
        Task QueryStoredProcedureAsync(string storedProcedureName, Action<SqlMapper.GridReader> callbackReader, object parameters = null);
        void QueryStoredProcedure(string storedProcedureName, Action<SqlMapper.GridReader> callbackReader, object parameters = null);
    }
}