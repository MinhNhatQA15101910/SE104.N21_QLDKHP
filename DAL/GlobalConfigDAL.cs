using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GlobalConfigDAL
    {
        public static int GetCurrNamHoc()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LayNamHocHienTai");
            }
            return output;
        }

        public static int GetCurrMaHocKy()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@NamHocHienTai", GlobalConfig.CurrNamHoc);
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LayMaHocKyHienTai", p, commandType: CommandType.StoredProcedure);
            }
            return output;
        }
    }
}
