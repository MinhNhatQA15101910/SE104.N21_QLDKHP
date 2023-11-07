using DAL.IServices;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Services
{
    [ExcludeFromCodeCoverage]
    public class DapperWrapper : IDapperWrapper
    {
        public int Execute(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType)
        {
            return dbConnection.Execute(sql, p, commandType: commandType);
        }

        public IEnumerable<T> Query<T>(IDbConnection dbConnection, string sql)
        {
            return dbConnection.Query<T>(sql);
        }

        public IEnumerable<T> Query<T>(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType)
        {
            return dbConnection.Query<T>(sql, p, commandType: commandType);
        }

        public T QueryFirst<T>(IDbConnection dbConnection, string sql)
        {
            return dbConnection.QueryFirst<T>(sql);
        }

        public T QueryFirst<T>(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType)
        {
            return dbConnection.QueryFirst<T>(sql, p, commandType: commandType);
        }

        public T QueryFirstOrDefault<T>(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType)
        {
            return dbConnection.QueryFirstOrDefault<T>(sql, p, commandType: commandType);
        }

        public T QuerySingleOrDefault<T>(IDbConnection dbConnection, string sql, DynamicParameters p, CommandType commandType)
        {
            return dbConnection.QuerySingleOrDefault<T>(sql, p, commandType: commandType);
        }
    }
}
