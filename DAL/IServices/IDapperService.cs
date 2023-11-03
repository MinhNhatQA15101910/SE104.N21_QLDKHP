using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DAL.IServices
{
    public interface IDapperService
    {
        IEnumerable<T> Query<T>(string sql);
        IEnumerable<T> Query<T>(string sql, DynamicParameters p, CommandType commandType);
        T QueryFirst<T>(string sql);
        T QueryFirst<T>(string sql, DynamicParameters p, CommandType commandType);
        T QueryFirstOrDefault<T>(string sql, DynamicParameters p, CommandType commandType);
        T QuerySingleOrDefault<T>(string sql, DynamicParameters p, CommandType commandType);
        int Execute(string sql, DynamicParameters p, CommandType commandType);
    }
}
