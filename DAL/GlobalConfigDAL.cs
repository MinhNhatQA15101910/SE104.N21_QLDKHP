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

        public static int LaySoTinChiToiDa()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LaySoTinChiToiDa");
            }
            return output;
        }

        public static object LaySoTinChiToiThieu()
        {
            int output;
            using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
            {
                output = connection.QueryFirst<int>("spGLOBALCONFIG_LaySoTinChiToiThieu");
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

        public static SuaGioiHanTinChiMessage SuaGioiHanTinChi(int tinChiToiDa, int tinChiToiThieu)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(DatabaseConnection.CnnString()))
                {
                    var p = new DynamicParameters();
                    p.Add("@SoTinChiToiDa", tinChiToiDa);
                    p.Add("@SoTinChiToiThieu", tinChiToiThieu);
                    connection.Execute("spGLOBALCONFIG_SuaGioiHanTinChi", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                return SuaGioiHanTinChiMessage.Error;
            }

            return SuaGioiHanTinChiMessage.Success;
        }
    }
}
