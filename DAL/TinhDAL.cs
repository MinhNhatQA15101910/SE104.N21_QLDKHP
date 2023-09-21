using Dapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class TinhDAL
    {
        public static List<Tinh> LayDSTinh()
        {
            List<Tinh> output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.Query<Tinh>("spTINH_LayDSTinh").ToList();
            }
            return output;
        }

        public static SuaTinhMessage SuaTinh(int maTinh, string tenTinh)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaTinh", maTinh);
                    p.Add("@TenTinh", tenTinh);
                    connection.Execute("spTINH_SuaTinh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_TINH_TenTinh"))
                    {
                        return SuaTinhMessage.DuplicateTenTinh;
                    }
                }
            }
            catch (Exception)
            {
                return SuaTinhMessage.Error;
            }

            return SuaTinhMessage.Success;
        }

        public static XoaTinhMessage XoaTinh(int maTinh)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@MaTinh", maTinh);
                    connection.Execute("spTINH_XoaTinh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return XoaTinhMessage.Error;
            }

            return XoaTinhMessage.Success;
        }

        public static ThemTinhMessage ThemTinh(string tenTinh)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@TenTinh", tenTinh);
                    connection.Execute("spTINH_ThemTinh", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("UQ_TINH_TenTTP"))
                    {
                        return ThemTinhMessage.DuplicateTenTinh;
                    }
                }
            }
            catch (Exception)
            {
                return ThemTinhMessage.Error;
            }

            return ThemTinhMessage.Success;
        }
    }
}
