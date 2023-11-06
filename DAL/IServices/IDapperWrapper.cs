using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DAL.IServices
{
    public interface IDapperWrapper
    {
        IEnumerable<T> Query<T>(IDbConnection dbConnection, string sql);
        IEnumerable<T> Query<T>(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType);
        T QueryFirst<T>(IDbConnection dbConnection, string sql);
        T QueryFirst<T>(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType);
        T QueryFirstOrDefault<T>(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType);
        int Execute(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType);
    }
}
