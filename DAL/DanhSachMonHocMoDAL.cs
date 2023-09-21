using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DanhSachMonHocMoDAL
    {
        public static List<string> LayDSMonHocMo()
        {
            List<string> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<string>("spDANHSACHMONHOCMO_LayDSMonHocMo").ToList();
            }

            return output;
        }

        public static List<dynamic> LayDanhSachMonHocMo(int hocKy, int namHoc)
        {
            List<dynamic> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);

                output = connection.Query<dynamic>("spDANHSACHMONHOCMO_LayDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public static List<dynamic> TimKiemDanhSachMonHocMo(int hocKy, int namHoc, string monHoc)
        {
            List<dynamic> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@hocKy", hocKy);
                parameters.Add("@namHoc", namHoc);
                parameters.Add("@monHoc", monHoc);


                output = connection.Query<dynamic>("spDANHSACHMONHOCMO_TimKiemDSMH", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }
    }
}
