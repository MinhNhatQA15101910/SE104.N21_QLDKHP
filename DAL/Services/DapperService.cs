using DAL.IServices;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class DapperService : IDapperService
    {
        private readonly IDbConnection _connection;

        public DapperService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public int Execute(string sql, DynamicParameters p, CommandType commandType)
        {
            return _connection.Execute(sql, p, commandType: commandType);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return _connection.Query<T>(sql);
        }

        public IEnumerable<T> Query<T>(string sql, DynamicParameters p, CommandType commandType)
        {
            return _connection.Query<T>(sql, p, commandType: commandType);
        }

        public T QueryFirst<T>(string sql)
        {
            return _connection.QueryFirst<T>(sql);
        }

        public T QueryFirst<T>(string sql, DynamicParameters p, CommandType commandType)
        {
            return _connection.QueryFirst<T>(sql, p, commandType: commandType);
        }

        public T QueryFirstOrDefault<T>(string sql, DynamicParameters p, CommandType commandType)
        {
            return _connection.QueryFirstOrDefault<T>(sql, p, commandType: commandType);
        }

        public T QuerySingleOrDefault<T>(string sql, DynamicParameters p, CommandType commandType)
        {
            return _connection.QuerySingleOrDefault<T>(sql, p, commandType: commandType);
        }
    }
}
