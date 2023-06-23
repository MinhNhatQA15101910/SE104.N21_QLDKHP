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
    public class HuyenDAL
    {
        public static List<CT_Huyen> LayDSHuyen()
        {
            List<CT_Huyen> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<CT_Huyen>("spHUYEN_LayDSHuyen").ToList();
            }
            return output;
        }

        public static SuaHuyenMessage SuaHuyen(int maHuyen, string tenHuyen, int vungUT, int maTinh)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaHuyen", maHuyen);
                    p.Add("@TenHuyen", tenHuyen);
                    p.Add("@VungUT", vungUT);
                    p.Add("@MaTinh", maTinh);
                    connection.Execute("spHUYEN_SuaHuyen", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_HUYEN_TenHuyen"))
                    {
                        return SuaHuyenMessage.DuplicateTenHuyen;
                    }
                }
            }
            catch (Exception)
            {
                return SuaHuyenMessage.Error;
            }

            return SuaHuyenMessage.Success;
        }

        public static XoaHuyenMessage XoaHuyen(int maHuyen)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaHuyen", maHuyen);
                    connection.Execute("spHUYEN_XoaHuyen", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaHuyenMessage.Error;
            }

            return XoaHuyenMessage.Success;
        }

        public static ThemHuyenMessage ThemHuyen(string tenHuyen, int vungUT, int maTinh)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@TenHuyen", tenHuyen);
                    p.Add("@VungUT", vungUT);
                    p.Add("@MaTinh", maTinh);
                    connection.Execute("spHUYEN_ThemHuyen", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_HUYEN_TenHuyen"))
                    {
                        return ThemHuyenMessage.DuplicateTenHuyen;
                    }
                }
            }
            catch (Exception)
            {
                return ThemHuyenMessage.Error;
            }

            return ThemHuyenMessage.Success;
        }
    }
}
