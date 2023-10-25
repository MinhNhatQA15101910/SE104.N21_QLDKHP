using DAL.IServices;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DAL.Services
{
    public class DapperService : IDapperService
    {
        public int Execute(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType)
        {
            return connection.Execute(sql, p, commandType: commandType);
        }

        public IEnumerable<T> Query<T>(IDbConnection connection, string sql)
        {
            return connection.Query<T>(sql);
        }

        public IEnumerable<T> Query<T>(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType)
        {
            return connection.Query<T>(sql, p, commandType: commandType);
        }

        public T QueryFirst<T>(IDbConnection connection, string sql)
        {
            return connection.QueryFirst<T>(sql);
        }

        public T QueryFirst<T>(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType)
        {
            return connection.QueryFirst<T>(sql, p, commandType: commandType);
        }

        public T QueryFirstOrDefault<T>(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType)
        {
            return connection.QueryFirstOrDefault<T>(sql, p, commandType: commandType);
        }

        public T QuerySingleOrDefault<T>(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType)
        {
            return connection.QuerySingleOrDefault<T>(sql, p, commandType: commandType);
        }
    }
}
