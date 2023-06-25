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
    public class MonHocMoDAL
    {
        public static List<HocKyNamHoc> GetAllHocKyNamHoc()
        {
            List<HocKyNamHoc> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<HocKyNamHoc>("spDANHSACHMONHOCMO_GetHocKyNamHoc").ToList();
            }

            return output;
        }

        public static MessageAddMonHocMo AddMonHocMo(string MaMH, int MaHocKy, int NamHoc)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaHocKy", MaHocKy);
                    p.Add("@MaMH", MaMH);
                    p.Add("@NamHoc", NamHoc);
                    connection.Execute("spDANHSACHMONHOCMO_AddMonHocMo", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageAddMonHocMo.Failed;
            }
            return MessageAddMonHocMo.Success;
        }

        public static List<int> GetAllNamHoc()
        {
            List<int> output;

            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<int>("spDANHSACHMONHOCMO_GetNam").ToList();
            }

            return output;
        }

        public static MessageDeleteHocKyNamHocMHM DeleteHocKyNamHocMHM(int MaHocKy, int NamHoc)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var mhm = new DynamicParameters();
                    mhm.Add("@MaHocKy", MaHocKy);
                    mhm.Add("@NamHoc", NamHoc);
                    connection.Execute("spDANHSACHMONHOCMO_XoaDanhSach", mhm, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return MessageDeleteHocKyNamHocMHM.Failed;
            }
            return MessageDeleteHocKyNamHocMHM.Success;
        }
    }
}
