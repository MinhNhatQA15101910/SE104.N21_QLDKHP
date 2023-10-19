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
    }
}
