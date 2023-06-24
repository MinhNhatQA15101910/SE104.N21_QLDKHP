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
    public class MonHocDAL
    {
        public static List<CT_MonHoc> LayDSMonHoc()
        {
            List<CT_MonHoc> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<CT_MonHoc>("spMONHOC_LayDSMonHoc").ToList();
            }
            return output;
        }

        public static XoaMonHocMessage XoaMonHoc(string maMH)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaMH", maMH);
                    connection.Execute("spMONHOC_XoaMonHoc", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaMonHocMessage.Error;
            }

            return XoaMonHocMessage.Success;
        }

        public static SuaMonHocMessage SuaMonHoc(string maMHBanDau, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaMH", maMHBanDau);
                    p.Add("@TenMH", tenMH);
                    p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                    p.Add("@SoTiet", soTiet);
                    connection.Execute("spMONHOC_SuaMonHoc", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return SuaMonHocMessage.Error;
            }

            return SuaMonHocMessage.Success;
        }

        public static ThemMonHocMessage ThemMonHoc(string maMH, string tenMH, int maLoaiMonHoc, int soTiet)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaMH", maMH);
                    p.Add("@TenMH", tenMH);
                    p.Add("@MaLoaiMonHoc", maLoaiMonHoc);
                    p.Add("@SoTiet", soTiet);
                    connection.Execute("spMONHOC_ThemMonHoc", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("PK_MONHOC"))
                    {
                        return ThemMonHocMessage.DuplicateMaMH;
                    }
                }
            }
            catch (Exception)
            {
                return ThemMonHocMessage.Error;
            }

            return ThemMonHocMessage.Success;
        }
    }
}
