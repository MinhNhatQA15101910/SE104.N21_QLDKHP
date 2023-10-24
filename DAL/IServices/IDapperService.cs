using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DAL.IServices
{
    public interface IDapperService
    {
        IEnumerable<T> Query<T>(IDbConnection connection, string sql);
        IEnumerable<T> Query<T>(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType);
        int Execute(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType);
    }
}
