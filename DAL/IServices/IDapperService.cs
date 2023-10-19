using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DAL.IServices
{
    public interface IDapperService
    {
        IEnumerable<T> Query<T>(IDbConnection connection, string sql);
        int Execute(IDbConnection connection, string sql, DynamicParameters p, CommandType commandType);
    }
}
