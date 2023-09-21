using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class KhoaDAL
    {
        public static List<Khoa> LayDSKhoa()
        {
            List<Khoa> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<Khoa>("spKHOA_LayDSKhoa").ToList();
            }
            return output;
        }

        public static SuaKhoaMessage SuaKhoa(string maKhoaBanDau, string maKhoaSua, string tenKhoaSua)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoaBanDau", maKhoaBanDau);
                    p.Add("@MaKhoaSua", maKhoaSua);
                    p.Add("@TenKhoaSua", tenKhoaSua);
                    connection.Execute("spKHOA_SuaKhoa", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_KHOA_TenKhoa"))
                    {
                        return SuaKhoaMessage.DuplicateTenKhoa;
                    }
                }
            }
            catch (Exception)
            {
                return SuaKhoaMessage.Error;
            }

            return SuaKhoaMessage.Success;
        }

        public static ThemKhoaMessage ThemKhoa(string maKhoa, string tenKhoa)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoa", maKhoa);
                    p.Add("@TenKhoa", tenKhoa);
                    connection.Execute("spKHOA_ThemKhoa", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("PK_KHOA"))
                    {
                        return ThemKhoaMessage.DuplicateMaKhoa;
                    }
                    else if (ex.Message.Contains("UQ_KHOA_TenKhoa"))
                    {
                        return ThemKhoaMessage.DuplicateTenKhoa;
                    }
                }
            }
            catch (Exception)
            {
                return ThemKhoaMessage.Error;
            }

            return ThemKhoaMessage.Success;
        }

        public static XoaKhoaMessage XoaKhoa(string maKhoa)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaKhoa", maKhoa);
                    connection.Execute("spKHOA_XoaKhoa", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaKhoaMessage.Error;
            }

            return XoaKhoaMessage.Success;
        }
    }
}
