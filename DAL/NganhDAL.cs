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
    public class NganhDAL
    {
        public static List<CT_Nganh> LayDSNganh()
        {
            List<CT_Nganh> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<CT_Nganh>("spNGANH_LayDSNganh").ToList();
            }
            return output;
        }

        public static XoaNganhMessage XoaNganh(string maNganh)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", maNganh);
                    connection.Execute("spNGANH_XoaNganh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaNganhMessage.Error;
            }

            return XoaNganhMessage.Success;
        }

        public static SuaNganhMessage SuaNganh(string maNganhBanDau, string maNganhSua, string tenNganhSua, string maKhoaSua)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganhBanDau", maNganhBanDau);
                    p.Add("@MaNganh", maNganhSua);
                    p.Add("@TenNganh", tenNganhSua);
                    p.Add("@MaKhoa", maKhoaSua);
                    connection.Execute("spNGANH_SuaNganh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_NGANH_TenNganh"))
                    {
                        return SuaNganhMessage.DuplicateTenNganh;
                    }
                }
            }
            catch (Exception)
            {
                return SuaNganhMessage.Error;
            }

            return SuaNganhMessage.Success;
        }

        public static ThemNganhMessage ThemNganh(string maNganh, string tenNganh, string maKhoa)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaNganh", maNganh);
                    p.Add("@TenNganh", tenNganh);
                    p.Add("@MaKhoa", maKhoa);
                    connection.Execute("spNGANH_ThemNganh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("PK_NGANH"))
                    {
                        return ThemNganhMessage.DuplicateMaNganh;
                    }
                    else if (ex.Message.Contains("UQ_NGANH_TenNganh"))
                    {
                        return ThemNganhMessage.DuplicateTenNganh;
                    }
                }
            }
            catch (Exception)
            {
                return ThemNganhMessage.Error;
            }

            return ThemNganhMessage.Success;
        }
    }
}
