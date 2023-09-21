using Dapper;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class HocKyDAL
    {
        public static List<HocKy> LayDanhSachHK()
        {
            List<HocKy> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<HocKy>("spHOCKY_LayDanhSachHK").ToList();
            }
            return output;
        }

        public static string LayHKByMaHK(int currMaHocKy)
        {
            string output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@MaHocKy", currMaHocKy);
                output = connection.QueryFirst<string>("spHOCKY_LayHKByMaHK", p, commandType: CommandType.StoredProcedure);
            }
            return output;
        }
    }
}
